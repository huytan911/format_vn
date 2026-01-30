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
    const [selectedVariant, setSelectedVariant] = useState(null);
    const { addToCart } = useCart();
    const { addToWishlist, removeFromWishlist, isInWishlist } = useWishlist();

    useEffect(() => {
        const fetchProduct = async () => {
            try {
                const response = await productsAPI.getById(id);
                setProduct(response.data);
                // Auto-select first variant if available
                if (response.data.variants?.length > 0) {
                    setSelectedVariant(response.data.variants[0]);
                }
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
        const maxStock = selectedVariant ? selectedVariant.stock : product?.stock;
        if (newQuantity >= 1 && newQuantity <= (maxStock || 1)) {
            setQuantity(newQuantity);
        }
    };

    const handleAddToCart = () => {
        const itemToCart = {
            ...product,
            price: selectedVariant?.price || product.price,
            stock: selectedVariant ? selectedVariant.stock : product.stock,
            variantId: selectedVariant?.id,
            variantName: selectedVariant ? `${selectedVariant.color} / ${selectedVariant.size} (${selectedVariant.material})` : null
        };
        addToCart(itemToCart, quantity);
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
                                src={getImageUrl((selectedVariant && selectedVariant.imageUrl) ? selectedVariant.imageUrl : product.imageUrl)}
                                alt={product.name}
                            />
                        </div>
                    </div>

                    <div className="product-details">
                        {product.category && (
                            <p className="product-category-tag">{product.category.name}</p>
                        )}
                        <h1 className="product-title">{product.name}</h1>
                        <p className="product-price-large">
                            {formatPrice(selectedVariant?.price || product.price)}
                        </p>

                        {product.description && (
                            <div className="product-description">
                                <p>{product.description}</p>
                            </div>
                        )}

                        <div className="product-stock">
                            <p>Còn hàng: <strong>{selectedVariant ? selectedVariant.stock : product.stock} sản phẩm</strong></p>
                        </div>

                        {product.variants && product.variants.length > 0 && (
                            <div className="variant-selection-info">
                                <p>Phiên bản đang chọn: <strong>{selectedVariant ? `${selectedVariant.color} / ${selectedVariant.size} - ${selectedVariant.material}` : 'Chưa chọn'}</strong></p>
                            </div>
                        )}

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
                                    disabled={quantity >= (selectedVariant ? selectedVariant.stock : product.stock)}
                                    className="quantity-btn"
                                >
                                    +
                                </button>
                            </div>
                        </div>

                        <div className="product-actions">
                            <button
                                className="btn btn-primary add-to-cart"
                                onClick={handleAddToCart}
                                disabled={(selectedVariant ? selectedVariant.stock : product.stock) <= 0}
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
                            <p><strong>Mã sản phẩm:</strong> {selectedVariant ? selectedVariant.sku : `#${product.id}`}</p>
                        </div>
                    </div>
                </div>

                {product.variants && product.variants.length > 0 && (
                    <div className="product-variants-section">
                        <h2 className="section-title">DANH SÁCH CHI TIẾT PHIÊN BẢN</h2>
                        <div className="variants-table-container">
                            <table className="variants-table">
                                <thead>
                                    <tr>
                                        <th>ẢNH</th>
                                        <th>MÀU SẮC</th>
                                        <th>CHẤT LIỆU</th>
                                        <th>KÍCH THƯỚC</th>
                                        <th>MÃ SKU</th>
                                        <th>GIÁ</th>
                                        <th>TRẠNG THÁI</th>
                                        <th>HÀNH ĐỘNG</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {product.variants.map(variant => (
                                        <tr key={variant.id} className={selectedVariant?.id === variant.id ? 'active' : ''}>
                                            <td>
                                                <div className="variant-thumbnail">
                                                    <img src={getImageUrl(variant.imageUrl || product.imageUrl)} alt={variant.color} />
                                                </div>
                                            </td>
                                            <td>{variant.color}</td>
                                            <td>{variant.material}</td>
                                            <td>{variant.size}</td>
                                            <td>{variant.sku}</td>
                                            <td>{formatPrice(variant.price || product.price)}</td>
                                            <td>
                                                <span className={variant.stock > 0 ? 'stock-label in' : 'stock-label out'}>
                                                    {variant.stock > 0 ? `Còn ${variant.stock}` : 'Hết hàng'}
                                                </span>
                                            </td>
                                            <td>
                                                <button
                                                    className="select-v-btn"
                                                    onClick={() => setSelectedVariant(variant)}
                                                >
                                                    {selectedVariant?.id === variant.id ? 'Đang chọn' : 'Chọn bản này'}
                                                </button>
                                            </td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    </div>
                )}
            </div>
        </div>
    );
};

export default ProductDetail;
