import React, { useState, useEffect } from 'react';
import axios from 'axios';
import AdminLayout from '../../components/AdminLayout/AdminLayout';
import DataTable from '../../components/DataTable/DataTable';
import Modal from '../../components/Modal/Modal';
import '../../styles/admin.css';

const AdminProducts = () => {
    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
    const [selectedProduct, setSelectedProduct] = useState(null);
    const [formData, setFormData] = useState({
        name: '',
        description: '',
        price: '',
        categoryId: '',
        imageUrl: '',
        stock: '',
        isFeatured: false
    });

    const API_URL = 'http://localhost:5149/api';

    useEffect(() => {
        fetchProducts();
        fetchCategories();
    }, []);

    const fetchProducts = async () => {
        try {
            const response = await axios.get(`${API_URL}/products`);
            setProducts(response.data);
        } catch (error) {
            console.error('Error fetching products:', error);
        }
    };

    const fetchCategories = async () => {
        try {
            const response = await axios.get(`${API_URL}/categories`);
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
            categoryId: '',
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
            categoryId: product.categoryId,
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
                categoryId: parseInt(formData.categoryId),
                stock: parseInt(formData.stock),
                createdAt: selectedProduct ? selectedProduct.createdAt : new Date().toISOString()
            };

            if (selectedProduct) {
                await axios.put(`${API_URL}/products/${selectedProduct.id}`, { ...data, id: selectedProduct.id });
            } else {
                await axios.post(`${API_URL}/products`, data);
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
            await axios.delete(`${API_URL}/products/${selectedProduct.id}`);
            setIsDeleteModalOpen(false);
            fetchProducts();
        } catch (error) {
            console.error('Error deleting product:', error);
            alert('Lỗi khi xóa sản phẩm');
        }
    };

    const columns = [
        { header: 'ID', accessor: 'id', sortable: true },
        { header: 'Tên sản phẩm', accessor: 'name', sortable: true },
        {
            header: 'Danh mục',
            accessor: 'category.name',
            render: (item) => item.category?.name || 'N/A'
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
                            <label>Danh mục *</label>
                            <select
                                value={formData.categoryId}
                                onChange={(e) => setFormData({ ...formData, categoryId: e.target.value })}
                                required
                            >
                                <option value="">Chọn danh mục</option>
                                {categories.map(cat => (
                                    <option key={cat.id} value={cat.id}>{cat.name}</option>
                                ))}
                            </select>
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
        </AdminLayout>
    );
};

export default AdminProducts;
