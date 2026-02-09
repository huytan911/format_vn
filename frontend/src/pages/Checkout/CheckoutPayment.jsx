import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';
import { useCart } from '../../contexts/CartContext';
import { useToast } from '../../contexts/ToastContext';
import usePageTitle from '../../hooks/usePageTitle';
import api from '../../config/axiosConfig';
import { FiArrowLeft, FiCheck } from 'react-icons/fi';
import './Checkout.css';

const CheckoutPayment = () => {
    const { user } = useAuth();
    const { cartItems, cartTotal, clearCart, isLoading } = useCart();
    const { showToast } = useToast();
    const navigate = useNavigate();

    usePageTitle('Thanh toán');

    const [shippingInfo, setShippingInfo] = useState(null);
    const [paymentMethod, setPaymentMethod] = useState('COD');
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [orderPlaced, setOrderPlaced] = useState(false);

    const getImageUrl = (path) => {
        if (!path) return '';
        if (path.startsWith('http')) return path;
        return `http://localhost:5149${path}`;
    };

    useEffect(() => {
        const savedShipping = localStorage.getItem('checkout_shipping');
        if (!savedShipping) {
            navigate('/checkout/shipping');
            return;
        }
        setShippingInfo(JSON.parse(savedShipping));

        if (!isLoading && cartItems.length === 0 && !orderPlaced) {
            navigate('/cart');
        }
    }, [navigate, cartItems, orderPlaced, isLoading]);

    const handlePlaceOrder = async () => {
        if (!shippingInfo || !user) return;

        setIsSubmitting(true);
        try {
            const fullAddress = `${shippingInfo.address}, ${shippingInfo.ward}, ${shippingInfo.district}, ${shippingInfo.city}`;

            const orderData = {
                customerId: user.id || 0,
                orderNumber: "",
                orderDate: new Date().toISOString(),
                totalAmount: cartTotal,
                status: "Pending",
                shippingAddress: fullAddress,
                orderItems: cartItems.map(item => ({
                    productId: item.productId,
                    productVariantId: item.productVariantId,
                    quantity: item.quantity,
                    unitPrice: item.price
                }))
            };

            const response = await api.post('/orders', orderData);

            if (response.status === 201 || response.status === 200) {
                setOrderPlaced(true);
                await clearCart();
                localStorage.removeItem('checkout_shipping');
                navigate('/checkout/result', {
                    state: {
                        status: 'success',
                        orderId: response.data.id,
                        orderNumber: response.data.orderNumber
                    }
                });
            }
        } catch (error) {
            console.error('Order creation failed:', error);
            navigate('/checkout/result', {
                state: {
                    status: 'failed',
                    message: error.response?.data?.message || 'Không thể tạo đơn hàng'
                }
            });
        } finally {
            setIsSubmitting(false);
        }
    };

    if (!shippingInfo) return <div className="loading">Đang tải...</div>;

    return (
        <div className="checkout-page">
            <div className="checkout-container">
                <div className="checkout-main">
                    <div className="checkout-steps">
                        <div className="step completed">
                            <Link to="/checkout/shipping" style={{ display: 'flex', alignItems: 'center', color: 'inherit', textDecoration: 'none' }}>
                                <span className="step-number"><FiCheck /></span>
                                Địa chỉ giao hàng
                            </Link>
                        </div>
                        <div className="step-separator"></div>
                        <div className="step active">
                            <span className="step-number">2</span>
                            Thanh toán & Đặt hàng
                        </div>
                    </div>

                    <div className="payment-section">
                        <h2>Xác nhận thông tin</h2>
                        <div className="info-review">
                            <div className="info-label">Giao tới</div>
                            <div className="info-value">{shippingInfo.fullName} ({shippingInfo.phoneNumber})</div>
                            <div className="info-value">
                                {shippingInfo.address}, {shippingInfo.ward}, {shippingInfo.district}, {shippingInfo.city}
                            </div>
                            {shippingInfo.note && (
                                <div className="info-note" style={{ marginTop: '5px', fontStyle: 'italic', color: '#666' }}>
                                    " {shippingInfo.note} "
                                </div>
                            )}
                            <div style={{ marginTop: '10px' }}>
                                <Link to="/checkout/shipping" style={{ fontSize: '13px', textDecoration: 'underline' }}>Chỉnh sửa</Link>
                            </div>
                        </div>

                        <h2>Phương thức thanh toán</h2>
                        <div className="payment-methods">
                            <label className={`payment-method-item ${paymentMethod === 'COD' ? 'selected' : ''}`}>
                                <input
                                    type="radio"
                                    name="payment"
                                    className="payment-radio"
                                    checked={paymentMethod === 'COD'}
                                    onChange={() => setPaymentMethod('COD')}
                                />
                                <div className="payment-details">
                                    <div>Thanh toán khi nhận hàng (COD)</div>
                                    <div style={{ fontSize: '12px', color: '#666', marginTop: '2px' }}>
                                        Bạn sẽ thanh toán tiền mặt cho shipper khi nhận được hàng.
                                    </div>
                                </div>
                            </label>

                            <label className={`payment-method-item ${paymentMethod === 'BANKING' ? 'selected' : ''}`}>
                                <input
                                    type="radio"
                                    name="payment"
                                    className="payment-radio"
                                    checked={paymentMethod === 'BANKING'}
                                    onChange={() => setPaymentMethod('BANKING')}
                                />
                                <div className="payment-details">
                                    <div>Chuyển khoản ngân hàng</div>
                                    <div style={{ fontSize: '12px', color: '#666', marginTop: '2px' }}>
                                        Chuyển khoản qua QR Code hoặc số tài khoản ngân hàng.
                                    </div>
                                </div>
                            </label>
                        </div>

                        <div className="actions-row" style={{ marginTop: '40px' }}>
                            <Link to="/checkout/shipping" className="back-link">
                                <FiArrowLeft /> Quay lại
                            </Link>
                            <button
                                onClick={handlePlaceOrder}
                                className="btn btn-primary"
                                disabled={isSubmitting}
                                style={{ minWidth: '200px' }}
                            >
                                {isSubmitting ? 'Đang xử lý...' : `ĐẶT HÀNG (${new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(cartTotal)})`}
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
        </div>
    );
};

export default CheckoutPayment;
