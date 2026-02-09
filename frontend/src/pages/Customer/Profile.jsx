import React, { useState, useEffect } from 'react';
import api from '../../config/axiosConfig';
import { useAuth } from '../../contexts/AuthContext';
import { useWishlist } from '../../contexts/WishlistContext';
import { useCart } from '../../contexts/CartContext';
import { getImageUrl } from '../../utils/imageUrl';
import { FiTrash2, FiShoppingBag, FiPlus, FiUser, FiPackage, FiHeart, FiMapPin, FiMail, FiLogOut, FiPhone } from 'react-icons/fi';
import './Profile.css';

const Profile = () => {
    const { user, logout } = useAuth();
    const { wishlistItems, removeFromWishlist } = useWishlist();
    const { addToCart } = useCart();
    const [activeTab, setActiveTab] = useState('account');
    const [formData, setFormData] = useState({
        name: '',
        email: '',
        phone: '',
        address: '',
        isSubscribed: false
    });
    const [orders, setOrders] = useState([]);
    const [addresses, setAddresses] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [isSaving, setIsSaving] = useState(false);
    const [message, setMessage] = useState({ text: '', type: '' });

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        try {
            const [profileRes, ordersRes, addressesRes] = await Promise.all([
                api.get('/auth/customer/profile'),
                api.get('/orders/my'),
                api.get('/addresses')
            ]);
            setFormData(profileRes.data);
            setOrders(ordersRes.data);
            setAddresses(addressesRes.data);
        } catch (error) {
            console.error('Error fetching data:', error);
            setMessage({ text: 'Không thể tải thông tin hồ sơ', type: 'error' });
        } finally {
            setIsLoading(false);
        }
    };

    const handleAddToCart = (item) => {
        addToCart({
            id: item.productId,
            name: item.productName,
            price: item.price,
            imageUrl: item.imageUrl
        });
        removeFromWishlist(item.productId);
        setMessage({ text: `Đã thêm ${item.productName} vào giỏ hàng`, type: 'success' });
        setTimeout(() => setMessage({ text: '', type: '' }), 3000);
    };

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setMessage({ text: '', type: '' });
        setIsSaving(true);

        try {
            await api.put('/auth/customer/profile', formData);
            setMessage({ text: 'Cập nhật hồ sơ thành công!', type: 'success' });
        } catch (error) {
            console.error('Error updating profile:', error);
            setMessage({ text: 'Lỗi khi cập nhật hồ sơ', type: 'error' });
        } finally {
            setIsSaving(false);
        }
    };

    const getStatusBadgeClass = (status) => {
        switch (status?.toLowerCase()) {
            case 'pending': return 'badge-pending';
            case 'processing': return 'badge-processing';
            case 'shipped': return 'badge-shipped';
            case 'delivered': return 'badge-delivered';
            case 'cancelled': return 'badge-cancelled';
            default: return 'badge-default';
        }
    };

    const formatDate = (dateString) => {
        return new Date(dateString).toLocaleDateString('vi-VN', {
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        });
    };

    if (isLoading) return (
        <div className="profile-container">
            <div className="loading">Đang tải hồ sơ...</div>
        </div>
    );

    const renderTabContent = () => {
        switch (activeTab) {
            case 'account':
                return (
                    <div className="tab-pane">
                        <div className="profile-header">
                            <h1>Thông tin hồ sơ</h1>
                            <p>Tùy chỉnh thông tin cá nhân của bạn</p>
                        </div>
                        {message.text && message.type !== 'success' && <div className={`message ${message.type}`}>{message.text}</div>}
                        {message.text && message.type === 'success' && activeTab === 'account' && <div className={`message ${message.type}`}>{message.text}</div>}
                        <form onSubmit={handleSubmit} className="profile-form">
                            <div className="form-group">
                                <label>Họ và tên</label>
                                <input type="text" name="name" value={formData.name} onChange={handleChange} required placeholder="Nhập họ và tên..." />
                            </div>
                            <div className="form-group">
                                <label>Email (Xác thực)</label>
                                <input type="email" value={formData.email} disabled />
                            </div>
                            <div className="form-group">
                                <label>Số điện thoại liên hệ</label>
                                <input type="tel" name="phone" value={formData.phone} onChange={handleChange} placeholder="Nhập số điện thoại..." />
                            </div>
                            <div className="form-group">
                                <label>Địa chỉ thường trú</label>
                                <textarea name="address" value={formData.address} onChange={handleChange} rows="3" placeholder="Nhập địa chỉ của bạn..." />
                            </div>
                            <div className="profile-actions">
                                <button type="submit" className="btn-save" disabled={isSaving}>
                                    {isSaving ? 'ĐANG LƯU...' : 'LƯU THÔNG TIN'}
                                </button>
                            </div>
                        </form>
                    </div>
                );
            case 'orders':
                return (
                    <div className="tab-pane">
                        <div className="profile-header">
                            <h1>Lịch sử giao dịch</h1>
                            <p>Theo dõi các đơn hàng bạn đã thực hiện</p>
                        </div>
                        <div className="orders-list">
                            {orders.length === 0 ? (
                                <div className="placeholder-text"><p>Bạn chưa có giao dịch nào.</p></div>
                            ) : (
                                <div className="table-responsive">
                                    <table className="orders-table">
                                        <thead>
                                            <tr>
                                                <th>Mã vận đơn</th>
                                                <th>Ngày giao dịch</th>
                                                <th>Tổng giá trị</th>
                                                <th>Tình trạng</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {orders.map(order => (
                                                <tr key={order.id}>
                                                    <td className="order-number">#{order.orderNumber}</td>
                                                    <td>{formatDate(order.orderDate)}</td>
                                                    <td className="order-amount">{order.totalAmount?.toLocaleString('vi-VN')}đ</td>
                                                    <td><span className={`badge ${getStatusBadgeClass(order.status)}`}>{order.status}</span></td>
                                                </tr>
                                            ))}
                                        </tbody>
                                    </table>
                                </div>
                            )}
                        </div>
                    </div>
                );
            case 'wishlist':
                return (
                    <div className="tab-pane">
                        <div className="profile-header">
                            <h1>Bộ sưu tập yêu thích</h1>
                            <p>Những sản phẩm bạn đã tinh tuyển</p>
                        </div>
                        <div className="wishlist-tab-content">
                            {wishlistItems.length === 0 ? (
                                <div className="placeholder-text"><p>Bộ sưu tập của bạn đang trống.</p></div>
                            ) : (
                                <div className="wishlist-mini-grid">
                                    {wishlistItems.map(item => (
                                        <div key={item.id} className="wishlist-mini-item">
                                            <img src={getImageUrl(item.imageUrl)} alt={item.productName} />
                                            <div className="item-details">
                                                <h4>{item.productName}</h4>
                                                <p>{item.price?.toLocaleString('vi-VN')}đ</p>
                                                <div className="item-actions">
                                                    <button onClick={() => handleAddToCart(item)} className="btn-icon-label"><FiShoppingBag /> THÊM VÀO GIỎ</button>
                                                    <button onClick={() => removeFromWishlist(item.productId)} className="btn-remove-mini"><FiTrash2 /></button>
                                                </div>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                        </div>
                    </div>
                );
            case 'addresses':
                return (
                    <div className="tab-pane">
                        <div className="profile-header">
                            <div className="header-flex">
                                <div>
                                    <h1>Sổ địa chỉ</h1>
                                    <p>Quản lý các điểm giao nhận hàng</p>
                                </div>
                                <button className="btn-add-address"><FiPlus /> THÊM ĐỊA CHỈ MỚI</button>
                            </div>
                        </div>
                        <div className="addresses-list">
                            {addresses.length === 0 ? (
                                <div className="placeholder-text"><p>Bạn chưa lưu địa chỉ nào.</p></div>
                            ) : (
                                <div className="address-cards">
                                    {addresses.map(addr => (
                                        <div key={addr.id} className={`address-card ${addr.isDefault ? 'default' : ''}`}>
                                            <div className="address-card-header">
                                                <div className="card-title-group">
                                                    <h4>{addr.receiverName}</h4>
                                                    {addr.isDefault && <span className="badge default-badge">MẶC ĐỊNH</span>}
                                                </div>
                                                <div className="card-actions">
                                                    <button className="btn-edit-mini">CHỈNH SỬA</button>
                                                    <button className="btn-delete-mini">LOẠI BỎ</button>
                                                </div>
                                            </div>
                                            <div className="address-card-body">
                                                <p><FiPhone className="body-icon" /> <span>{addr.phoneNumber}</span></p>
                                                <p><FiMapPin className="body-icon" /> <span>{addr.addressLine}, {addr.ward}, {addr.district}, {addr.city}</span></p>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            )}
                        </div>
                    </div>
                );
            case 'newsletter':
                return (
                    <div className="tab-pane">
                        <div className="profile-header">
                            <h1>Đăng ký bản tin</h1>
                            <p>Cập nhật xu hướng và ưu đãi độc quyền</p>
                        </div>
                        <div className="newsletter-tab-card">
                            <div className="newsletter-option">
                                <input
                                    type="checkbox"
                                    id="newsletter-check"
                                    checked={formData.isSubscribed}
                                    onChange={(e) => setFormData({ ...formData, isSubscribed: e.target.checked })}
                                />
                                <label htmlFor="newsletter-check">
                                    <h3 style={{ margin: 0 }}>Nhận thông báo qua Email</h3>
                                    <p style={{ marginTop: '8px' }}>Đăng ký để nhận thông tin về bộ sưu tập mới, sự kiện và các chương trình ưu đãi đặc biệt dành riêng cho bạn từ FORMAT.</p>
                                </label>
                            </div>
                            <button
                                onClick={handleSubmit}
                                className="btn-save"
                                style={{ marginTop: '30px' }}
                                disabled={isSaving}
                            >
                                {isSaving ? 'ĐANG CẬP NHẬT...' : 'CẬP NHẬT THIẾT LẬP'}
                            </button>
                            {message.text && activeTab === 'newsletter' && <div className={`message ${message.type}`} style={{ marginTop: '20px' }}>{message.text}</div>}
                        </div>
                    </div>
                );
            default:
                return null;
        }
    };

    return (
        <div className="profile-container">
            <div className="profile-layout">
                <aside className="profile-sidebar">
                    <div className="user-summary">
                        <div className="user-avatar">{user.name.charAt(0)}</div>
                        <div className="user-info">
                            <h3>{user.name}</h3>
                            <p>{user.email}</p>
                        </div>
                    </div>
                    <nav className="profile-nav">
                        <button className={activeTab === 'account' ? 'active' : ''} onClick={() => setActiveTab('account')}>
                            <FiUser /> Hồ sơ cá nhân
                        </button>
                        <button className={activeTab === 'orders' ? 'active' : ''} onClick={() => setActiveTab('orders')}>
                            <FiPackage /> Lịch sử mua hàng
                        </button>
                        <button className={activeTab === 'wishlist' ? 'active' : ''} onClick={() => setActiveTab('wishlist')}>
                            <FiHeart /> Sản phẩm yêu thích
                        </button>
                        <button className={activeTab === 'addresses' ? 'active' : ''} onClick={() => setActiveTab('addresses')}>
                            <FiMapPin /> Sổ địa chỉ
                        </button>
                        <button className={activeTab === 'newsletter' ? 'active' : ''} onClick={() => setActiveTab('newsletter')}>
                            <FiMail /> Đăng ký bản tin
                        </button>
                        <button className="logout-nav-btn" onClick={logout}>
                            <FiLogOut /> Đăng xuất
                        </button>
                    </nav>
                </aside>
                <main className="profile-main">
                    {renderTabContent()}
                </main>
            </div>
        </div>
    );
};

export default Profile;
