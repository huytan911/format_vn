import React, { useState, useEffect } from 'react';
import api from '../../config/axiosConfig';
import { getImageUrl } from '../../utils/imageUrl';
import './ImageUpload.css';

const ImageUpload = ({ value, onChange, folder = 'general' }) => {
    const [mode, setMode] = useState(value && !value.startsWith('/uploads/') ? 'link' : 'upload');
    const [uploading, setUploading] = useState(false);
    const [preview, setPreview] = useState(value);

    // Sync preview with value from parent
    useEffect(() => {
        setPreview(value);
    }, [value]);

    const handleFileChange = async (e) => {
        const file = e.target.files[0];
        if (!file) return;

        // Preview locally immediately
        const reader = new FileReader();
        reader.onloadend = () => {
            setPreview(reader.result);
        };
        reader.readAsDataURL(file);

        // Upload to server
        const formData = new FormData();
        formData.append('file', file);

        setUploading(true);
        try {
            const response = await api.post(`/upload?folder=${folder}`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            const imageUrl = response.data.url;
            onChange(imageUrl);
        } catch (error) {
            console.error('Upload failed:', error);
            alert('Lỗi khi tải ảnh lên');
            setPreview(value); // Rollback preview on error
        } finally {
            setUploading(false);
        }
    };

    const handleUrlChange = (e) => {
        const url = e.target.value;
        setPreview(url);
        onChange(url);
    };

    return (
        <div className="image-upload-container">
            <div className="image-upload-modes">
                <button
                    type="button"
                    className={`mode-btn ${mode === 'upload' ? 'active' : ''}`}
                    onClick={() => setMode('upload')}
                >
                    Tải ảnh lên
                </button>
                <button
                    type="button"
                    className={`mode-btn ${mode === 'link' ? 'active' : ''}`}
                    onClick={() => setMode('link')}
                >
                    Link ảnh
                </button>
            </div>

            <div className="image-upload-content">
                {mode === 'upload' ? (
                    <div className="file-input-wrapper">
                        <input
                            type="file"
                            accept="image/*"
                            onChange={handleFileChange}
                            id="file-upload"
                            className="hidden-input"
                        />
                        <label htmlFor="file-upload" className="file-label">
                            {uploading ? 'Đang tải lên...' : 'Chọn ảnh từ máy tính'}
                        </label>
                    </div>
                ) : (
                    <input
                        type="url"
                        value={mode === 'link' ? value || '' : ''}
                        onChange={handleUrlChange}
                        placeholder="https://example.com/image.jpg"
                        className="url-input"
                    />
                )}
            </div>

            {preview && (
                <div className="image-preview">
                    <img src={getImageUrl(preview)} alt="Preview" />
                    <button
                        type="button"
                        className="remove-preview"
                        onClick={() => {
                            setPreview(null);
                            onChange('');
                        }}
                    >
                        &times;
                    </button>
                </div>
            )}
        </div>
    );
};

export default ImageUpload;
