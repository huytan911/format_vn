import React, { useState, useEffect } from 'react';
import api from '../../config/axiosConfig';
import AdminLayout from '../../components/AdminLayout/AdminLayout';
import DataTable from '../../components/DataTable/DataTable';
import Modal from '../../components/Modal/Modal';
import MultiSelect from '../../components/MultiSelect/MultiSelect';
import '../../styles/admin.css';

const AdminProducts = () => {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
    const [isRemoveCategoryModalOpen, setIsRemoveCategoryModalOpen] = useState(false);
    const [selectedProduct, setSelectedProduct] = useState(null);
    const [categoryToRemove, setCategoryToRemove] = useState(null);
    const [formData, setFormData] = useState({
        name: '',
        description: '',
        price: '',
        categoryIds: [],
        imageUrl: '',
        stock: '',
        isFeatured: false
    });

    useEffect(() => {
        fetchProducts();
        fetchCategories();
    }, []);

    const fetchProducts = async () => {
        try {
            const response = await api.get('/products');
            setProducts(response.data);
        } catch (error) {
            console.error('Error fetching products:', error);
        }
    };

    const fetchCategories = async () => {
        try {
            const response = await api.get('/categories');
            setCategories(response.data);
        } catch (error) {
            console.error('Error fetching categories:', error);
        }
    };

    const handleCreate = () => {
        setSelectedProduct(null);
        setFormData({
            name: '',
            description: '',
            price: '',
            categoryIds: [],
            imageUrl: '',
            stock: '',
            isFeatured: false
        });
        setIsModalOpen(true);
    };

    const handleEdit = (product) => {
        setSelectedProduct(product);
        setFormData({
            name: product.name,
            description: product.description || '',
            price: product.price,
            categoryIds: product.categories ? product.categories.map(c => c.id) : [],
            imageUrl: product.imageUrl || '',
            stock: product.stock,
            isFeatured: product.isFeatured
        });
        setIsModalOpen(true);
    };

    const handleDelete = (product) => {
        setSelectedProduct(product);
        setIsDeleteModalOpen(true);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const data = {
                ...formData,
                price: parseFloat(formData.price),
                stock: parseInt(formData.stock),
                categoryIds: formData.categoryIds.map(id => parseInt(id)),
                id: selectedProduct ? selectedProduct.id : undefined
            };

            if (selectedProduct) {
                await api.put(`/products/${selectedProduct.id}`, data);
            } else {
                await api.post('/products', data);
            }

            setIsModalOpen(false);
            fetchProducts();
        } catch (error) {
            console.error('Error saving product:', error);
            alert('Lỗi khi lưu sản phẩm');
        }
    };

    const confirmDelete = async () => {
        try {
            await api.delete(`/products/${selectedProduct.id}`);
            setIsDeleteModalOpen(false);
            fetchProducts();
        } catch (error) {
            console.error('Error deleting product:', error);
            alert('Lỗi khi xóa sản phẩm');
        }
    };

    const confirmRemoveCategory = async () => {
        if (!categoryToRemove) return;

        const { product, categoryId } = categoryToRemove;

        try {
            const currentCategoryIds = product.categories.map(c => c.id);
            const newCategoryIds = currentCategoryIds.filter(id => id !== categoryId);

            const updateData = {
                id: product.id,
                name: product.name,
                description: product.description,
                price: product.price,
                imageUrl: product.imageUrl,
                stock: product.stock,
                isFeatured: product.isFeatured,
                categoryIds: newCategoryIds
            };

            await api.put(`/products/${product.id}`, updateData);
            setIsRemoveCategoryModalOpen(false);
            setCategoryToRemove(null);
            fetchProducts();
        } catch (error) {
            console.error('Error removing category:', error);
            alert('Lỗi khi xóa danh mục khỏi sản phẩm');
        }
    };

    const handleRemoveCategory = (e, product, categoryId) => {
        e.stopPropagation();
        setCategoryToRemove({ product, categoryId });
        setIsRemoveCategoryModalOpen(true);
    };

    const handleCategoryChange = (catId) => {
        const id = parseInt(catId);
        setFormData(prev => {
            if (prev.categoryIds.includes(id)) {
                return { ...prev, categoryIds: prev.categoryIds.filter(c => c !== id) };
            } else {
                return { ...prev, categoryIds: [...prev.categoryIds, id] };
            }
        });
    };

    const columns = [
        { header: 'ID', accessor: 'id', sortable: true },
        { header: 'Tên sản phẩm', accessor: 'name', sortable: true },
        {
            header: 'Danh mục',
            accessor: 'categories',
            render: (item) => (
                <div className="category-tags">
                    {item.categories && item.categories.length > 0 ? (
                        item.categories.map(cat => (
                            <span key={cat.id} className="badge badge-info mr-1 category-badge-pill">
                                {cat.name}
                                <span
                                    className="remove-cat-btn"
                                    onClick={(e) => handleRemoveCategory(e, item, cat.id)}
                                    title="Xóa danh mục này"
                                >
                                    ×
                                </span>
                            </span>
                        ))
                    ) : (
                        <span className="text-gray">Chưa phân loại</span>
                    )}
                </div>
            )
        },
        {
            header: 'Giá',
            accessor: 'price',
            sortable: true,
            render: (item) => item.price.toLocaleString('vi-VN') + 'đ'
        },
        { header: 'Tồn kho', accessor: 'stock', sortable: true },
        {
            header: 'Nổi bật',
            accessor: 'isFeatured',
            render: (item) => (
                <span className={`badge ${item.isFeatured ? 'badge-success' : 'badge-secondary'}`}>
                    {item.isFeatured ? '⭐ Có' : 'Không'}
                </span>
            )
        }
    ];

    return (
        <AdminLayout>
            <div className="admin-page-header">
                <h1>Quản lý Sản phẩm</h1>
                <button className="btn-primary" onClick={handleCreate}>
                    + Thêm sản phẩm mới
                </button>
            </div>

            <DataTable
                columns={columns}
                data={products}
                onEdit={handleEdit}
                onDelete={handleDelete}
            />

            <Modal
                isOpen={isModalOpen}
                onClose={() => setIsModalOpen(false)}
                title={selectedProduct ? 'Chỉnh sửa sản phẩm' : 'Thêm sản phẩm mới'}
                size="large"
            >
                <form onSubmit={handleSubmit} className="admin-form">
                    <div className="form-row">
                        <div className="form-group">
                            <label>Tên sản phẩm *</label>
                            <input
                                type="text"
                                value={formData.name}
                                onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                                required
                            />
                        </div>
                        <div className="form-group">
                            <label>Danh mục</label>
                            <MultiSelect
                                options={categories}
                                selectedIds={formData.categoryIds}
                                onChange={(newSelectedIds) => setFormData({ ...formData, categoryIds: newSelectedIds })}
                                placeholder="Chọn danh mục..."
                            />
                        </div>
                    </div>

                    <div className="form-row">
                        <div className="form-group">
                            <label>Giá (VNĐ) *</label>
                            <input
                                type="number"
                                value={formData.price}
                                onChange={(e) => setFormData({ ...formData, price: e.target.value })}
                                required
                                min="0"
                            />
                        </div>
                        <div className="form-group">
                            <label>Tồn kho *</label>
                            <input
                                type="number"
                                value={formData.stock}
                                onChange={(e) => setFormData({ ...formData, stock: e.target.value })}
                                required
                                min="0"
                            />
                        </div>
                    </div>

                    <div className="form-group">
                        <label>Mô tả</label>
                        <textarea
                            value={formData.description}
                            onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                            rows="4"
                        />
                    </div>

                    <div className="form-group">
                        <label>URL hình ảnh</label>
                        <input
                            type="url"
                            value={formData.imageUrl}
                            onChange={(e) => setFormData({ ...formData, imageUrl: e.target.value })}
                            placeholder="https://example.com/image.jpg"
                        />
                    </div>

                    <div className="form-group">
                        <label className="checkbox-label">
                            <input
                                type="checkbox"
                                checked={formData.isFeatured}
                                onChange={(e) => setFormData({ ...formData, isFeatured: e.target.checked })}
                            />
                            <span>Sản phẩm nổi bật</span>
                        </label>
                    </div>

                    <div className="form-actions">
                        <button type="button" className="btn-secondary" onClick={() => setIsModalOpen(false)}>
                            Hủy
                        </button>
                        <button type="submit" className="btn-primary">
                            {selectedProduct ? 'Cập nhật' : 'Tạo mới'}
                        </button>
                    </div>
                </form>
            </Modal>

            <Modal
                isOpen={isDeleteModalOpen}
                onClose={() => setIsDeleteModalOpen(false)}
                title="Xác nhận xóa"
                size="small"
            >
                <div className="delete-confirmation">
                    <p>Bạn có chắc chắn muốn xóa sản phẩm <strong>{selectedProduct?.name}</strong>?</p>
                    <div className="form-actions">
                        <button className="btn-secondary" onClick={() => setIsDeleteModalOpen(false)}>
                            Hủy
                        </button>
                        <button className="btn-danger" onClick={confirmDelete}>
                            Xóa
                        </button>
                    </div>
                </div>
            </Modal>
            <Modal
                isOpen={isRemoveCategoryModalOpen}
                onClose={() => setIsRemoveCategoryModalOpen(false)}
                title="Xác nhận xóa danh mục"
                size="small"
            >
                <div className="delete-confirmation">
                    <p>
                        Bạn có chắc chắn muốn xóa danh mục khỏi sản phẩm
                        <strong> "{categoryToRemove?.product?.name}"</strong>?
                    </p>
                    <div className="form-actions">
                        <button
                            className="btn-secondary"
                            onClick={() => setIsRemoveCategoryModalOpen(false)}
                        >
                            Hủy
                        </button>
                        <button
                            className="btn-danger"
                            onClick={confirmRemoveCategory}
                        >
                            Xóa
                        </button>
                    </div>
                </div>
            </Modal>
        </AdminLayout>
    );
};

export default AdminProducts;
