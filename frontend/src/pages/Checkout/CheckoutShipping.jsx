import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios'; // For external location API
import { useAuth } from '../../contexts/AuthContext';
import { useCart } from '../../contexts/CartContext';
import { useToast } from '../../contexts/ToastContext';
import { FiArrowLeft, FiChevronRight, FiPlus, FiMapPin, FiTrash2 } from 'react-icons/fi';
import Modal from '../../components/Modal/Modal';
import api from '../../config/axiosConfig'; // Backend API
import './Checkout.css';

const CheckoutShipping = () => {
    const { user } = useAuth();
    const { cartItems, cartTotal } = useCart();
    const { showToast } = useToast();
    const navigate = useNavigate();

    const [addresses, setAddresses] = useState([]);
    const [selectedAddressId, setSelectedAddressId] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isLoading, setIsLoading] = useState(false);

    // Location Data State
    const [provinces, setProvinces] = useState([]);
    const [districts, setDistricts] = useState([]);
    const [wards, setWards] = useState([]);
    const [locationIds, setLocationIds] = useState({
        provinceId: '',
        districtId: '',
        wardId: ''
    });

    // New Address Form State
    const [newAddress, setNewAddress] = useState({
        receiverName: user?.fullName || '',
        phoneNumber: user?.phoneNumber || '',
        addressLine: '',
        city: '',
        district: '',
        ward: '',
        note: '',
        isDefault: false
    });

    // Load addresses from backend
    useEffect(() => {
        fetchAddresses();
    }, []);

    // Load Provinces on mount
    useEffect(() => {
        const fetchProvinces = async () => {
            try {
                const response = await axios.get('https://esgoo.net/api-tinhthanh/1/0.htm');
                if (response.data.error === 0) {
                    setProvinces(response.data.data);
                }
            } catch (error) {
                console.error('Error fetching provinces:', error);
            }
        };
        fetchProvinces();
    }, []);

    // Fetch Districts when Province changes
    useEffect(() => {
        if (locationIds.provinceId) {
            const fetchDistricts = async () => {
                try {
                    const response = await axios.get(`https://esgoo.net/api-tinhthanh/2/${locationIds.provinceId}.htm`);
                    if (response.data.error === 0) {
                        setDistricts(response.data.data);
                        setWards([]); // Clear wards
                    }
                } catch (error) {
                    console.error('Error fetching districts:', error);
                }
            };
            fetchDistricts();
        } else {
            setDistricts([]);
            setWards([]);
        }
    }, [locationIds.provinceId]);

    // Fetch Wards when District changes
    useEffect(() => {
        if (locationIds.districtId) {
            const fetchWards = async () => {
                try {
                    const response = await axios.get(`https://esgoo.net/api-tinhthanh/3/${locationIds.districtId}.htm`);
                    if (response.data.error === 0) {
                        setWards(response.data.data);
                    }
                } catch (error) {
                    console.error('Error fetching wards:', error);
                }
            };
            fetchWards();
        } else {
            setWards([]);
        }
    }, [locationIds.districtId]);

    const fetchAddresses = async () => {
        setIsLoading(true);
        try {
            const response = await api.get('/addresses');
            setAddresses(response.data);

            if (response.data.length > 0) {
                const defaultAddr = response.data.find(a => a.isDefault) || response.data[0];
                setSelectedAddressId(defaultAddr.id);
            } else {
                setIsModalOpen(true);
            }
        } catch (error) {
            console.error('Error fetching addresses:', error);
            // Fallback to empty if fails
        } finally {
            setIsLoading(false);
        }
    };

    // Check cart
    useEffect(() => {
        if (cartItems.length === 0) {
            navigate('/cart');
        }
    }, [cartItems, navigate]);

    const handleAddressChange = (e) => {
        const { name, value, type, checked } = e.target;
        setNewAddress(prev => ({
            ...prev,
            [name]: type === 'checkbox' ? checked : value
        }));
    };

    const handleLocationChange = (e, type) => {
        const value = e.target.value;
        const name = e.target.options[e.target.selectedIndex].text;

        if (type === 'province') {
            setLocationIds(prev => ({ ...prev, provinceId: value, districtId: '', wardId: '' }));
            setNewAddress(prev => ({ ...prev, city: name, district: '', ward: '' }));
        } else if (type === 'district') {
            setLocationIds(prev => ({ ...prev, districtId: value, wardId: '' }));
            setNewAddress(prev => ({ ...prev, district: name, ward: '' }));
        } else if (type === 'ward') {
            setLocationIds(prev => ({ ...prev, wardId: value }));
            setNewAddress(prev => ({ ...prev, ward: name }));
        }
    };

    const handleSaveAddress = async (e) => {
        e.preventDefault();
        try {
            const response = await api.post('/addresses', newAddress);
            setAddresses(prev => {
                // If new one is default, uncheck others. But simpler to just refetch or rely on API response order.
                // For optimistic UI:
                const created = response.data;
                const updated = prev.map(a => created.isDefault ? { ...a, isDefault: false } : a);
                updated.push(created);
                return updated;
            });

            setSelectedAddressId(response.data.id);
            setIsModalOpen(false);
            showToast('Đã thêm địa chỉ mới');

            // Reset form
            setNewAddress({
                receiverName: user?.fullName || '',
                phoneNumber: user?.phoneNumber || '',
                addressLine: '',
                city: '',
                district: '',
                ward: '',
                note: '',
                isDefault: false
            });
            setLocationIds({ provinceId: '', districtId: '', wardId: '' });

            // Re-fetch to be sure of order and default state
            fetchAddresses();

        } catch (error) {
            console.error('Error saving address:', error);
            showToast('Không thể lưu địa chỉ', 'error');
        }
    };

    const handleDeleteAddress = async (e, id) => {
        e.stopPropagation(); // Prevent selection when clicking delete
        if (!window.confirm('Bạn có chắc muốn xóa địa chỉ này?')) return;

        try {
            await api.delete(`/addresses/${id}`);
            setAddresses(prev => prev.filter(a => a.id !== id));
            if (selectedAddressId === id) setSelectedAddressId(null);
            showToast('Đã xóa địa chỉ');
        } catch (error) {
            console.error('Error deleting address:', error);
            showToast('Không thể xóa địa chỉ', 'error');
        }
    };

    const handleContinue = () => {
        if (!selectedAddressId) {
            if (addresses.length === 0) {
                setIsModalOpen(true);
                showToast('Vui lòng thêm địa chỉ giao hàng để tiếp tục', 'info');
            } else {
                showToast('Vui lòng chọn địa chỉ giao hàng', 'warning');
            }
            return;
        }

        const selected = addresses.find(a => a.id === selectedAddressId);
        if (selected) {
            const shippingInfo = {
                fullName: selected.receiverName,
                phoneNumber: selected.phoneNumber,
                address: selected.addressLine,
                city: selected.city,
                district: selected.district,
                ward: selected.ward,
                note: selected.note
            };

            localStorage.setItem('checkout_shipping', JSON.stringify(shippingInfo));
            navigate('/checkout/payment');
        }
    };

    const getImageUrl = (path) => {
        if (!path) return '';
        if (path.startsWith('http')) return path;
        return `http://localhost:5149${path}`;
    };

    if (isLoading && addresses.length === 0) return <div className="checkout-page"><div className="container">Đang tải...</div></div>;

    return (
        <div className="checkout-page">
            <div className="checkout-container">
                <div className="checkout-main">
                    <div className="checkout-steps">
                        <div className="step active">
                            <span className="step-number">1</span>
                            Địa chỉ giao hàng
                        </div>
                        <div className="step-separator"></div>
                        <div className="step">
                            <span className="step-number">2</span>
                            Thanh toán & Đặt hàng
                        </div>
                    </div>

                    <div className="shipping-selection">
                        <div className="section-header" style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '20px' }}>
                            <h2 style={{ margin: 0 }}>Chọn địa chỉ nhận hàng</h2>
                            <button className="btn btn-outline btn-sm" onClick={() => setIsModalOpen(true)}>
                                <FiPlus /> Thêm địa chỉ mới
                            </button>
                        </div>

                        {addresses.length === 0 ? (
                            <div className="empty-address-state" style={{ textAlign: 'center', padding: '40px', background: 'white', borderRadius: '8px' }}>
                                <p>Bạn chưa có địa chỉ nhận hàng nào.</p>
                                <button className="btn btn-primary" onClick={() => setIsModalOpen(true)}>
                                    Thêm địa chỉ giao hàng
                                </button>
                            </div>
                        ) : (
                            <div className="address-list" style={{ display: 'flex', flexDirection: 'column', gap: '15px' }}>
                                {addresses.map(addr => (
                                    <label key={addr.id} className={`address-item ${selectedAddressId === addr.id ? 'selected' : ''}`}
                                        style={{
                                            display: 'flex',
                                            padding: '15px',
                                            border: `1px solid ${selectedAddressId === addr.id ? '#000' : '#ddd'}`,
                                            borderRadius: '8px',
                                            cursor: 'pointer',
                                            background: 'white',
                                            position: 'relative'
                                        }}
                                    >
                                        <div style={{ marginRight: '15px', paddingTop: '2px' }}>
                                            <input
                                                type="radio"
                                                name="shipping_address"
                                                checked={selectedAddressId === addr.id}
                                                onChange={() => setSelectedAddressId(addr.id)}
                                            />
                                        </div>
                                        <div style={{ flex: 1 }}>
                                            <div style={{ fontWeight: '600', marginBottom: '4px' }}>
                                                {addr.receiverName} <span style={{ fontWeight: '400', color: '#666', marginLeft: '5px' }}>| {addr.phoneNumber}</span>
                                            </div>
                                            <div style={{ color: '#333' }}>
                                                {addr.addressLine}
                                            </div>
                                            <div style={{ color: '#666', fontSize: '13px' }}>
                                                {addr.ward}, {addr.district}, {addr.city}
                                            </div>
                                            {addr.isDefault && <span style={{ fontSize: '11px', color: '#28a745', border: '1px solid #28a745', padding: '1px 4px', borderRadius: '3px', marginTop: '5px', display: 'inline-block' }}>Mặc định</span>}
                                        </div>
                                        <button
                                            onClick={(e) => handleDeleteAddress(e, addr.id)}
                                            style={{ background: 'none', border: 'none', color: '#999', cursor: 'pointer', padding: '5px' }}
                                            title="Xóa địa chỉ"
                                        >
                                            <FiTrash2 />
                                        </button>
                                    </label>
                                ))}
                            </div>
                        )}

                        <div className="actions-row">
                            <Link to="/cart" className="back-link">
                                <FiArrowLeft /> Quay lại giỏ hàng
                            </Link>
                            <button
                                onClick={handleContinue}
                                className="btn btn-primary"
                            >
                                Tiếp tục đến thanh toán <FiChevronRight />
                            </button>
                        </div>
                    </div>
                </div>

                <div className="checkout-sidebar">
                    <div className="order-summary-card">
                        <h3>Đơn hàng ({cartItems.reduce((acc, item) => acc + item.quantity, 0)} sản phẩm)</h3>
                        <div className="summary-items">
                            {cartItems.map(item => (
                                <div key={item.id} className="summary-item">
                                    <img src={getImageUrl(item.imageUrl)} alt={item.productName} className="summary-item-image" />
                                    <div className="summary-item-info">
                                        <span className="summary-item-title">{item.productName}</span>
                                        {item.variantName && <div className="summary-item-variant">{item.variantName}</div>}
                                        <div className="summary-item-qty">x{item.quantity}</div>
                                    </div>
                                    <div className="summary-item-price">
                                        {new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(item.price * item.quantity)}
                                    </div>
                                </div>
                            ))}
                        </div>
                        <div className="summary-totals">
                            <div className="total-row">
                                <span>Tạm tính</span>
                                <span>{new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(cartTotal)}</span>
                            </div>
                            <div className="total-row">
                                <span>Phí vận chuyển</span>
                                <span>Miễn phí</span>
                            </div>
                            <div className="total-row final">
                                <span>Tổng cộng</span>
                                <span>{new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(cartTotal)}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            {/* Add Address Modal */}
            <Modal
                isOpen={isModalOpen}
                onClose={() => setIsModalOpen(false)}
                title="Thêm địa chỉ mới"
            >
                <form onSubmit={handleSaveAddress} className="add-address-form">
                    <div className="form-group">
                        <label>Họ và tên</label>
                        <input
                            type="text"
                            className="form-control"
                            name="receiverName"
                            value={newAddress.receiverName}
                            onChange={handleAddressChange}
                            required
                            placeholder="Nhập họ và tên người nhận"
                        />
                    </div>

                    <div className="form-group">
                        <label>Số điện thoại</label>
                        <input
                            type="tel"
                            className="form-control"
                            name="phoneNumber"
                            value={newAddress.phoneNumber}
                            onChange={handleAddressChange}
                            required
                            placeholder="Nhập số điện thoại"
                        />
                    </div>

                    <div className="form-row" style={{ display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: '10px' }}>
                        <div className="form-group">
                            <label>Tỉnh / Thành phố</label>
                            <select
                                className="form-control"
                                value={locationIds.provinceId}
                                onChange={(e) => handleLocationChange(e, 'province')}
                                required
                            >
                                <option value="">Chọn Tỉnh/Thành</option>
                                {provinces.map(p => (
                                    <option key={p.id} value={p.id}>{p.full_name}</option>
                                ))}
                            </select>
                        </div>
                        <div className="form-group">
                            <label>Quận / Huyện</label>
                            <select
                                className="form-control"
                                value={locationIds.districtId}
                                onChange={(e) => handleLocationChange(e, 'district')}
                                required
                                disabled={!locationIds.provinceId}
                            >
                                <option value="">Chọn Quận/Huyện</option>
                                {districts.map(d => (
                                    <option key={d.id} value={d.id}>{d.full_name}</option>
                                ))}
                            </select>
                        </div>
                        <div className="form-group">
                            <label>Phường / Xã</label>
                            <select
                                className="form-control"
                                value={locationIds.wardId}
                                onChange={(e) => handleLocationChange(e, 'ward')}
                                required
                                disabled={!locationIds.districtId}
                            >
                                <option value="">Chọn Phường/Xã</option>
                                {wards.map(w => (
                                    <option key={w.id} value={w.id}>{w.full_name}</option>
                                ))}
                            </select>
                        </div>
                    </div>

                    <div className="form-group">
                        <label>Địa chỉ cụ thể</label>
                        <input
                            type="text"
                            className="form-control"
                            name="addressLine"
                            value={newAddress.addressLine}
                            onChange={handleAddressChange}
                            required
                            placeholder="Số nhà, tên đường..."
                        />
                    </div>

                    <div className="form-group">
                        <label>Ghi chú (Tùy chọn)</label>
                        <textarea
                            className="form-control"
                            name="note"
                            value={newAddress.note}
                            onChange={handleAddressChange}
                            rows="2"
                        ></textarea>
                    </div>

                    <div className="form-group">
                        <label style={{ display: 'flex', alignItems: 'center', gap: '8px', fontWeight: 'normal' }}>
                            <input
                                type="checkbox"
                                name="isDefault"
                                checked={newAddress.isDefault}
                                onChange={handleAddressChange}
                            />
                            Đặt làm địa chỉ mặc định
                        </label>
                    </div>

                    <div style={{ display: 'flex', justifyContent: 'flex-end', gap: '10px', marginTop: '20px' }}>
                        <button type="button" className="btn btn-outline" onClick={() => setIsModalOpen(false)}>
                            Hủy
                        </button>
                        <button type="submit" className="btn btn-primary">
                            Lưu địa chỉ
                        </button>
                    </div>
                </form>
            </Modal>
        </div>
    );
};

export default CheckoutShipping;
