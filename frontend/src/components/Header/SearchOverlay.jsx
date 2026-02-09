import React, { useState, useEffect, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import { FiSearch, FiX, FiClock, FiArrowRight, FiTrash2 } from 'react-icons/fi';
import api from '../../config/axiosConfig';
import { getImageUrl } from '../../utils/imageUrl';
import './SearchOverlay.css';

const SearchOverlay = ({ isOpen, onClose }) => {
    const [searchTerm, setSearchTerm] = useState('');
    const [suggestions, setSuggestions] = useState([]);
    const [history, setHistory] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const inputRef = useRef(null);
    const navigate = useNavigate();

    useEffect(() => {
        if (isOpen) {
            setTimeout(() => inputRef.current?.focus(), 100);
            const savedHistory = JSON.parse(localStorage.getItem('searchHistory') || '[]');
            setHistory(savedHistory);
        }
    }, [isOpen]);

    useEffect(() => {
        const fetchSuggestions = async () => {
            if (searchTerm.length < 1) {
                setSuggestions([]);
                return;
            }
            setIsLoading(true);
            try {
                const response = await api.get(`/products/suggestions?q=${searchTerm}`);
                setSuggestions(response.data);
            } catch (error) {
                console.error('Error fetching suggestions:', error);
            } finally {
                setIsLoading(false);
            }
        };

        const debounce = setTimeout(fetchSuggestions, 100);
        return () => clearTimeout(debounce);
    }, [searchTerm]);

    const handleSearch = (term) => {
        const finalTerm = term || searchTerm;
        if (!finalTerm.trim()) return;

        // Save to history
        const newHistory = [finalTerm, ...history.filter(h => h !== finalTerm)].slice(0, 10);
        setHistory(newHistory);
        localStorage.setItem('searchHistory', JSON.stringify(newHistory));

        navigate(`/products?search=${encodeURIComponent(finalTerm)}`);
        onClose();
    };

    const clearHistory = () => {
        setHistory([]);
        localStorage.removeItem('searchHistory');
    };

    const removeHistoryItem = (e, item) => {
        e.stopPropagation();
        const newHistory = history.filter(h => h !== item);
        setHistory(newHistory);
        localStorage.setItem('searchHistory', JSON.stringify(newHistory));
    };

    if (!isOpen) return null;

    return (
        <div className={`search-overlay ${isOpen ? 'open' : ''}`} onClick={onClose}>
            <div className="search-container" onClick={e => e.stopPropagation()}>
                <div className="search-header">
                    <div className="search-input-wrapper">
                        <FiSearch className="search-icon-main" />
                        <input
                            ref={inputRef}
                            type="text"
                            placeholder="Tìm kiếm sản phẩm..."
                            value={searchTerm}
                            onChange={(e) => setSearchTerm(e.target.value)}
                            onKeyDown={(e) => e.key === 'Enter' && handleSearch()}
                        />
                        {isLoading && <div className="search-spinner" />}
                    </div>
                    <button className="close-overlay" onClick={onClose}>
                        <FiX size={24} />
                    </button>
                </div>

                <div className="search-body custom-scrollbar">
                    {searchTerm.length < 1 ? (
                        <div className="search-initial">
                            {history.length > 0 && (
                                <div className="search-section">
                                    <div className="section-header">
                                        <h3>LỊCH SỬ TÌM KIẾM</h3>
                                        <button className="btn-clear" onClick={clearHistory}>XOÁ TẤT CẢ</button>
                                    </div>
                                    <div className="history-list">
                                        {history.map((item, index) => (
                                            <div
                                                key={index}
                                                className="history-item"
                                                onClick={() => handleSearch(item)}
                                                style={{ animationDelay: `${index * 0.05}s` }}
                                            >
                                                <FiClock className="item-icon" />
                                                <span>{item}</span>
                                                <button className="btn-remove" onClick={(e) => removeHistoryItem(e, item)}>
                                                    <FiX size={14} />
                                                </button>
                                            </div>
                                        ))}
                                    </div>
                                </div>
                            )}
                            <div className="search-section">
                                <h3>GỢI Ý TÌM KIẾM</h3>
                                <div className="suggestion-tags">
                                    {['Áo Vest', 'Quần Tây', 'Sơ Mi', 'Phụ Kiện'].map((tag, idx) => (
                                        <button
                                            key={tag}
                                            onClick={() => handleSearch(tag)}
                                            style={{ animationDelay: `${(history.length + idx) * 0.05}s` }}
                                        >
                                            {tag}
                                        </button>
                                    ))}
                                </div>
                            </div>
                        </div>
                    ) : (
                        <div className="search-results-mini">
                            {suggestions.length > 0 ? (
                                <div className="suggestions-grid">
                                    {suggestions.map((product, index) => (
                                        <div
                                            key={product.id}
                                            className="suggestion-card"
                                            onClick={() => {
                                                navigate(`/product/${product.id}`);
                                                onClose();
                                            }}
                                            style={{ animationDelay: `${index * 0.08}s` }}
                                        >
                                            <div className="suggestion-image">
                                                <img src={getImageUrl(product.imageUrl)} alt={product.name} />
                                            </div>
                                            <div className="suggestion-info">
                                                <h4>{product.name}</h4>
                                                <p className="price">{product.price.toLocaleString('vi-VN')}đ</p>
                                            </div>
                                            <div className="go-icon">
                                                <FiArrowRight size={20} />
                                            </div>
                                        </div>
                                    ))}
                                </div>
                            ) : (
                                !isLoading && <p className="no-matches">Không tìm thấy sản phẩm phù hợp</p>
                            )}
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
};

export default SearchOverlay;
