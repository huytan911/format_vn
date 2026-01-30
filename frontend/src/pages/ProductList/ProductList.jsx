import { useState, useEffect, useCallback } from 'react';
import { useParams } from 'react-router-dom';
import ProductGrid from '../../components/ProductGrid/ProductGrid';
import { productsAPI, categoriesAPI } from '../../services/api';
import { FiSearch, FiSliders } from 'react-icons/fi';
import './ProductList.css';

const ProductList = () => {
    const { categoryId } = useParams();
    const [products, setProducts] = useState([]);
    const [category, setCategory] = useState(null);
    const [loading, setLoading] = useState(true);

    // Filter & Sort State
    const [searchTerm, setSearchTerm] = useState('');
    const [debouncedSearch, setDebouncedSearch] = useState('');
    const [sortBy, setSortBy] = useState('newest');
    const [minPrice, setMinPrice] = useState('');
    const [maxPrice, setMaxPrice] = useState('');
    const [inStock, setInStock] = useState(false);
    const [showFilters, setShowFilters] = useState(false);

    // Debounce search term
    useEffect(() => {
        const timer = setTimeout(() => {
            setDebouncedSearch(searchTerm);
        }, 500);
        return () => clearTimeout(timer);
    }, [searchTerm]);

    const fetchData = useCallback(async () => {
        setLoading(true);
        try {
            const params = {
                searchTerm: debouncedSearch,
                sortBy,
                minPrice: minPrice || null,
                maxPrice: maxPrice || null,
                inStock: inStock || null
            };

            if (categoryId) {
                const [productsRes, categoryRes] = await Promise.all([
                    productsAPI.getByCategory(categoryId, params),
                    categoriesAPI.getById(categoryId)
                ]);
                setProducts(productsRes.data);
                setCategory(categoryRes.data);
            } else {
                const response = await productsAPI.getAll(params);
                setProducts(response.data);
                setCategory(null);
            }
        } catch (error) {
            console.error('Error fetching products:', error);
        } finally {
            setLoading(false);
        }
    }, [categoryId, debouncedSearch, sortBy, minPrice, maxPrice, inStock]);

    useEffect(() => {
        fetchData();
    }, [fetchData]);

    const handleResetFilters = () => {
        setSearchTerm('');
        setSortBy('newest');
        setMinPrice('');
        setMaxPrice('');
        setInStock(false);
    };

    return (
        <div className="product-list-page">
            <div className="page-header">
                <div className="container">
                    <h1 className="page-title">
                        {category ? category.name : 'TẤT CẢ SẢN PHẨM'}
                    </h1>
                    {category?.description && (
                        <p className="page-description">{category.description}</p>
                    )}
                </div>
            </div>

            <div className="filter-bar">
                <div className="container">
                    <div className="filter-controls">
                        <div className="search-box">
                            <FiSearch className="search-icon" />
                            <input
                                type="text"
                                placeholder="Tìm kiếm sản phẩm..."
                                value={searchTerm}
                                onChange={(e) => setSearchTerm(e.target.value)}
                            />
                        </div>

                        <div className="sort-box">
                            <label>Sắp xếp:</label>
                            <select value={sortBy} onChange={(e) => setSortBy(e.target.value)}>
                                <option value="newest">Mới nhất</option>
                                <option value="price_asc">Giá: Thấp đến Cao</option>
                                <option value="price_desc">Giá: Cao đến Thấp</option>
                            </select>
                        </div>

                        <button
                            className={`filter-toggle-btn ${showFilters ? 'active' : ''}`}
                            onClick={() => setShowFilters(!showFilters)}
                        >
                            <FiSliders /> Bộ lọc
                        </button>
                    </div>

                    {showFilters && (
                        <div className="expanded-filters">
                            <div className="filter-group">
                                <label>Khoảng giá (VNĐ):</label>
                                <div className="price-inputs">
                                    <input
                                        type="number"
                                        placeholder="Từ"
                                        value={minPrice}
                                        onChange={(e) => setMinPrice(e.target.value)}
                                    />
                                    <span>-</span>
                                    <input
                                        type="number"
                                        placeholder="Đến"
                                        value={maxPrice}
                                        onChange={(e) => setMaxPrice(e.target.value)}
                                    />
                                </div>
                            </div>

                            <div className="filter-group checkbox-group">
                                <label>
                                    <input
                                        type="checkbox"
                                        checked={inStock}
                                        onChange={(e) => setInStock(e.target.checked)}
                                    />
                                    Còn hàng
                                </label>
                            </div>

                            <button className="reset-btn" onClick={handleResetFilters}>
                                Đặt lại
                            </button>
                        </div>
                    )}
                </div>
            </div>

            <div className="products-section">
                <div className="container">
                    {loading ? (
                        <div className="loading">Đang tải sản phẩm...</div>
                    ) : products.length > 0 ? (
                        <ProductGrid products={products} />
                    ) : (
                        <div className="no-results">
                            Không tìm thấy sản phẩm nào phù hợp với lựa chọn của bạn.
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default ProductList;
