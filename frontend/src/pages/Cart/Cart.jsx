import React from 'react';
import { Link } from 'react-router-dom';
import { useCart } from '../../contexts/CartContext';
import { FiTrash2, FiMinus, FiPlus, FiArrowLeft } from 'react-icons/fi';
import { getImageUrl } from '../../utils/imageUrl';
import './Cart.css';

const Cart = () => {
    const { cartItems, updateQuantity, removeFromCart, clearCart, cartTotal, isLoading } = useCart();

    const formatPrice = (price) => {
        return new Intl.NumberFormat('vi-VN', {
            style: 'currency',
            currency: 'VND',
        }).format(price);
    };

    if (isLoading) {
        return <div className="cart-page loading">Đang tải giỏ hàng...</div>;
    }

    if (cartItems.length === 0) {
        return (
            <div className="cart-page empty">
                <div className="container">
                    <h2>GIỎ HÀNG CỦA BẠN ĐANG TRỐNG</h2>
                    <p>Hãy chọn lựa những sản phẩm ưng ý nhất từ FORMAT nhé!</p>
                    <Link to="/" className="btn btn-primary">TIẾP TỤC MUA SẮM</Link>
                </div>
            </div>
        );
    }

    return (
        <div className="cart-page">
            <div className="container">
                <h1 className="page-title">GIỎ HÀNG</h1>

                <div className="cart-layout">
                    <div className="cart-items-section">
                        <div className="cart-table-header">
                            <span>SẢN PHẨM</span>
                            <span>GIÁ</span>
                            <span>SỐ LƯỢNG</span>
                            <span>TỔNG</span>
                        </div>

                        {cartItems.map((item) => (
                            <div key={item.id} className="cart-item">
                                <div className="item-details">
                                    <div className="item-image">
                                        <img src={getImageUrl(item.imageUrl)} alt={item.productName} />
                                    </div>
                                    <div className="item-info">
                                        <h3>{item.productName}</h3>
                                        {item.variantName && (
                                            <p className="item-variant">{item.variantName}</p>
                                        )}
                                        <button
                                            className="remove-btn"
                                            onClick={() => removeFromCart(item.id)}
                                        >
                                            <FiTrash2 size={16} /> Xóa
                                        </button>
                                    </div>
                                </div>
                                <div className="item-price">
                                    {formatPrice(item.price)}
                                </div>
                                <div className="item-quantity">
                                    <div className="quantity-controls">
                                        <button onClick={() => updateQuantity(item.id, item.quantity - 1)}>
                                            <FiMinus size={14} />
                                        </button>
                                        <span>{item.quantity}</span>
                                        <button onClick={() => updateQuantity(item.id, item.quantity + 1)}>
                                            <FiPlus size={14} />
                                        </button>
                                    </div>
                                </div>
                                <div className="item-total">
                                    {formatPrice(item.price * item.quantity)}
                                </div>
                            </div>
                        ))}

                        <div className="cart-actions">
                            <Link to="/" className="back-link">
                                <FiArrowLeft /> TIẾP TỤC MUA SẮM
                            </Link>
                            <button className="clear-cart-btn" onClick={clearCart}>
                                XÓA TOÀN BỘ GIỎ HÀNG
                            </button>
                        </div>
                    </div>

                    <div className="cart-summary-section">
                        <div className="summary-card">
                            <h2>TỔNG CỘNG</h2>
                            <div className="summary-row">
                                <span>Tạm tính:</span>
                                <span>{formatPrice(cartTotal)}</span>
                            </div>
                            <div className="summary-row">
                                <span>Phí vận chuyển:</span>
                                <span>Miễn phí</span>
                            </div>
                            <div className="summary-total">
                                <span>THÀNH TIỀN:</span>
                                <span>{formatPrice(cartTotal)}</span>
                            </div>
                            <button className="checkout-btn btn-primary">
                                TIẾN HÀNH THANH TOÁN
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Cart;
