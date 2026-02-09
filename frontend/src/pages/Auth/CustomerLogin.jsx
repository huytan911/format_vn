
import React, { useState } from 'react';
import { useNavigate, Link, useLocation } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';
import usePageTitle from '../../hooks/usePageTitle';
import './Auth.css';

const CustomerLogin = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    usePageTitle('Đăng nhập');
    const { login } = useAuth();
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError('');
        setIsLoading(true);

        try {
            const result = await login(email, password, false);
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
                    <h1>ĐĂNG NHẬP</h1>
                    <p>Chào mừng bạn quay trở lại với FORMAT</p>
                </div>

                {error && <div className="error-message">{error}</div>}

                <form onSubmit={handleSubmit} className="auth-form">
                    <div className="form-group">
                        <label htmlFor="email">Email</label>
                        <input
                            type="email"
                            id="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            placeholder="your@email.com"
                            required
                            disabled={isLoading}
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="password">Mật khẩu</label>
                        <input
                            type="password"
                            id="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            placeholder="••••••••"
                            required
                            disabled={isLoading}
                        />
                    </div>

                    <button type="submit" className="btn-auth" disabled={isLoading}>
                        {isLoading ? 'ĐANG ĐĂNG NHẬP...' : 'ĐĂNG NHẬP'}
                    </button>
                </form>

                <div className="auth-footer">
                    <p>Chưa có tài khoản? <Link to="/register">Đăng ký ngay</Link></p>
                </div>
            </div>
        </div>
    );
};

export default CustomerLogin;
