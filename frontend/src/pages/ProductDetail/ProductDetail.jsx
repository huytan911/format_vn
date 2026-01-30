import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { productsAPI } from '../../services/api';
import { FiShoppingBag, FiHeart } from 'react-icons/fi';
import { useCart } from '../../contexts/CartContext';
import { useWishlist } from '../../contexts/WishlistContext';
import { getImageUrl } from '../../utils/imageUrl';
import './ProductDetail.css';

const ProductDetail = () => {
    const { id } = useParams();
    const [product, setProduct] = useState(null);
    const [loading, setLoading] = useState(true);
    const [quantity, setQuantity] = useState(1);
    const { addToCart } = useCart();
    const { addToWishlist, removeFromWishlist, isInWishlist } = useWishlist();

    useEffect(() => {
        const fetchProduct = async () => {
            try {
                const response = await productsAPI.getById(id);
                setProduct(response.data);
            } catch (error) {
                console.error('Error fetching product:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchProduct();
    }, [id]);

    const formatPrice = (price) => {
        return new Intl.NumberFormat('vi-VN', {
            style: 'currency',
            currency: 'VND',
        }).format(price);
    };

    const handleQuantityChange = (change) => {
        const newQuantity = quantity + change;
        if (newQuantity >= 1 && newQuantity <= (product?.stock || 1)) {
            setQuantity(newQuantity);
        }
    };

    if (loading) {
        return <div className="loading">Đang tải sản phẩm...</div>;
    }

    if (!product) {
        return <div className="loading">Không tìm thấy sản phẩm</div>;
    }

    return (
        <div className="product-detail-page">
            <div className="container">
                <div className="product-detail-grid">
                    <div className="product-images">
                        <div className="main-image">
                            <img
                                src={getImageUrl(product.imageUrl)}
                                alt={product.name}
                            />
                        </div>
                    </div>

                    <div className="product-details">
                        {product.category && (
                            <p className="product-category-tag">{product.category.name}</p>
                        )}
                        <h1 className="product-title">{product.name}</h1>
                        <p className="product-price-large">{formatPrice(product.price)}</p>

                        {product.description && (
                            <div className="product-description">
                                <p>{product.description}</p>
                            </div>
                        )}

                        <div className="product-stock">
                            <p>Còn hàng: <strong>{product.stock} sản phẩm</strong></p>
                        </div>

                        <div className="quantity-selector">
                            <label>Số lượng:</label>
                            <div className="quantity-controls">
                                <button
                                    onClick={() => handleQuantityChange(-1)}
                                    disabled={quantity <= 1}
                                    className="quantity-btn"
                                >
                                    -
                                </button>
                                <span className="quantity-value">{quantity}</span>
                                <button
                                    onClick={() => handleQuantityChange(1)}
                                    disabled={quantity >= product.stock}
                                    className="quantity-btn"
                                >
                                    +
                                </button>
                            </div>
                        </div>

                        <div className="product-actions">
                            <button
                                className="btn btn-primary add-to-cart"
                                onClick={() => addToCart(product, quantity)}
                                disabled={product.stock <= 0}
                            >
                                <FiShoppingBag /> Thêm vào giỏ hàng
                            </button>
                            <button
                                className={`btn wishlist-detail-btn ${isInWishlist(product.id) ? 'active' : ''}`}
                                onClick={() => isInWishlist(product.id) ? removeFromWishlist(product.id) : addToWishlist(product.id)}
                            >
                                <FiHeart fill={isInWishlist(product.id) ? "currentColor" : "none"} />
                                {isInWishlist(product.id) ? ' Đã yêu thích' : ' Yêu thích'}
                            </button>
                        </div>

                        <div className="product-meta">
                            <p><strong>Mã sản phẩm:</strong> #{product.id}</p>
                            <p><strong>Danh mục:</strong> {product.category?.name}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default ProductDetail;
