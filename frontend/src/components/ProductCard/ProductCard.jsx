import { Link } from 'react-router-dom';
import './ProductCard.css';

const ProductCard = ({ product }) => {
    const formatPrice = (price) => {
        return new Intl.NumberFormat('vi-VN', {
            style: 'currency',
            currency: 'VND',
        }).format(price);
    };

    return (
        <Link to={`/product/${product.id}`} className="product-card">
            <div className="product-image-wrapper">
                <img
                    src={product.imageUrl || 'https://via.placeholder.com/400x500?text=Format'}
                    alt={product.name}
                    className="product-image"
                />
                <div className="product-overlay">
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
