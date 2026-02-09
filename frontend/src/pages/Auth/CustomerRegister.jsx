import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';
import usePageTitle from '../../hooks/usePageTitle';
import './Auth.css';

const CustomerRegister = () => {
    const [formData, setFormData] = useState({
        name: '',
        email: '',
        password: '',
        confirmPassword: '',
        phone: '',
        address: ''
    });
    const [error, setError] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    usePageTitle('Đăng ký tài khoản');
    const { register } = useAuth();
    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError('');

        if (formData.password !== formData.confirmPassword) {
            setError('Mật khẩu xác nhận không khớp');
            return;
        }

        setIsLoading(true);

        try {
            const { confirmPassword, ...registerData } = formData;
            const result = await register(registerData);
            if (result.success) {
                navigate('/');
            } else {
                setError(result.message);
            }
        } catch (err) {
            setError('Đã xảy ra lỗi. Vui lòng thử lại.');
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="auth-container">
            <Link to="/" className="back-home-link">← Quay lại trang chủ</Link>
            <div className="auth-card">
                <div className="auth-header">
                    <h1>ĐĂNG KÝ</h1>
                    <p>Trở thành thành viên của FORMAT ngay hôm nay</p>
                </div>

                {error && <div className="error-message">{error}</div>}

                <form onSubmit={handleSubmit} className="auth-form">
                    <div className="form-group">
                        <label htmlFor="name">Họ và tên *</label>
                        <input
                            type="text"
                            id="name"
                            name="name"
                            value={formData.name}
                            onChange={handleChange}
                            placeholder="Nguyễn Văn An"
                            required
                            disabled={isLoading}
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="email">Email *</label>
                        <input
                            type="email"
                            id="email"
                            name="email"
                            value={formData.email}
                            onChange={handleChange}
                            placeholder="your@email.com"
                            required
                            disabled={isLoading}
                        />
                    </div>

                    <div className="form-row">
                        <div className="form-group">
                            <label htmlFor="password">Mật khẩu *</label>
                            <input
                                type="password"
                                id="password"
                                name="password"
                                value={formData.password}
                                onChange={handleChange}
                                placeholder="••••••••"
                                required
                                disabled={isLoading}
                                minLength="6"
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="confirmPassword">Xác nhận *</label>
                            <input
                                type="password"
                                id="confirmPassword"
                                name="confirmPassword"
                                value={formData.confirmPassword}
                                onChange={handleChange}
                                placeholder="••••••••"
                                required
                                disabled={isLoading}
                            />
                        </div>
                    </div>

                    <div className="form-group">
                        <label htmlFor="phone">Số điện thoại</label>
                        <input
                            type="tel"
                            id="phone"
                            name="phone"
                            value={formData.phone}
                            onChange={handleChange}
                            placeholder="0912 345 678"
                            disabled={isLoading}
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="address">Địa chỉ</label>
                        <textarea
                            id="address"
                            name="address"
                            value={formData.address}
                            onChange={handleChange}
                            placeholder="Số nhà, tên đường, quận/huyện..."
                            disabled={isLoading}
                            rows="2"
                        />
                    </div>

                    <button type="submit" className="btn-auth" disabled={isLoading}>
                        {isLoading ? 'ĐANG XỬ LÝ...' : 'ĐĂNG KÝ'}
                    </button>
                </form>

                <div className="auth-footer">
                    <p>Đã có tài khoản? <Link to="/login">Đăng nhập</Link></p>
                </div>
            </div>
        </div>
    );
};

export default CustomerRegister;
