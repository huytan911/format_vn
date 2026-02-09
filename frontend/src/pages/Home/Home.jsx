import { useState, useEffect } from 'react';
import usePageTitle from '../../hooks/usePageTitle';
import Hero from '../../components/Hero/Hero';
import ProductGrid from '../../components/ProductGrid/ProductGrid';
import { productsAPI } from '../../services/api';
import './Home.css';

const Home = () => {
    const [featuredProducts, setFeaturedProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    usePageTitle('Trang chủ');

    useEffect(() => {
        const fetchFeaturedProducts = async () => {
            try {
                const response = await productsAPI.getFeatured();
                setFeaturedProducts(response.data);
            } catch (error) {
                console.error('Error fetching featured products:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchFeaturedProducts();
    }, []);

    return (
        <div className="home-page">
            <Hero
                title="BỘ SƯU TẬP MỚI NHẤT"
                subtitle="New Collection 2026"
                image="https://images.unsplash.com/photo-1490481651871-ab68de25d43d?w=1600&h=900&fit=crop"
                ctaText="Khám phá ngay"
                ctaLink="/category/1"
            />

            {loading ? (
                <div className="loading">Đang tải sản phẩm...</div>
            ) : (
                <>
                    <ProductGrid
                        products={featuredProducts}
                        title="Sản phẩm nổi bật"
                    />

                    <section className="promo-section">
                        <div className="container">
                            <div className="promo-grid">
                                <div className="promo-card" style={{
                                    backgroundImage: 'url(https://images.unsplash.com/photo-1483985988355-763728e1935b?w=800&h=1000&fit=crop)'
                                }}>
                                    <div className="promo-content">
                                        <h3>THỜI TRANG NỮ</h3>
                                        <a href="/category/1" className="promo-link">Xem thêm →</a>
                                    </div>
                                </div>
                                <div className="promo-card" style={{
                                    backgroundImage: 'url(https://images.unsplash.com/photo-1490367532201-b9bc1dc483f6?w=800&h=1000&fit=crop)'
                                }}>
                                    <div className="promo-content">
                                        <h3>THỜI TRANG NAM</h3>
                                        <a href="/category/2" className="promo-link">Xem thêm →</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </>
            )}
        </div>
    );
};

export default Home;
