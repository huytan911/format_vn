import React, { useState, useEffect } from 'react';
import api from '../../config/axiosConfig';
import AdminLayout from '../../components/AdminLayout/AdminLayout';
import DataTable from '../../components/DataTable/DataTable';
import Modal from '../../components/Modal/Modal';


import { getImageUrl } from '../../utils/imageUrl';


import usePageTitle from '../../hooks/usePageTitle';

const AdminCategories = () => {
    usePageTitle('Quản lý Danh mục');
    const [categories, setCategories] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [notification, setNotification] = useState({
        isOpen: false,
        message: '',
        type: 'success' // 'success' | 'error'
    });
    const [formData, setFormData] = useState({
        name: '',
        description: '',

        parentId: ''
    });

    useEffect(() => {
        fetchCategories();
    }, []);

    const fetchCategories = async () => {
        try {
            const response = await api.get('/categories');
            setCategories(response.data);
        } catch (error) {
            console.error('Error fetching categories:', error);
        }
    };

    const handleCreate = () => {
        setSelectedCategory(null);
        setFormData({ name: '', description: '', parentId: '' });
        setIsModalOpen(true);
    };

    const handleEdit = (category) => {
        setSelectedCategory(category);
        setFormData({
            name: category.name,
            description: category.description || '',

            parentId: category.parentId || ''
        });
        setIsModalOpen(true);
    };

    const handleDelete = (category) => {
        setSelectedCategory(category);
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
            const dataToSave = {
                ...formData,
                parentId: formData.parentId === '' ? null : parseInt(formData.parentId)
            };

            if (selectedCategory) {
                await api.put(`/categories/${selectedCategory.id}`, {
                    ...dataToSave,
                    id: selectedCategory.id
                });
                showNotification('Cập nhật danh mục thành công!');
            } else {
                await api.post('/categories', dataToSave);
                showNotification('Thêm danh mục mới thành công!');
            }
            setIsModalOpen(false);
            fetchCategories();
        } catch (error) {
            console.error('Error saving category:', error);
            showNotification('Lỗi khi lưu danh mục: ' + (error.response?.data || error.message), 'error');
        }
    };

    const confirmDelete = async () => {
        try {
            await api.delete(`/categories/${selectedCategory.id}`);
            setIsDeleteModalOpen(false);
            fetchCategories();
            showNotification('Xóa danh mục thành công!');
        } catch (error) {
            console.error('Error deleting category:', error);
            showNotification('Lỗi khi xóa danh mục. Có thể danh mục đang có sản phẩm hoặc danh mục con.', 'error');
        }
    };

    const columns = [

        { header: 'ID', accessor: 'id', sortable: true },
        { header: 'Tên danh mục', accessor: 'name', sortable: true },
        {
            header: 'Danh mục cha',
            accessor: 'parent.name',
            render: (item) => item.parent ? (
                <span className="badge badge-info">{item.parent.name}</span>
            ) : (
                <span className="text-gray">-</span>
            )
        },
        {
            header: 'Ngày tạo',
            accessor: 'createdAt',
            sortable: true,
            render: (item) => new Date(item.createdAt).toLocaleString('vi-VN')
        },
        { header: 'Mô tả', accessor: 'description' },
        {
            header: 'Số sản phẩm',
            accessor: 'productCategories',
            render: (item) => item.productCategories?.length || 0
        }
    ];

    // Filter out the current category and its children (to avoid circular refs)
    // For simplicity, we just filter out the current category for now
    const parentOptions = categories.filter(c => !selectedCategory || c.id !== selectedCategory.id);

    return (
        <AdminLayout>
            <div className="admin-page-header">
                <h1>Quản lý Danh mục</h1>
                <button className="btn-primary" onClick={handleCreate}>
                    + Thêm danh mục mới
                </button>
            </div>

            <DataTable
                columns={columns}
                data={categories}
                onEdit={handleEdit}
                onDelete={handleDelete}
            />

            <Modal
                isOpen={isModalOpen}
                onClose={() => setIsModalOpen(false)}
                title={selectedCategory ? 'Chỉnh sửa danh mục' : 'Thêm danh mục mới'}
                size="large"
            >
                <form onSubmit={handleSubmit} className="admin-form">
                    <div className="form-row">
                        <div className="form-group">
                            <label>Tên danh mục *</label>
                            <input
                                type="text"
                                value={formData.name}
                                onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                                required
                            />
                        </div>

                        <div className="form-group">
                            <label>Danh mục cha</label>
                            <select
                                value={formData.parentId}
                                onChange={(e) => setFormData({ ...formData, parentId: e.target.value })}
                                className="form-control"
                            >
                                <option value="">-- Không có (Danh mục gốc) --</option>
                                {parentOptions.map(cat => (
                                    <option key={cat.id} value={cat.id}>
                                        {cat.name}
                                    </option>
                                ))}
                            </select>
                        </div>
                    </div>

                    <div className="form-group">
                        <label>Mô tả</label>
                        <textarea
                            value={formData.description}
                            onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                            rows="3"
                        />
                    </div>



                    <div className="form-actions">
                        <button type="button" className="btn-secondary" onClick={() => setIsModalOpen(false)}>
                            Hủy
                        </button>
                        <button type="submit" className="btn-primary">
                            {selectedCategory ? 'Cập nhật' : 'Tạo mới'}
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
                    <p>Bạn có chắc chắn muốn xóa danh mục <strong>{selectedCategory?.name}</strong>?</p>
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

export default AdminCategories;
