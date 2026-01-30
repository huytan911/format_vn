import React, { useState, useEffect } from 'react';
import api from '../../config/axiosConfig';
import AdminLayout from '../../components/AdminLayout/AdminLayout';
import DataTable from '../../components/DataTable/DataTable';
import Modal from '../../components/Modal/Modal';
import '../../styles/admin.css';

const AdminOrders = () => {
    const [orders, setOrders] = useState([]);
    const [customers, setCustomers] = useState([]);
    const [products, setProducts] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isViewModalOpen, setIsViewModalOpen] = useState(false);
    const [isDeleteModalOpen, setIsDeleteModalOpen] = useState(false);
    const [selectedOrder, setSelectedOrder] = useState(null);
    const [formData, setFormData] = useState({
        customerId: '',
        status: 'Pending',
        shippingAddress: '',
        orderItems: []
    });

    const statusOptions = ['Pending', 'Processing', 'Shipped', 'Delivered', 'Cancelled'];

    useEffect(() => {
        fetchOrders();
        fetchCustomers();
        fetchProducts();
    }, []);

    const fetchOrders = async () => {
        try {
            const response = await api.get('/orders');
            setOrders(response.data);
        } catch (error) {
            console.error('Error fetching orders:', error);
        }
    };

    const fetchCustomers = async () => {
        try {
            const response = await api.get('/customers');
            setCustomers(response.data);
        } catch (error) {
            console.error('Error fetching customers:', error);
        }
    };

    const fetchProducts = async () => {
        try {
            const response = await api.get('/products');
            setProducts(response.data);
        } catch (error) {
            console.error('Error fetching products:', error);
        }
    };

    const handleView = (order) => {
        setSelectedOrder(order);
        setIsViewModalOpen(true);
    };

    const handleEdit = (order) => {
        setSelectedOrder(order);
        setFormData({
            customerId: order.customerId,
            status: order.status,
            shippingAddress: order.shippingAddress || '',
            orderItems: order.orderItems || []
        });
        setIsModalOpen(true);
    };

    const handleDelete = (order) => {
        setSelectedOrder(order);
        setIsDeleteModalOpen(true);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const totalAmount = formData.orderItems.reduce(
                (sum, item) => sum + (item.quantity * item.unitPrice), 0
            );

            const data = {
                ...formData,
                customerId: parseInt(formData.customerId),
                totalAmount,
                orderNumber: selectedOrder?.orderNumber || ''
            };

            if (selectedOrder) {
                await api.put(`/orders/${selectedOrder.id}`, {
                    ...data,
                    id: selectedOrder.id
                });
            } else {
                await api.post('/orders', data);
            }
            setIsModalOpen(false);
            fetchOrders();
        } catch (error) {
            console.error('Error saving order:', error);
            alert('Lỗi khi lưu đơn hàng');
        }
    };

    const confirmDelete = async () => {
        try {
            await api.delete(`/orders/${selectedOrder.id}`);
            setIsDeleteModalOpen(false);
            fetchOrders();
        } catch (error) {
            console.error('Error deleting order:', error);
            alert('Lỗi khi xóa đơn hàng');
        }
    };

    const getStatusColor = (status) => {
        const colors = {
            'Pending': 'badge-warning',
            'Processing': 'badge-info',
            'Shipped': 'badge-primary',
            'Delivered': 'badge-success',
            'Cancelled': 'badge-danger'
        };
        return colors[status] || 'badge-secondary';
    };

    const columns = [
        { header: 'Mã đơn', accessor: 'orderNumber', sortable: true },
        {
            header: 'Khách hàng',
            accessor: 'customer.name',
            render: (item) => item.customer?.name || 'N/A'
        },
        {
            header: 'Ngày đặt',
            accessor: 'createdAt',
            sortable: true,
            render: (item) => new Date(item.createdAt).toLocaleString('vi-VN')
        },
        {
            header: 'Cập nhật',
            accessor: 'updatedAt',
            sortable: true,
            render: (item) => new Date(item.updatedAt).toLocaleString('vi-VN')
        },
        {
            header: 'Tổng tiền',
            accessor: 'totalAmount',
            sortable: true,
            render: (item) => item.totalAmount.toLocaleString('vi-VN') + 'đ'
        },
        {
            header: 'Trạng thái',
            accessor: 'status',
            sortable: true,
            render: (item) => (
                <span className={`badge ${getStatusColor(item.status)}`}>
                    {item.status}
                </span>
            )
        }
    ];

    return (
        <AdminLayout>
            <div className="admin-page-header">
                <h1>Quản lý Đơn hàng</h1>
                <button className="btn-primary" onClick={() => {
                    setSelectedOrder(null);
                    setFormData({ customerId: '', status: 'Pending', shippingAddress: '', orderItems: [] });
                    setIsModalOpen(true);
                }}>
                    + Tạo đơn hàng mới
                </button>
            </div>

            <DataTable
                columns={columns}
                data={orders}
                onView={handleView}
                onEdit={handleEdit}
                onDelete={handleDelete}
            />

            {/* View Order Modal */}
            <Modal
                isOpen={isViewModalOpen}
                onClose={() => setIsViewModalOpen(false)}
                title="Chi tiết đơn hàng"
                size="large"
            >
                {selectedOrder && (
                    <div className="order-details">
                        <div className="detail-section">
                            <h3>Thông tin đơn hàng</h3>
                            <p><strong>Mã đơn:</strong> {selectedOrder.orderNumber}</p>
                            <p><strong>Ngày đặt:</strong> {new Date(selectedOrder.orderDate).toLocaleString('vi-VN')}</p>
                            <p><strong>Trạng thái:</strong> <span className={`badge ${getStatusColor(selectedOrder.status)}`}>{selectedOrder.status}</span></p>
                        </div>

                        <div className="detail-section">
                            <h3>Thông tin khách hàng</h3>
                            <p><strong>Tên:</strong> {selectedOrder.customer?.name}</p>
                            <p><strong>Email:</strong> {selectedOrder.customer?.email}</p>
                            <p><strong>Điện thoại:</strong> {selectedOrder.customer?.phone}</p>
                            <p><strong>Địa chỉ giao hàng:</strong> {selectedOrder.shippingAddress}</p>
                        </div>

                        <div className="detail-section">
                            <h3>Sản phẩm</h3>
                            <table className="order-items-table">
                                <thead>
                                    <tr>
                                        <th>Sản phẩm</th>
                                        <th>Số lượng</th>
                                        <th>Đơn giá</th>
                                        <th>Thành tiền</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {selectedOrder.orderItems?.map(item => (
                                        <tr key={item.id}>
                                            <td>{item.product?.name}</td>
                                            <td>{item.quantity}</td>
                                            <td>{item.unitPrice.toLocaleString('vi-VN')}đ</td>
                                            <td>{(item.quantity * item.unitPrice).toLocaleString('vi-VN')}đ</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                            <div className="order-total">
                                <strong>Tổng cộng: {selectedOrder.totalAmount.toLocaleString('vi-VN')}đ</strong>
                            </div>
                        </div>
                    </div>
                )}
            </Modal>

            {/* Edit Order Modal */}
            <Modal
                isOpen={isModalOpen}
                onClose={() => setIsModalOpen(false)}
                title={selectedOrder ? 'Chỉnh sửa đơn hàng' : 'Tạo đơn hàng mới'}
                size="large"
            >
                <form onSubmit={handleSubmit} className="admin-form">
                    <div className="form-row">
                        <div className="form-group">
                            <label>Khách hàng *</label>
                            <select
                                value={formData.customerId}
                                onChange={(e) => setFormData({ ...formData, customerId: e.target.value })}
                                required
                            >
                                <option value="">Chọn khách hàng</option>
                                {customers.map(customer => (
                                    <option key={customer.id} value={customer.id}>
                                        {customer.name} ({customer.email})
                                    </option>
                                ))}
                            </select>
                        </div>

                        <div className="form-group">
                            <label>Trạng thái *</label>
                            <select
                                value={formData.status}
                                onChange={(e) => setFormData({ ...formData, status: e.target.value })}
                                required
                            >
                                {statusOptions.map(status => (
                                    <option key={status} value={status}>{status}</option>
                                ))}
                            </select>
                        </div>
                    </div>

                    <div className="form-group">
                        <label>Địa chỉ giao hàng</label>
                        <textarea
                            value={formData.shippingAddress}
                            onChange={(e) => setFormData({ ...formData, shippingAddress: e.target.value })}
                            rows="3"
                        />
                    </div>

                    <div className="form-actions">
                        <button type="button" className="btn-secondary" onClick={() => setIsModalOpen(false)}>
                            Hủy
                        </button>
                        <button type="submit" className="btn-primary">
                            {selectedOrder ? 'Cập nhật' : 'Tạo mới'}
                        </button>
                    </div>
                </form>
            </Modal>

            {/* Delete Confirmation Modal */}
            <Modal
                isOpen={isDeleteModalOpen}
                onClose={() => setIsDeleteModalOpen(false)}
                title="Xác nhận xóa"
                size="small"
            >
                <div className="delete-confirmation">
                    <p>Bạn có chắc chắn muốn xóa đơn hàng <strong>{selectedOrder?.orderNumber}</strong>?</p>
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

export default AdminOrders;
