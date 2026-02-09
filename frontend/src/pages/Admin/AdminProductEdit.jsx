import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import api from '../../config/axiosConfig';
import AdminLayout from '../../components/AdminLayout/AdminLayout';
import MultiSelect from '../../components/MultiSelect/MultiSelect';
import ImageUpload from '../../components/ImageUpload/ImageUpload';
import { FiArrowLeft, FiPlus, FiTrash2, FiSave, FiImage, FiCamera } from 'react-icons/fi';
import { getImageUrl } from '../../utils/imageUrl';
import '../../styles/admin.css';

const AdminProductEdit = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const isEdit = id && id !== 'new' && id !== 'undefined';

    const [categories, setCategories] = useState([]);
    const [loading, setLoading] = useState(isEdit);
    const [saving, setSaving] = useState(false);

    const [formData, setFormData] = useState({
        name: '',
        description: '',
        price: '',
        categoryIds: [],
        imageUrl: '',
        stock: '',
        weight: '',
        isFeatured: false,
        variants: []
    });

    const [matrixInputs, setMatrixInputs] = useState({
        colors: [''],
        materials: [''],
        sizes: ['']
    });

    const addAttributeValue = (type) => {
        setMatrixInputs(prev => ({
            ...prev,
            [type]: [...prev[type], '']
        }));
    };

    const removeAttributeValue = (type, index) => {
        setMatrixInputs(prev => ({
            ...prev,
            [type]: prev[type].filter((_, i) => i !== index)
        }));
    };

    const handleAttributeValueChange = (type, index, value) => {
        setMatrixInputs(prev => {
            const newValues = [...prev[type]];
            newValues[index] = value;
            return { ...prev, [type]: newValues };
        });
    };

    const handleMatrixGenerate = () => {
        const colors = matrixInputs.colors.map(s => s.trim()).filter(s => s);
        const materials = matrixInputs.materials.map(s => s.trim()).filter(s => s);
        const sizes = matrixInputs.sizes.map(s => s.trim()).filter(s => s);

        if (colors.length === 0 && materials.length === 0 && sizes.length === 0) {
            alert('Vui lòng nhập ít nhất một thuộc tính');
            return;
        }

        // Use base values if empty
        const colorsList = colors.length > 0 ? colors : [''];
        const materialsList = materials.length > 0 ? materials : [''];
        const sizesList = sizes.length > 0 ? sizes : [''];

        const newVariants = [];
        colorsList.forEach(color => {
            materialsList.forEach(material => {
                sizesList.forEach(size => {
                    newVariants.push({
                        id: 0,
                        color,
                        material,
                        size,
                        sku: `${formData.name.substring(0, 3).toUpperCase()}-${color.substring(0, 3).toUpperCase()}-${size.toUpperCase()}`,
                        price: '',
                        stock: 0,
                        isDefault: false
                    });
                });
            });
        });

        // Mark first one as default if any created
        if (newVariants.length > 0) {
            newVariants[0].isDefault = true;
        }

        if (window.confirm(`Bạn có muốn tạo ${newVariants.length} phiên bản? Việc này sẽ thay thế danh sách hiện tại.`)) {
            setFormData(prev => ({ ...prev, variants: newVariants }));
        }
    };

    useEffect(() => {
        fetchCategories();
        if (isEdit) {
            fetchProduct();
        }
    }, [id]);

    const fetchCategories = async () => {
        try {
            const response = await api.get('/categories');
            setCategories(response.data);
        } catch (error) {
            console.error('Error fetching categories:', error);
        }
    };

    const fetchProduct = async () => {
        try {
            const response = await api.get(`/products/${id}`);
            const p = response.data;
            setFormData({
                name: p.name,
                description: p.description || '',
                price: p.price,
                categoryIds: p.categories ? p.categories.map(c => c.id) : [],
                imageUrl: p.imageUrl || '',
                stock: p.stock,
                weight: p.weight || 0,
                isFeatured: p.isFeatured,
                variants: p.variants || []
            });
        } catch (error) {
            console.error('Error fetching product:', error);
            alert('Không thể tải thông tin sản phẩm');
            navigate('/admin/products');
        } finally {
            setLoading(false);
        }
    };

    const handleAddVariant = () => {
        setFormData(prev => ({
            ...prev,
            variants: [
                ...prev.variants,
                { id: 0, color: '', material: '', size: '', sku: '', price: '', stock: 0, isDefault: prev.variants.length === 0 }
            ]
        }));
    };

    const handleRemoveVariant = (index) => {
        setFormData(prev => ({
            ...prev,
            variants: prev.variants.filter((_, i) => i !== index)
        }));
    };

    const handleVariantChange = (index, field, value) => {
        setFormData(prev => {
            let newVariants = [...prev.variants];
            if (field === 'isDefault' && value === true) {
                // Unset other defaults
                newVariants = newVariants.map((v, i) => ({ ...v, isDefault: i === index }));
            } else {
                newVariants[index] = { ...newVariants[index], [field]: value };
            }
            return { ...prev, variants: newVariants };
        });
    };

    const handleVariantImageUpload = async (index, file) => {
        if (!file) return;
        const formDataUpload = new FormData();
        formDataUpload.append('file', file);

        try {
            const response = await api.post(`/upload?folder=products`, formDataUpload, {
                headers: { 'Content-Type': 'multipart/form-data' }
            });
            handleVariantChange(index, 'imageUrl', response.data.url);
        } catch (error) {
            console.error('Variant image upload failed:', error);
            alert('Lỗi khi tải ảnh lên');
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setSaving(true);
        try {
            const payload = {
                ...formData,
                price: parseFloat(formData.price),
                stock: parseInt(formData.stock),
                weight: parseInt(formData.weight) || 0,
                categoryIds: formData.categoryIds.map(id => parseInt(id)),
                variants: formData.variants.map(v => ({
                    ...v,
                    price: v.price ? parseFloat(v.price) : null,
                    stock: parseInt(v.stock),
                    id: v.id || 0
                }))
            };

            if (isEdit) {
                await api.put(`/products/${id}`, { ...payload, id: parseInt(id) });
            } else {
                await api.post('/products', payload);
            }
            navigate('/admin/products');
        } catch (error) {
            console.error('Error saving product:', error);
            alert('Lỗi khi lưu sản phẩm: ' + (error.response?.data?.message || error.message));
        } finally {
            setSaving(false);
        }
    };

    if (loading) return <AdminLayout><div className="loading">Đang tải...</div></AdminLayout>;

    return (
        <AdminLayout>
            <div className="admin-page-header">
                <button className="back-btn" onClick={() => navigate('/admin/products')}>
                    <FiArrowLeft /> Quay lại
                </button>
                <h1>{isEdit ? 'Chỉnh sửa Sản phẩm' : 'Thêm Sản phẩm mới'}</h1>
            </div>

            <form onSubmit={handleSubmit} className="admin-edit-form">
                <div className="form-sections-grid">
                    <div className="form-main-section">
                        <div className="card">
                            <h3>Thông tin cơ bản</h3>
                            <div className="form-group">
                                <label>Tên sản phẩm *</label>
                                <input
                                    type="text"
                                    value={formData.name}
                                    onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                                    required
                                />
                            </div>
                            <div className="form-group">
                                <label>Mô tả</label>
                                <textarea
                                    value={formData.description}
                                    onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                                    rows="6"
                                />
                            </div>
                        </div>

                        <div className="card">
                            <h3>Phiên bản Sản phẩm</h3>
                            <p className="section-help">Thêm các giá trị cho từng thuộc tính bên dưới để tạo phiên bản tự động.</p>

                            <div className="variant-matrix-generator">
                                <div className="matrix-sections">
                                    {[
                                        { key: 'colors', label: 'Màu sắc' },
                                        { key: 'materials', label: 'Chất liệu' },
                                        { key: 'sizes', label: 'Kích thước' }
                                    ].map((attr) => (
                                        <div key={attr.key} className="attribute-section">
                                            <label className="attribute-title">{attr.label}</label>
                                            <div className="attribute-values">
                                                {matrixInputs[attr.key].map((val, idx) => (
                                                    <div key={idx} className="value-input-row">
                                                        <input
                                                            type="text"
                                                            value={val}
                                                            onChange={(e) => handleAttributeValueChange(attr.key, idx, e.target.value)}
                                                            placeholder={`Nhập ${attr.label.toLowerCase()}...`}
                                                        />
                                                        {matrixInputs[attr.key].length > 1 && (
                                                            <button
                                                                type="button"
                                                                className="remove-val-btn"
                                                                onClick={() => removeAttributeValue(attr.key, idx)}
                                                            >
                                                                <FiTrash2 />
                                                            </button>
                                                        )}
                                                    </div>
                                                ))}
                                                <button
                                                    type="button"
                                                    className="add-value-btn"
                                                    onClick={() => addAttributeValue(attr.key)}
                                                >
                                                    <FiPlus /> Thêm giá trị
                                                </button>
                                            </div>
                                        </div>
                                    ))}
                                </div>
                                <button type="button" className="btn-secondary w-100 generate-btn" onClick={handleMatrixGenerate}>
                                    <FiPlus /> Tạo phiên bản tự động
                                </button>
                            </div>

                            <hr style={{ margin: '20px 0', border: 'none', borderTop: '1px solid rgba(99,179,237,0.1)' }} />

                            <div className="variants-editor">
                                {formData.variants.length > 0 ? (
                                    <table className="admin-table">
                                        <thead>
                                            <tr>
                                                <th>Ảnh</th>
                                                <th>Màu</th>
                                                <th>Chất liệu</th>
                                                <th>Size</th>
                                                <th>SKU</th>
                                                <th>Giá lẻ</th>
                                                <th>Kho</th>
                                                <th>Mặc định</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {formData.variants.map((variant, index) => (
                                                <tr key={index}>
                                                    <td>
                                                        <div className="mini-image-upload">
                                                            {variant.imageUrl ? (
                                                                <img
                                                                    src={getImageUrl(variant.imageUrl)}
                                                                    alt="Variant"
                                                                    onClick={() => document.getElementById(`v-img-${index}`).click()}
                                                                />
                                                            ) : (
                                                                <div
                                                                    className="mini-image-placeholder"
                                                                    onClick={() => document.getElementById(`v-img-${index}`).click()}
                                                                >
                                                                    <FiCamera />
                                                                </div>
                                                            )}
                                                            <input
                                                                type="file"
                                                                id={`v-img-${index}`}
                                                                style={{ display: 'none' }}
                                                                accept="image/*"
                                                                onChange={(e) => handleVariantImageUpload(index, e.target.files[0])}
                                                            />
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <input
                                                            type="text"
                                                            value={variant.color}
                                                            onChange={(e) => handleVariantChange(index, 'color', e.target.value)}
                                                            placeholder="Vd: Đỏ"
                                                        />
                                                    </td>
                                                    <td>
                                                        <input
                                                            type="text"
                                                            value={variant.material}
                                                            onChange={(e) => handleVariantChange(index, 'material', e.target.value)}
                                                            placeholder="Vd: Cotton"
                                                        />
                                                    </td>
                                                    <td>
                                                        <input
                                                            type="text"
                                                            value={variant.size}
                                                            onChange={(e) => handleVariantChange(index, 'size', e.target.value)}
                                                            placeholder="Vd: XL"
                                                        />
                                                    </td>
                                                    <td>
                                                        <input
                                                            type="text"
                                                            value={variant.sku}
                                                            onChange={(e) => handleVariantChange(index, 'sku', e.target.value)}
                                                            placeholder="SKU-001"
                                                        />
                                                    </td>
                                                    <td>
                                                        <input
                                                            type="number"
                                                            value={variant.price}
                                                            onChange={(e) => handleVariantChange(index, 'price', e.target.value)}
                                                            placeholder="Default price"
                                                        />
                                                    </td>
                                                    <td>
                                                        <input
                                                            type="number"
                                                            value={variant.stock}
                                                            onChange={(e) => handleVariantChange(index, 'stock', e.target.value)}
                                                            required
                                                        />
                                                    </td>
                                                    <td>
                                                        <input
                                                            type="radio"
                                                            name="defaultVariant"
                                                            checked={variant.isDefault}
                                                            onChange={(e) => handleVariantChange(index, 'isDefault', e.target.checked)}
                                                        />
                                                    </td>
                                                    <td>
                                                        <button
                                                            type="button"
                                                            className="text-danger"
                                                            onClick={() => handleRemoveVariant(index)}
                                                        >
                                                            <FiTrash2 />
                                                        </button>
                                                    </td>
                                                </tr>
                                            ))}
                                        </tbody>
                                    </table>
                                ) : (
                                    <div className="empty-variants">
                                        Chưa có phiên bản nào.
                                    </div>
                                )}
                                <button type="button" className="btn-secondary add-variant-btn" onClick={handleAddVariant}>
                                    <FiPlus /> Thêm phiên bản
                                </button>
                            </div>
                        </div>
                    </div>

                    <div className="form-side-section">
                        <div className="card">
                            <h3>Phân loại & Giá</h3>
                            <div className="form-group">
                                <label>Danh mục</label>
                                <MultiSelect
                                    options={categories}
                                    selectedIds={formData.categoryIds}
                                    onChange={(newSelectedIds) => setFormData({ ...formData, categoryIds: newSelectedIds })}
                                    placeholder="Chọn danh mục..."
                                />
                            </div>
                            <div className="form-group">
                                <label>Giá mặc định (VNĐ) *</label>
                                <input
                                    type="number"
                                    value={formData.price}
                                    onChange={(e) => setFormData({ ...formData, price: e.target.value })}
                                    required
                                    min="0"
                                />
                            </div>
                            <div className="form-group">
                                <label>Tổng tồn kho *</label>
                                <input
                                    type="number"
                                    value={formData.stock}
                                    onChange={(e) => setFormData({ ...formData, stock: e.target.value })}
                                    required
                                    min="0"
                                />
                            </div>
                            <div className="form-group">
                                <label>Trọng lượng (Grams) *</label>
                                <input
                                    type="number"
                                    value={formData.weight}
                                    onChange={(e) => setFormData({ ...formData, weight: e.target.value })}
                                    required
                                    min="0"
                                    placeholder="Vd: 500"
                                />
                            </div>
                            <div className="form-group">
                                <label className="checkbox-label">
                                    <input
                                        type="checkbox"
                                        checked={formData.isFeatured}
                                        onChange={(e) => setFormData({ ...formData, isFeatured: e.target.checked })}
                                    />
                                    <span>Sản phẩm nổi bật</span>
                                </label>
                            </div>
                        </div>

                        <div className="card">
                            <h3>Hình ảnh</h3>
                            <ImageUpload
                                value={formData.imageUrl}
                                onChange={(url) => setFormData({ ...formData, imageUrl: url })}
                                folder="products"
                            />
                        </div>

                        <div className="form-sticky-actions">
                            <button type="submit" className="btn-primary w-100" disabled={saving}>
                                <FiSave /> {saving ? 'Đang lưu...' : 'Lưu sản phẩm'}
                            </button>
                        </div>
                    </div>
                </div>
            </form>
        </AdminLayout>
    );
};

export default AdminProductEdit;
