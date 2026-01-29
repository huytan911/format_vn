import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import ProductGrid from '../../components/ProductGrid/ProductGrid';
import { productsAPI, categoriesAPI } from '../../services/api';
import './ProductList.css';

const ProductList = () => {
    const { categoryId } = useParams();
    const [products, setProducts] = useState([]);
    const [category, setCategory] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            setLoading(true);
            try {
                if (categoryId) {
                    const [productsRes, categoryRes] = await Promise.all([
                        productsAPI.getByCategory(categoryId),
                        categoriesAPI.getById(categoryId)
                    ]);
                    setProducts(productsRes.data);
                    setCategory(categoryRes.data);
                } else {
                    const response = await productsAPI.getAll();
                    setProducts(response.data);
                }
            } catch (error) {
                console.error('Error fetching products:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchData();
    }, [categoryId]);

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

            {loading ? (
                <div className="loading">Đang tải sản phẩm...</div>
            ) : (
                <ProductGrid products={products} />
            )}
        </div>
    );
};

export default ProductList;
