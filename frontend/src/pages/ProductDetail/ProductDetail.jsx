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
    const [selectedColor, setSelectedColor] = useState(null);
    const [selectedSize, setSelectedSize] = useState(null);
    const [activeTab, setActiveTab] = useState('description');
    const { addToCart } = useCart();
    const { addToWishlist, removeFromWishlist, isInWishlist } = useWishlist();

    useEffect(() => {
        const fetchProduct = async () => {
            try {
                const response = await productsAPI.getById(id);
                setProduct(response.data);
                // Auto-select default variant if available, otherwise pick first
                if (response.data.variants?.length > 0) {
                    const defaultVariant = response.data.variants.find(v => v.isDefault) || response.data.variants[0];
                    setSelectedVariant(defaultVariant);
                    setSelectedColor(defaultVariant.color);
                    setSelectedSize(defaultVariant.size);
                }
            } catch (error) {
                console.error('Error fetching product:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchProduct();
    }, [id]);

    // Derived values for selection
    const availableColors = product?.variants
        ? product.variants.reduce((acc, v) => {
            const existing = acc.find(a => a.name === v.color);
            if (existing) {
                existing.stock += v.stock;
            } else if (v.color) {
                acc.push({ name: v.color, stock: v.stock });
            }
            return acc;
        }, [])
        : [];

    const availableSizesForColor = product?.variants && selectedColor
        ? product.variants
            .filter(v => v.color === selectedColor && v.size)
            .map(v => ({ name: v.size, stock: v.stock }))
        : [];

    const handleColorSelect = (color) => {
        setSelectedColor(color);
        // Find if current size exists for this color
        const matchingVariant = product.variants.find(v => v.color === color && v.size === selectedSize);
        if (matchingVariant) {
            setSelectedVariant(matchingVariant);
        } else {
            // Pick first available size for this color
            const firstAvailable = product.variants.find(v => v.color === color);
            if (firstAvailable) {
                setSelectedSize(firstAvailable.size);
                setSelectedVariant(firstAvailable);
            }
        }
    };

    const handleSizeSelect = (size) => {
        setSelectedSize(size);
        const matchingVariant = product.variants.find(v => v.color === selectedColor && v.size === size);
        if (matchingVariant) {
            setSelectedVariant(matchingVariant);
        }
    };

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

                        <div className="product-tabs-section">
                            <div className="product-tabs-header">
                                <button
                                    className={`tab-btn ${activeTab === 'description' ? 'active' : ''}`}
                                    onClick={() => setActiveTab('description')}
                                >
                                    MÔ TẢ
                                </button>
                                <button
                                    className={`tab-btn ${activeTab === 'detail' ? 'active' : ''}`}
                                    onClick={() => setActiveTab('detail')}
                                >
                                    CHI TIẾT
                                </button>
                                <button
                                    className={`tab-btn ${activeTab === 'policy' ? 'active' : ''}`}
                                    onClick={() => setActiveTab('policy')}
                                >
                                    CHÍNH SÁCH
                                </button>
                            </div>

                            <div className="tab-content">
                                {activeTab === 'description' && (
                                    <div className="product-description fade-in">
                                        <p>{product.description || 'Chưa có mô tả cho sản phẩm này.'}</p>
                                    </div>
                                )}

                                {activeTab === 'detail' && (
                                    <div className="product-specifications fade-in">
                                        <ul className="specs-list">
                                            <li><strong>Chất liệu:</strong> {selectedVariant?.material || 'Liên hệ để biết thêm chi tiết'}</li>
                                            <li><strong>Phân loại:</strong> {product.category?.name || 'Sản phẩm mới'}</li>
                                            <li><strong>Kích thước:</strong> {selectedVariant?.size || 'Đa dạng'}</li>
                                            <li><strong>Màu sắc:</strong> {selectedColor || 'Đa dạng'}</li>
                                            <li><strong>SKU:</strong> {selectedVariant?.sku || `#${product.id}`}</li>
                                        </ul>
                                    </div>
                                )}

                                {activeTab === 'policy' && (
                                    <div className="product-policies fade-in">
                                        <div className="policy-item">
                                            <h5>MIỄN PHÍ GIAO HÀNG</h5>
                                            <p>Miễn phí giao hàng cho đơn hàng từ 1.000.000đ trở lên.</p>
                                        </div>
                                        <div className="policy-item">
                                            <h5>ĐỔI TRẢ DỄ DÀNG</h5>
                                            <p>Đổi sản phẩm trong vòng 7 ngày nếu do lỗi từ nhà sản xuất.</p>
                                        </div>
                                        <div className="policy-item">
                                            <h5>BẢO MẬT THANH TOÁN</h5>
                                            <p>Mọi thông tin giao dịch đều được mã hóa và bảo mật tuyệt đối.</p>
                                        </div>
                                    </div>
                                )}
                            </div>
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

                        <div className="product-stock">
                            <p>Còn hàng: <strong>{selectedVariant ? selectedVariant.stock : product.stock} sản phẩm</strong></p>
                        </div>

                        {product.variants && product.variants.length > 0 && (
                            <div className="product-selection-controls">
                                {availableColors.length > 0 && (
                                    <div className="selection-group">
                                        <label>Màu sắc:</label>
                                        <div className="selection-options">
                                            {availableColors.map(colorObj => (
                                                <button
                                                    key={colorObj.name}
                                                    className={`selection-item ${selectedColor === colorObj.name ? 'active' : ''} ${colorObj.stock <= 0 ? 'out-of-stock' : ''}`}
                                                    onClick={() => handleColorSelect(colorObj.name)}
                                                    title={colorObj.stock <= 0 ? 'Hết hàng' : `${colorObj.stock} sản phẩm`}
                                                >
                                                    {colorObj.name}
                                                    {colorObj.stock > 0 && <span className="item-stock-tag">({colorObj.stock})</span>}
                                                </button>
                                            ))}
                                        </div>
                                    </div>
                                )}

                                {availableSizesForColor.length > 0 && (
                                    <div className="selection-group">
                                        <label>Kích thước:</label>
                                        <div className="selection-options">
                                            {availableSizesForColor.map(sizeObj => (
                                                <button
                                                    key={sizeObj.name}
                                                    className={`selection-item ${selectedSize === sizeObj.name ? 'active' : ''} ${sizeObj.stock <= 0 ? 'out-of-stock' : ''}`}
                                                    onClick={() => handleSizeSelect(sizeObj.name)}
                                                    title={sizeObj.stock <= 0 ? 'Hết hàng' : `${sizeObj.stock} sản phẩm`}
                                                >
                                                    {sizeObj.name}
                                                    {sizeObj.stock > 0 && <span className="item-stock-tag">({sizeObj.stock})</span>}
                                                </button>
                                            ))}
                                        </div>
                                    </div>
                                )}

                                <div className="variant-selection-info">
                                    <p>Đang chọn: <strong>{selectedVariant ? `${selectedVariant.color} / ${selectedVariant.size} - ${selectedVariant.material}` : 'Chưa chọn'}</strong></p>
                                </div>
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
