import React, { useState, useEffect } from 'react';
import axios from 'axios';
import AdminLayout from '../../components/AdminLayout/AdminLayout';
import DataTable from '../../components/DataTable/DataTable';
import Modal from '../../components/Modal/Modal';
import '../../styles/admin.css';

const AdminCategories = () => {
    const [categories, setCategories] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [formData, setFormData] = useState({
        name: '',
        description: '',
        imageUrl: ''
    });

    const API_URL = 'http://localhost:5149/api';

    useEffect(() => {
        fetchCategories();
    }, []);

    const fetchCategories = async () => {
        try {
            const response = await axios.get(`${API_URL}/categories`);
            setCategories(response.data);
        } catch (error) {
            console.error('Error fetching categories:', error);
        }
    };

    const handleCreate = () => {
        setSelectedCategory(null);
        setFormData({ name: '', description: '', imageUrl: '' });
        setIsModalOpen(true);
    };

    const handleEdit = (category) => {
        setSelectedCategory(category);
        setFormData({
            name: category.name,
            description: category.description || '',
            imageUrl: category.imageUrl || ''
        });
        setIsModalOpen(true);
    };

    const handleDelete = (category) => {
        setSelectedCategory(category);
        setIsDeleteModalOpen(true);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            if (selectedCategory) {
                await axios.put(`${API_URL}/categories/${selectedCategory.id}`, {
                    ...formData,
                    id: selectedCategory.id
                });
            } else {
                await axios.post(`${API_URL}/categories`, formData);
            }
            setIsModalOpen(false);
            fetchCategories();
        } catch (error) {
            console.error('Error saving category:', error);
            alert('Lỗi khi lưu danh mục');
        }
    };

    const confirmDelete = async () => {
        try {
            await axios.delete(`${API_URL}/categories/${selectedCategory.id}`);
            setIsDeleteModalOpen(false);
            fetchCategories();
        } catch (error) {
            console.error('Error deleting category:', error);
            alert('Lỗi khi xóa danh mục. Có thể danh mục đang có sản phẩm.');
        }
    };

    const columns = [
        { header: 'ID', accessor: 'id', sortable: true },
        { header: 'Tên danh mục', accessor: 'name', sortable: true },
        { header: 'Mô tả', accessor: 'description' },
        {
            header: 'Số sản phẩm',
            accessor: 'products',
            render: (item) => item.products?.length || 0
        }
    ];

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
            >
                <form onSubmit={handleSubmit} className="admin-form">
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
                        <label>Mô tả</label>
                        <textarea
                            value={formData.description}
                            onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                            rows="3"
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
        </AdminLayout>
    );
};

export default AdminCategories;
