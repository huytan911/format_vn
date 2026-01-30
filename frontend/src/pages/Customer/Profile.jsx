import React, { useState, useEffect } from 'react';
import api from '../../config/axiosConfig';
import { useAuth } from '../../contexts/AuthContext';
import './Profile.css';

const Profile = () => {
    const { user } = useAuth();
    const [formData, setFormData] = useState({
        name: '',
        email: '',
        phone: '',
        address: ''
    });
    const [isLoading, setIsLoading] = useState(true);
    const [isSaving, setIsSaving] = useState(false);
    const [message, setMessage] = useState({ text: '', type: '' });

    useEffect(() => {
        fetchProfile();
    }, []);

    const fetchProfile = async () => {
        try {
            const response = await api.get('/auth/customer/profile');
            setFormData(response.data);
        } catch (error) {
            console.error('Error fetching profile:', error);
            setMessage({ text: 'Không thể tải thông tin hồ sơ', type: 'error' });
        } finally {
            setIsLoading(false);
        }
    };

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setMessage({ text: '', type: '' });
        setIsSaving(true);

        try {
            await api.put('/auth/customer/profile', formData);
            setMessage({ text: 'Cập nhật hồ sơ thành công!', type: 'success' });
        } catch (error) {
            console.error('Error updating profile:', error);
            setMessage({ text: 'Lỗi khi cập nhật hồ sơ', type: 'error' });
        } finally {
            setIsSaving(false);
        }
    };

    if (isLoading) return <div className="loading">Đang tải...</div>;

    return (
        <div className="profile-container">
            <div className="profile-card">
                <div className="profile-header">
                    <h1>Thông tin tài khoản</h1>
                    <p>Quản lý thông tin cá nhân của bạn</p>
                </div>

                {message.text && (
                    <div className={`message ${message.type}`}>
                        {message.text}
                    </div>
                )}

                <form onSubmit={handleSubmit} className="profile-form">
                    <div className="form-group">
                        <label>Họ và tên</label>
                        <input
                            type="text"
                            name="name"
                            value={formData.name}
                            onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label>Email (Không thể thay đổi)</label>
                        <input
                            type="email"
                            value={formData.email}
                            disabled
                        />
                    </div>

                    <div className="form-group">
                        <label>Số điện thoại</label>
                        <input
                            type="tel"
                            name="phone"
                            value={formData.phone}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="form-group">
                        <label>Địa chỉ nhận hàng</label>
                        <textarea
                            name="address"
                            value={formData.address}
                            onChange={handleChange}
                            rows="3"
                        />
                    </div>

                    <div className="profile-actions">
                        <button type="submit" className="btn-save" disabled={isSaving}>
                            {isSaving ? 'ĐANG LƯU...' : 'LƯU THAY ĐỔI'}
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Profile;
