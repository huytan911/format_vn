import { Link } from 'react-router-dom';
import { FiHeart, FiShoppingBag } from 'react-icons/fi';
import { useCart } from '../../contexts/CartContext';
import { useWishlist } from '../../contexts/WishlistContext';
import { getImageUrl } from '../../utils/imageUrl';
import './ProductCard.css';

const ProductCard = ({ product }) => {
    const { addToCart } = useCart();
    const { addToWishlist, removeFromWishlist, isInWishlist } = useWishlist();

    const formatPrice = (price) => {
        return new Intl.NumberFormat('vi-VN', {
            style: 'currency',
            currency: 'VND',
        }).format(price);
    };

    const handleWishlist = (e) => {
        e.preventDefault();
        e.stopPropagation();
        if (isInWishlist(product.id)) {
            removeFromWishlist(product.id);
        } else {
            addToWishlist(product.id);
        }
    };

    const handleAddToCart = (e) => {
        e.preventDefault();
        e.stopPropagation();
        addToCart(product);
    };

    return (
        <Link to={`/product/${product.id}`} className="product-card">
            <div className="product-image-wrapper">
                <img
                    src={getImageUrl(product.imageUrl)}
                    alt={product.name}
                    className="product-image"
                />
                <div className="product-overlay">
                    <div className="product-actions">
                        <button
                            className={`action-btn wishlist-btn ${isInWishlist(product.id) ? 'active' : ''}`}
                            onClick={handleWishlist}
                            title="Yêu thích"
                        >
                            <FiHeart fill={isInWishlist(product.id) ? "currentColor" : "none"} />
                        </button>
                        <button
                            className="action-btn cart-btn"
                            onClick={handleAddToCart}
                            title="Thêm vào giỏ"
                        >
                            <FiShoppingBag />
                        </button>
                    </div>
                    <button className="quick-view-btn">XEM NHANH</button>
                </div>
            </div>
            <div className="product-info">
                <h3 className="product-name">{product.name}</h3>
                <p className="product-price">{formatPrice(product.price)}</p>
                {product.category && (
                    <p className="product-category">{product.category.name}</p>
                )}
            </div>
        </Link>
    );
};

export default ProductCard;
