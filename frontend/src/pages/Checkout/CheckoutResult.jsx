
import React from 'react';
import { useLocation, Link, useNavigate } from 'react-router-dom';
import { FiCheckCircle, FiXCircle, FiHome, FiArrowRight } from 'react-icons/fi';
import usePageTitle from '../../hooks/usePageTitle';
import './Checkout.css'; // Re-use existing styles or add specific ones

const CheckoutResult = () => {
    const location = useLocation();
    const navigate = useNavigate();
    const { status, orderId, orderNumber, message, success } = location.state || {}; // Expect state: { status: 'success' | 'failed', success: boolean, ... }

    usePageTitle(success ? 'Đặt hàng thành công' : 'Kết quả đặt hàng');

    // Fallback if accessed directly without state
    if (!status && success === undefined) { // Check both status and success for fallback
        return (
            <div className="checkout-page">
                <div className="container" style={{ textAlign: 'center', padding: '100px 20px' }}>
                    <p>Trang không tồn tại hoặc đã hết hạn.</p>
                    <Link to="/" className="btn btn-primary">Về trang chủ</Link>
                </div>
            </div>
        );
    }

    const isSuccess = status === 'success';

    return (
        <div className="checkout-page">
            <div className="container" style={{ maxWidth: '600px', margin: '0 auto', textAlign: 'center', padding: '60px 20px' }}>
                <div style={{ marginBottom: '30px' }}>
                    {isSuccess ? (
                        <FiCheckCircle style={{ width: '80px', height: '80px', color: '#28a745' }} />
                    ) : (
                        <FiXCircle style={{ width: '80px', height: '80px', color: '#dc3545' }} />
                    )}
                </div>

                <h1 style={{ fontSize: '24px', fontWeight: 'bold', marginBottom: '15px' }}>
                    {isSuccess ? 'Đặt hàng thành công!' : 'Đặt hàng thất bại'}
                </h1>

                {isSuccess ? (
                    <div style={{ color: '#666', marginBottom: '40px', lineHeight: '1.6' }}>
                        <p>Cảm ơn bạn đã mua hàng tại Format Vn Shop.</p>
                        <p>Mã đơn hàng của bạn là: <strong>{orderNumber}</strong></p>
                        <p>Chúng tôi sẽ sớm liên hệ với bạn để xác nhận đơn hàng.</p>
                    </div>
                ) : (
                    <div style={{ color: '#666', marginBottom: '40px', lineHeight: '1.6' }}>
                        <p>Rất tiếc, đã có lỗi xảy ra trong quá trình xử lý đơn hàng.</p>
                        {message && <p style={{ color: '#dc3545' }}>{message}</p>}
                        <p>Vui lòng thử lại hoặc liên hệ với bộ phận hỗ trợ.</p>
                    </div>
                )}

                <div style={{ display: 'flex', gap: '15px', justifyContent: 'center' }}>
                    <Link to="/" className="btn btn-outline" style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                        <FiHome /> Về trang chủ
                    </Link>
                    {!isSuccess && (
                        <Link to="/checkout/payment" className="btn btn-primary" style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                            Thử lại <FiArrowRight />
                        </Link>
                    )}
                    {isSuccess && (
                        <Link to="/products" className="btn btn-primary" style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                            Tiếp tục mua sắm <FiArrowRight />
                        </Link>
                    )}
                </div>
            </div>
        </div>
    );
};

export default CheckoutResult;
