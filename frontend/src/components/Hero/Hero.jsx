import { Link } from 'react-router-dom';
import './Hero.css';

const Hero = ({ title, subtitle, image, ctaText = "Khám phá ngay", ctaLink = "/" }) => {
    return (
        <div className="hero" style={{ backgroundImage: `url(${image})` }}>
            <div className="hero-overlay">
                <div className="hero-content">
                    {subtitle && <p className="hero-subtitle">{subtitle}</p>}
                    {title && <h2 className="hero-title">{title}</h2>}
                    {ctaText && (
                        <Link to={ctaLink} className="hero-cta btn btn-primary">
                            {ctaText}
                        </Link>
                    )}
                </div>
            </div>
        </div>
    );
};

export default Hero;
