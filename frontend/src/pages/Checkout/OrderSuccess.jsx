import React from 'react';
import { Link, useLocation } from 'react-router-dom';
import { FiCheckCircle } from 'react-icons/fi';
import './Checkout.css';

const OrderSuccess = () => {
    const location = useLocation();
    const { orderId, orderNumber } = location.state || {}; // Retrieve passed state

    return (
        <div className="checkout-page">
            <div className="container">
                <div className="order-success-page">
                    <FiCheckCircle size={80} className="success-icon" />
                    <h1>Đặt hàng thành công!</h1>
                    <p>Cảm ơn bạn đã mua sắm tại FORMAT.</p>

                    {orderNumber && (
                        <div style={{ margin: '20px 0', padding: '15px', background: '#f5f5f5', borderRadius: '8px', display: 'inline-block' }}>
                            <span style={{ color: '#666' }}>Mã đơn hàng:</span> <strong>{orderNumber}</strong>
                        </div>
                    )}

                    <p>Chúng tôi sẽ sớm liên hệ để xác nhận đơn hàng của bạn.</p>

                    <div style={{ marginTop: '30px', display: 'flex', gap: '15px', justifyContent: 'center' }}>
                        <Link to="/" className="btn btn-primary">
                            TIẾP TỤC MUA SẮM
                        </Link>
                        <Link to="/profile" className="btn btn-outline">
                            XEM ĐƠN HÀNG
                        </Link>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default OrderSuccess;
