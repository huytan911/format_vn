import React from 'react';
import { Link } from 'react-router-dom';
import { useWishlist } from '../../contexts/WishlistContext';
import { useCart } from '../../contexts/CartContext';
import { FiTrash2, FiShoppingBag, FiArrowLeft } from 'react-icons/fi';
import { getImageUrl } from '../../utils/imageUrl';
import './Wishlist.css';

const Wishlist = () => {
    const { wishlistItems, removeFromWishlist, isLoading } = useWishlist();
    const { addToCart } = useCart();

    const formatPrice = (price) => {
        return new Intl.NumberFormat('vi-VN', {
            style: 'currency',
            currency: 'VND',
        }).format(price);
    };

    const handleAddToCart = (item) => {
        addToCart({
            id: item.productId,
            name: item.productName,
            price: item.price,
            imageUrl: item.imageUrl
        });
        removeFromWishlist(item.productId);
    };

    if (isLoading) {
        return <div className="wishlist-page loading">Đang tải danh sách yêu thích...</div>;
    }

    if (wishlistItems.length === 0) {
        return (
            <div className="wishlist-page empty">
                <div className="container">
                    <h2>DANH SÁCH YÊU THÍCH TRỐNG</h2>
                    <p>Hãy lưu lại những sản phẩm bạn yêu thích để mua sắm sau nhé!</p>
                    <Link to="/" className="btn btn-primary">KHÁM PHÁ SẢN PHẨM</Link>
                </div>
            </div>
        );
    }

    return (
        <div className="wishlist-page">
            <div className="container">
                <h1 className="page-title">DANH SÁCH YÊU THÍCH</h1>

                <div className="wishlist-grid">
                    {wishlistItems.map((item) => (
                        <div key={item.id} className="wishlist-item">
                            <div className="item-image" style={{ height: '400px', display: 'block' }}>
                                <Link to={`/product/${item.productId}`} style={{ display: 'block', height: '100%', width: '100%' }}>
                                    <img
                                        src={getImageUrl(item.imageUrl)}
                                        alt={item.productName}
                                        style={{ width: '100%', height: '100%', objectFit: 'cover' }}
                                    />
                                </Link>
                                <button
                                    className="remove-wishlist-btn"
                                    onClick={() => removeFromWishlist(item.productId)}
                                    title="Xóa khỏi yêu thích"
                                >
                                    <FiTrash2 size={18} />
                                </button>
                            </div>
                            <div className="item-info">
                                <h3>{item.productName}</h3>
                                <p className="item-price">{formatPrice(item.price)}</p>
                                <div className="item-status">
                                    {item.isInStock ? (
                                        <span className="stock-in">Còn hàng</span>
                                    ) : (
                                        <span className="stock-out">Hết hàng</span>
                                    )}
                                </div>
                                <button
                                    className="wishlist-add-to-cart-action"
                                    onClick={() => handleAddToCart(item)}
                                    disabled={!item.isInStock}
                                >
                                    <FiShoppingBag /> THÊM VÀO GIỎ
                                </button>
                            </div>
                        </div>
                    ))}
                </div>

                <div className="wishlist-footer">
                    <Link to="/" className="back-link">
                        <FiArrowLeft /> TIẾP TỤC MUA SẮM
                    </Link>
                </div>
            </div>
        </div>
    );
};

export default Wishlist;
