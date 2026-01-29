import { Link } from 'react-router-dom';
import { FiFacebook, FiInstagram, FiYoutube } from 'react-icons/fi';
import './Footer.css';

const Footer = () => {
    return (
        <footer className="footer">
            <div className="container">
                <div className="footer-grid">
                    <div className="footer-column">
                        <h4 className="footer-heading">HỖ TRỢ KHÁCH HÀNG</h4>
                        <ul className="footer-links">
                            <li><Link to="/">Hướng dẫn mua hàng</Link></li>
                            <li><Link to="/">Hướng dẫn thanh toán</Link></li>
                            <li><Link to="/">Chính sách đổi trả</Link></li>
                            <li><Link to="/">Chính sách bảo mật</Link></li>
                            <li><Link to="/">Câu hỏi thường gặp</Link></li>
                        </ul>
                    </div>

                    <div className="footer-column">
                        <h4 className="footer-heading">VỀ CHÚNG TÔI</h4>
                        <ul className="footer-links">
                            <li><Link to="/">Giới thiệu</Link></li>
                            <li><Link to="/">Tuyển dụng</Link></li>
                            <li><Link to="/">Tin tức</Link></li>
                            <li><Link to="/">Hệ thống cửa hàng</Link></li>
                            <li><Link to="/">Liên hệ</Link></li>
                        </ul>
                    </div>

                    <div className="footer-column">
                        <h4 className="footer-heading">THEO DÕI CHÚNG TÔI</h4>
                        <div className="social-links">
                            <a href="https://facebook.com" target="_blank" rel="noopener noreferrer" className="social-link">
                                <FiFacebook size={24} />
                            </a>
                            <a href="https://instagram.com" target="_blank" rel="noopener noreferrer" className="social-link">
                                <FiInstagram size={24} />
                            </a>
                            <a href="https://youtube.com" target="_blank" rel="noopener noreferrer" className="social-link">
                                <FiYoutube size={24} />
                            </a>
                        </div>
                    </div>

                    <div className="footer-column">
                        <h4 className="footer-heading">ĐĂNG KÝ NHẬN THÔNG TIN</h4>
                        <p className="newsletter-text">Nhận thông tin về sản phẩm mới và ưu đãi đặc biệt</p>
                        <form className="newsletter-form">
                            <input
                                type="email"
                                placeholder="Email của bạn"
                                className="newsletter-input"
                            />
                            <button type="submit" className="newsletter-btn">XÁC NHẬN</button>
                        </form>
                    </div>
                </div>

                <div className="footer-bottom">
                    <p className="copyright">
                        © 2026 FORMAT. All rights reserved.
                    </p>
                    <div className="payment-methods">
                        <span>Phương thức thanh toán: COD | ATM | VISA | MASTERCARD</span>
                    </div>
                </div>
            </div>
        </footer>
    );
};

export default Footer;
