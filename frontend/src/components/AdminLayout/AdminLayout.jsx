import React from 'react';
import { Link, useLocation } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';
import './AdminLayout.css';

const AdminLayout = ({ children }) => {
    const location = useLocation();
    const { user, logout } = useAuth();

    const menuItems = [
        { path: '/admin/products', label: 'Sản phẩm', icon: '📦' },
        { path: '/admin/categories', label: 'Danh mục', icon: '📁' },
        { path: '/admin/customers', label: 'Khách hàng', icon: '👥' },
        { path: '/admin/orders', label: 'Đơn hàng', icon: '🛒' },
    ];

    return (
        <div className="admin-layout">
            <aside className="admin-sidebar">
                <div className="sidebar-header">
                    <h1>FORMAT.VN</h1>
                    <p>Admin Panel</p>
                </div>

                <div className="user-profile">
                    <div className="user-avatar">
                        {user?.username?.charAt(0).toUpperCase() || 'A'}
                    </div>
                    <div className="user-info">
                        <span className="username">{user?.username}</span>
                        <span className="role-badge">{user?.role}</span>
                    </div>
                </div>

                <nav className="sidebar-nav">
                    {menuItems.map(item => (
                        <Link
                            key={item.path}
                            to={item.path}
                            className={`nav-item ${location.pathname === item.path ? 'active' : ''}`}
                        >
                            <span className="nav-icon">{item.icon}</span>
                            <span className="nav-label">{item.label}</span>
                        </Link>
                    ))}

                    <button onClick={logout} className="nav-item logout-btn">
                        <span className="nav-icon">🚪</span>
                        <span className="nav-label">Đăng xuất</span>
                    </button>
                </nav>
                <div className="sidebar-footer">
                    <Link to="/" className="back-to-store">
                        ← Về trang chủ
                    </Link>
                </div>
            </aside>
            <main className="admin-main">
                <div className="admin-content">
                    {children}
                </div>
            </main>
        </div>
    );
};

export default AdminLayout;
