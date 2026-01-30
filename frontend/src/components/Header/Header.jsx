import { Link } from 'react-router-dom';
import { FiSearch, FiShoppingBag, FiUser, FiHeart, FiLogOut } from 'react-icons/fi';
import { useAuth } from '../../contexts/AuthContext';
import { useCart } from '../../contexts/CartContext';
import { useWishlist } from '../../contexts/WishlistContext';
import './Header.css';

const Header = () => {
    const { user, logout, isAuthenticated } = useAuth();
    const { cartCount } = useCart();
    const { wishlistCount } = useWishlist();

    return (
        <header className="header">
            <div className="header-top">
                <div className="container header-content">
                    <div className="header-left">
                        <button className="icon-btn" aria-label="Search">
                            <FiSearch size={20} />
                        </button>
                    </div>

                    <Link to="/" className="logo">
                        <h1>FORMAT</h1>
                    </Link>

                    <div className="header-right">
                        <Link to="/wishlist" className="icon-btn" aria-label="Wishlist">
                            <FiHeart size={20} />
                            {wishlistCount > 0 && <span className="icon-badge">{wishlistCount}</span>}
                        </Link>
                        <Link to="/cart" className="icon-btn" aria-label="Cart">
                            <FiShoppingBag size={20} />
                            {cartCount > 0 && <span className="icon-badge">{cartCount}</span>}
                        </Link>

                        <div className="account-menu">
                            {isAuthenticated ? (
                                <div className="user-dropdown">
                                    <button className="icon-btn user-name" aria-label="Account">
                                        <FiUser size={20} />
                                        <span>{user.name}</span>
                                    </button>
                                    <div className="dropdown-content">
                                        {user.role === 'Customer' ? (
                                            <>
                                                <Link to="/profile">Tài khoản</Link>
                                                <Link to="/orders">Đơn hàng</Link>
                                            </>
                                        ) : (
                                            <Link to="/admin/products">Quản trị</Link>
                                        )}
                                        <button onClick={logout} className="logout-btn">
                                            <FiLogOut size={16} /> Đăng xuất
                                        </button>
                                    </div>
                                </div>
                            ) : (
                                <div className="auth-links">
                                    <Link to="/login" className="auth-link">ĐĂNG NHẬP</Link>
                                    <span className="divider">/</span>
                                    <Link to="/register" className="auth-link">ĐĂNG KÝ</Link>
                                </div>
                            )}
                        </div>
                    </div>
                </div>
            </div>

            <nav className="header-nav">
                <div className="container">
                    <ul className="nav-menu">
                        <li className="nav-item">
                            <Link to="/category/1" className="nav-link">NỮ</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/category/2" className="nav-link">NAM</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/category/3" className="nav-link">PHỤ KIỆN</Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/" className="nav-link">BỘ SƯU TẬP</Link>
                        </li>
                    </ul>
                </div>
            </nav>
        </header>
    );
};

export default Header;
