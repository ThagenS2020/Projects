import React from 'react';
import '../src/StyleSheet.css'; // Adjust the path based on your actual file structure
import { Link } from 'react-router-dom'; // Import Link for routing
import gif from './6bafd77fd2633aa0b469df9cef31c6b8.gif';
import app from './APP.png';
import about from './about.gif';
import aboutpage from './about';
import service from './services.gif';
import career from './career.gif';

function HomePage() {
    return (
        <div>
            <div className="background-image">
                <img className="logo" src={app} alt="Logo" />
                <label className="labelTitle">Advanced Technology</label>
            </div>
            <div className="containerlabel">
                <label className="labels">
                    Our skilled software development team delivers innovative solutions that exceed expectations. We offer customized solutions, from custom systems to cloud-based options.
                </label>
                <label className="labelsTwo">
                    Our team works collaboratively with clients to understand their unique needs and deliver reliable, scalable, and user-friendly solutions. We are committed to staying ahead of the curve by keeping up with the latest technologies and industry best practices.
                </label>
            </div>
            <div className="container-wrapper">
                <div className="containerGif">
                    <img src={gif} alt="Animated Gif" />
                </div>
                <div className="containerThree">
                    <label className="labelsGrey">
                        We understand the benefits of cloud computing and the impact it can have on businesses of all sizes. That’s why we offer a range of cloud services, including migration, infrastructure management, and more. Our team of experts can help you navigate the complexities of the cloud and develop a customized solution that meets your unique needs.
                    </label>
                </div>
            </div>
            <div className="partnerdiv">
            <label className="partner">MORE ABOUT ADVANCED PROJECTS AND PEOPLE</label>
            </div>
            <div className="container-wrapperTwo">
                <div className="hoverDiv">
                    <img className="iconImages" src={about} alt="About Gif" />
                    <Link to="/about" className="buttonSlideLink">
                        <button className="buttonSlide">ABOUT</button>
                    </Link>
                </div>
                <div className="hoverDiv">
                    <img className="iconImages" src={service} alt="Services Gif" />
                    <button className="buttonSlide">SERVICES</button>
                </div>
                <div className="hoverDiv">
                    <img className="iconImages" src={career} alt="Career Gif" />
                    <button className="buttonSlide">CAREER</button>
                </div>
            </div> 
            <div className="footer">
                <label className="footertext">We have presence in all of the 9 provinces in South Africa and beyond.</label>
                <label className="footertextTwo">Embracing empowerment initiatives, Advanced Technology is a devoted BBBEE level 1 contributor</label>
                <label className="footertextThree">Copyright © 2024 Advanced Technology</label>
            </div>
        </div>
    );
}

export default HomePage;
