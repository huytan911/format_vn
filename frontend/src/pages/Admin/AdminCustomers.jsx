import React, { useState, useEffect } from 'react';
import api from '../../config/axiosConfig';
import AdminLayout from '../../components/AdminLayout/AdminLayout';
import DataTable from '../../components/DataTable/DataTable';
import Modal from '../../components/Modal/Modal';
import '../../styles/admin.css';

const AdminCustomers = () => {
    const [customers, setCustomers] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
    const [selectedCustomer, setSelectedCustomer] = useState(null);
    const [formData, setFormData] = useState({
        name: '',
        email: '',
        phone: '',
        address: ''
    });

    useEffect(() => {
        fetchCustomers();
    }, []);

    const fetchCustomers = async () => {
        try {
            const response = await api.get('/customers');
            setCustomers(response.data);
        } catch (error) {
            console.error('Error fetching customers:', error);
        }
    };

    const handleCreate = () => {
        setSelectedCustomer(null);
        setFormData({ name: '', email: '', phone: '', address: '' });
        setIsModalOpen(true);
    };

    const handleEdit = (customer) => {
        setSelectedCustomer(customer);
        setFormData({
            name: customer.name,
            email: customer.email,
            phone: customer.phone || '',
            address: customer.address || ''
        });
        setIsModalOpen(true);
    };

    const handleDelete = (customer) => {
        setSelectedCustomer(customer);
        setIsDeleteModalOpen(true);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const data = {
                ...formData
            };

            if (selectedCustomer) {
                await api.put(`/customers/${selectedCustomer.id}`, {
                    ...data,
                    id: selectedCustomer.id
                });
            } else {
                await api.post('/customers', data);
            }
            setIsModalOpen(false);
            fetchCustomers();
        } catch (error) {
            console.error('Error saving customer:', error);
            alert('Lỗi khi lưu khách hàng');
        }
    };

    const confirmDelete = async () => {
        try {
            await api.delete(`/customers/${selectedCustomer.id}`);
            setIsDeleteModalOpen(false);
            fetchCustomers();
        } catch (error) {
            console.error('Error deleting customer:', error);
            alert('Lỗi khi xóa khách hàng');
        }
    };

    const columns = [
        { header: 'ID', accessor: 'id', sortable: true },
        { header: 'Tên khách hàng', accessor: 'name', sortable: true },
        { header: 'Email', accessor: 'email', sortable: true },
        { header: 'Số điện thoại', accessor: 'phone' },
        { header: 'Địa chỉ', accessor: 'address' },
        {
            header: 'Ngày tạo',
            accessor: 'createdAt',
            sortable: true,
            render: (item) => new Date(item.createdAt).toLocaleString('vi-VN')
        },
        {
            header: 'Số đơn hàng',
            accessor: 'orders',
            render: (item) => item.orders?.length || 0
        }
    ];

    return (
        <AdminLayout>
            <div className="admin-page-header">
                <h1>Quản lý Khách hàng</h1>
                <button className="btn-primary" onClick={handleCreate}>
                    + Thêm khách hàng mới
                </button>
            </div>

            <DataTable
                columns={columns}
                data={customers}
                onEdit={handleEdit}
                onDelete={handleDelete}
            />

            <Modal
                isOpen={isModalOpen}
                onClose={() => setIsModalOpen(false)}
                title={selectedCustomer ? 'Chỉnh sửa khách hàng' : 'Thêm khách hàng mới'}
            >
                <form onSubmit={handleSubmit} className="admin-form">
                    <div className="form-group">
                        <label>Tên khách hàng *</label>
                        <input
                            type="text"
                            value={formData.name}
                            onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label>Email *</label>
                        <input
                            type="email"
                            value={formData.email}
                            onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label>Số điện thoại</label>
                        <input
                            type="tel"
                            value={formData.phone}
                            onChange={(e) => setFormData({ ...formData, phone: e.target.value })}
                            placeholder="0901234567"
                        />
                    </div>

                    <div className="form-group">
                        <label>Địa chỉ</label>
                        <textarea
                            value={formData.address}
                            onChange={(e) => setFormData({ ...formData, address: e.target.value })}
                            rows="3"
                            placeholder="Địa chỉ đầy đủ"
                        />
                    </div>

                    <div className="form-actions">
                        <button type="button" className="btn-secondary" onClick={() => setIsModalOpen(false)}>
                            Hủy
                        </button>
                        <button type="submit" className="btn-primary">
                            {selectedCustomer ? 'Cập nhật' : 'Tạo mới'}
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
                    <p>Bạn có chắc chắn muốn xóa khách hàng <strong>{selectedCustomer?.name}</strong>?</p>
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

export default AdminCustomers;
