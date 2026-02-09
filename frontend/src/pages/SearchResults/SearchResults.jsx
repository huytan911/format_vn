import { useState, useEffect, useCallback } from 'react';
import { useSearchParams } from 'react-router-dom';
import usePageTitle from '../../hooks/usePageTitle';
import ProductGrid from '../../components/ProductGrid/ProductGrid';
import Pagination from '../../components/Common/Pagination';
import { productsAPI } from '../../services/api';
import { FiSearch, FiSliders } from 'react-icons/fi';
import '../ProductList/ProductList.css'; // Reuse ProductList styles

const SearchResults = () => {
    const [searchParams] = useSearchParams();
    const query = searchParams.get('q') || '';
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [pagination, setPagination] = useState({
        currentPage: 1,
        totalPages: 1,
        pageSize: 12,
        totalCount: 0
    });

    usePageTitle(`Kết quả tìm kiếm cho "${query}"`);

    // Filter & Sort State
    const [sortBy, setSortBy] = useState('newest');
    const [minPrice, setMinPrice] = useState('');
    const [maxPrice, setMaxPrice] = useState('');
    const [inStock, setInStock] = useState(false);
    const [selectedColors, setSelectedColors] = useState([]);
    const [selectedMaterials, setSelectedMaterials] = useState([]);
    const [filterOptions, setFilterOptions] = useState({
        colors: [],
        materials: [],
        minPrice: 0,
        maxPrice: 0
    });
    const [showFilters, setShowFilters] = useState(false);

    useEffect(() => {
        const fetchFilters = async () => {
            try {
                const response = await productsAPI.getFilters();
                setFilterOptions(response.data);
            } catch (error) {
                console.error('Error fetching filters:', error);
            }
        };
        fetchFilters();
    }, []);

    const fetchData = useCallback(async (page = 1) => {
        setLoading(true);
        try {
            const params = {
                searchTerm: query,
                sortBy,
                minPrice: minPrice || null,
                maxPrice: maxPrice || null,
                inStock: inStock || null,
                colors: selectedColors.length > 0 ? selectedColors : null,
                materials: selectedMaterials.length > 0 ? selectedMaterials : null,
                page,
                pageSize: pagination.pageSize
            };

            const response = await productsAPI.getAll(params);
            const data = response.data;
            const items = Array.isArray(data) ? data : (data.items || data.Items || []);
            const totalCount = data.totalCount || data.TotalCount || items.length;
            const currentPage = data.page || data.Page || 1;
            const totalPages = data.totalPages || data.TotalPages || 1;

            setProducts(items);
            setPagination(prev => ({
                ...prev,
                currentPage,
                totalPages,
                totalCount
            }));
        } catch (error) {
            console.error('Error fetching search results:', error);
        } finally {
            setLoading(false);
        }
    }, [query, sortBy, minPrice, maxPrice, inStock, selectedColors, selectedMaterials, pagination.pageSize]);

    useEffect(() => {
        fetchData(1);
    }, [fetchData]);

    const handlePageChange = (newPage) => {
        window.scrollTo({ top: 0, behavior: 'smooth' });
        fetchData(newPage);
    };

    const handleResetFilters = () => {
        setSortBy('newest');
        setMinPrice('');
        setMaxPrice('');
        setInStock(false);
        setSelectedColors([]);
        setSelectedMaterials([]);
    };

    const handleToggleFilter = (item, selectedList, setSelectedList) => {
        if (selectedList.includes(item)) {
            setSelectedList(selectedList.filter(i => i !== item));
        } else {
            setSelectedList([...selectedList, item]);
        }
    };

    return (
        <div className="product-list-page">
            <div className="page-header">
                <div className="container">
                    <h1 className="page-title">
                        KẾT QUẢ TÌM KIẾM
                    </h1>
                    <p className="page-description">Tìm thấy {pagination.totalCount} sản phẩm cho "{query}"</p>
                </div>
            </div>

            <div className="filter-bar">
                <div className="container">
                    <div className="filter-controls">
                        <div className="search-info">
                            <FiSearch /> <span>"{query}"</span>
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
                            <div className="filter-grid">
                                <div className="filter-column">
                                    <div className="filter-group">
                                        <label>Khoảng giá (VNĐ):</label>
                                        <div className="price-inputs">
                                            <input
                                                type="number"
                                                placeholder={`Từ ${filterOptions.minPrice.toLocaleString()}`}
                                                value={minPrice}
                                                onChange={(e) => setMinPrice(e.target.value)}
                                            />
                                            <span>-</span>
                                            <input
                                                type="number"
                                                placeholder={`Đến ${filterOptions.maxPrice.toLocaleString()}`}
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
                                </div>

                                {filterOptions.colors?.length > 0 && (
                                    <div className="filter-column">
                                        <div className="filter-group">
                                            <label>Màu sắc:</label>
                                            <div className="options-list">
                                                {filterOptions.colors.map(color => (
                                                    <label key={color} className="option-item">
                                                        <input
                                                            type="checkbox"
                                                            checked={selectedColors.includes(color)}
                                                            onChange={() => handleToggleFilter(color, selectedColors, setSelectedColors)}
                                                        />
                                                        {color}
                                                    </label>
                                                ))}
                                            </div>
                                        </div>
                                    </div>
                                )}

                                {filterOptions.materials?.length > 0 && (
                                    <div className="filter-column">
                                        <div className="filter-group">
                                            <label>Chất liệu:</label>
                                            <div className="options-list">
                                                {filterOptions.materials.map(material => (
                                                    <label key={material} className="option-item">
                                                        <input
                                                            type="checkbox"
                                                            checked={selectedMaterials.includes(material)}
                                                            onChange={() => handleToggleFilter(material, selectedMaterials, setSelectedMaterials)}
                                                        />
                                                        {material}
                                                    </label>
                                                ))}
                                            </div>
                                        </div>
                                    </div>
                                )}
                            </div>

                            <div className="filter-actions">
                                <button className="reset-btn" onClick={handleResetFilters}>
                                    Đặt lại
                                </button>
                            </div>
                        </div>
                    )}
                </div>
            </div>

            <div className="products-section">
                <div className="container">
                    {loading ? (
                        <div className="loading">Đang tìm kiếm sản phẩm...</div>
                    ) : products.length > 0 ? (
                        <>
                            <ProductGrid products={products} />
                            <Pagination
                                currentPage={pagination.currentPage}
                                totalPages={pagination.totalPages}
                                onPageChange={handlePageChange}
                            />
                        </>
                    ) : (
                        <div className="no-results">
                            Không tìm thấy sản phẩm nào phù hợp với "{query}".
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default SearchResults;
