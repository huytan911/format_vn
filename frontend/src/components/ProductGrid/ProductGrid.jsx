import ProductCard from '../ProductCard/ProductCard';
import './ProductGrid.css';

const ProductGrid = ({ products, title }) => {
    return (
        <section className="product-grid-section">
            {title && (
                <div className="container">
                    <h2 className="section-title text-center text-uppercase">{title}</h2>
                </div>
            )}
            <div className="container">
                <div className="product-grid grid grid-4">
                    {products && products.length > 0 ? (
                        products.map((product) => (
                            <ProductCard key={product.id} product={product} />
                        ))
                    ) : (
                        <p className="no-products">Không có sản phẩm nào</p>
                    )}
                </div>
            </div>
        </section>
    );
};

export default ProductGrid;
