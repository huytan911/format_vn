import { Link } from 'react-router-dom';
import { FiSearch, FiShoppingBag, FiUser, FiHeart } from 'react-icons/fi';
import './Header.css';

const Header = () => {
    return (
        <header className="header">
            <div className="header-top">
                <div className="container">
                    <div className="header-content">
                        <div className="header-left">
                            <button className="icon-btn" aria-label="Search">
                                <FiSearch size={20} />
                            </button>
                        </div>

                        <Link to="/" className="logo">
                            <h1>FORMAT</h1>
                        </Link>

                        <div className="header-right">
                            <button className="icon-btn" aria-label="Wishlist">
                                <FiHeart size={20} />
                            </button>
                            <button className="icon-btn" aria-label="Shopping Cart">
                                <FiShoppingBag size={20} />
                            </button>
                            <button className="icon-btn" aria-label="Account">
                                <FiUser size={20} />
                            </button>
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
