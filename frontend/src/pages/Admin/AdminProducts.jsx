import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import usePageTitle from '../../hooks/usePageTitle';
import api from '../../config/axiosConfig';
import AdminLayout from '../../components/AdminLayout/AdminLayout';
import DataTable from '../../components/DataTable/DataTable';
import Modal from '../../components/Modal/Modal';
import MultiSelect from '../../components/MultiSelect/MultiSelect';
import ImageUpload from '../../components/ImageUpload/ImageUpload';
import '../../styles/admin.css';

import { getImageUrl } from '../../utils/imageUrl';

const AdminProducts = () => {
    const navigate = useNavigate();
    usePageTitle('Quản lý Sản phẩm');
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
    const [notification, setNotification] = useState({
        isOpen: false,
        message: '',
        type: 'success' // 'success' | 'error'
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
        navigate('/admin/products/new');
    };

    const handleEdit = (product) => {
        if (!product || !product.id) {
            console.error('Invalid product for edit:', product);
            showNotification('Lỗi: Sản phẩm không hợp lệ', 'error');
            return;
        }
        navigate(`/admin/products/edit/${product.id}`);
    };

    const handleDelete = (product) => {
        if (!product || !product.id) {
            console.error('Invalid product for delete:', product);
            showNotification('Lỗi: Sản phẩm không hợp lệ', 'error');
            return;
        }
        setSelectedProduct(product);
        setIsDeleteModalOpen(true);
    };

    const showNotification = (message, type = 'success') => {
        setNotification({
            isOpen: true,
            message,
            type
        });
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
                showNotification('Cập nhật sản phẩm thành công!');
            } else {
                await api.post('/products', data);
                showNotification('Thêm sản phẩm mới thành công!');
            }

            setIsModalOpen(false);
            fetchProducts();
        } catch (error) {
            console.error('Error saving product:', error);
            showNotification('Lỗi khi lưu sản phẩm: ' + (error.response?.data?.message || error.message), 'error');
        }
    };

    const confirmDelete = async () => {
        try {
            await api.delete(`/products/${selectedProduct.id}`);
            setIsDeleteModalOpen(false);
            fetchProducts();
            showNotification('Xóa sản phẩm thành công!');
        } catch (error) {
            console.error('Error deleting product:', error);
            showNotification('Lỗi khi xóa sản phẩm: ' + (error.response?.data?.message || error.message), 'error');
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
        {
            header: 'Ảnh',
            accessor: 'imageUrl',
            render: (item) => (
                <img
                    src={getImageUrl(item.imageUrl)}
                    alt={item.name}
                    style={{ width: '40px', height: '40px', objectFit: 'cover', borderRadius: '4px' }}
                />
            )
        },
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
            header: 'Trọng lượng',
            accessor: 'weight',
            sortable: true,
            render: (item) => (item.weight || 0) + 'g'
        },
        {
            header: 'Nổi bật',
            accessor: 'isFeatured',
            render: (item) => (
                <span className={`badge ${item.isFeatured ? 'badge-success' : 'badge-secondary'}`}>
                    {item.isFeatured ? '⭐ Có' : 'Không'}
                </span>
            )
        },
        {
            header: 'Ngày tạo',
            accessor: 'createdAt',
            sortable: true,
            render: (item) => new Date(item.createdAt).toLocaleString('vi-VN')
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

            {/* Remove product form modal */}

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

            {/* Notification Modal */}
            <Modal
                isOpen={notification.isOpen}
                onClose={() => setNotification({ ...notification, isOpen: false })}
                title={notification.type === 'success' ? 'Thành công' : 'Thông báo lỗi'}
                size="small"
            >
                <div className="notification-content">
                    <div className={`notification-icon ${notification.type}`}>
                        {notification.type === 'success' ? '✅' : '❌'}
                    </div>
                    <p>{notification.message}</p>
                    <div className="form-actions" style={{ justifyContent: 'center', marginTop: '20px' }}>
                        <button
                            className={`btn-${notification.type === 'success' ? 'primary' : 'danger'}`}
                            onClick={() => setNotification({ ...notification, isOpen: false })}
                        >
                            Đóng
                        </button>
                    </div>
                </div>
            </Modal>
        </AdminLayout>
    );
};

export default AdminProducts;
