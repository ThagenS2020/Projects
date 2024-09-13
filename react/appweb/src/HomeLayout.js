import React from 'react';
import { Link } from 'react-router-dom'; // Import Link for routing
import './StyleSheetNav.css'; // Ensure the CSS file is located in the same directory
import logo from './APP.png'
import about from './about';

// If using FontAwesome directly in the component (ensure it's imported globally in index.html if not using this approach)
// import '@fortawesome/fontawesome-free/css/all.min.css';

const Topbar = () => {
    return (
        <div className="topbar">
            <img className="logoNav" src={logo} alt="Animated Gif" />
            <div className="menu">
                <Link to="/" className="menuItem">Home</Link>
                <Link to="/about" className="menuItem">About Us</Link>
                <Link to="/services" className="menuItem">Services</Link>
                <a href="#" className="menuItem">Career</a>
                <a href="#" className="menuItem">Our approach</a>
                <a href="#" className="menuItem">Store</a>
                <button className="ctaButton">Contact Us</button>
            </div>
        </div>
    );
};

export default Topbar;
