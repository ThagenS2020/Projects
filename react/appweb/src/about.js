import React from 'react';
import './about.css'; // Ensure the correct path to your CSS file
import './T-Systems.png';
import './Huawei.png';
import './absa.png';
import './adc.png'
import './eskom.png';
import './molex.png';
import './sanlam.png';
import social from './social.jpg';

function About() {
    return (
        <div className='container'>
            <div className='aboutheading'>
                <label className='aboutheadingtext'>About Us</label>
                <div>
                    <div className='aboutheadinginnerdiv'>
                        <label>Advanced Technology is a 100% Black Owned SME, specialising in Information Communication Technology (ICT) managed services. In line with our strategic objectives of market leadership and customer-centric solutions, we leverage a wealth of skills, experience and a solid track record to tailor solutions in to meet customer-specific and market requirements.</label>
                    </div>
                    <div className='aboutheadinginnerdiv'>
                        <label>Providing managed services for end user computing, ICT resourcing, project management and consultation, ICT hardware and software, and network infrastructure solutions, we have worked with some of the biggest companies in South Africa, across multiple industries and verticals.</label>
                    </div>
                </div>

            </div>
            <div className='seconddiv'>
                <label className='visiontext'>OUR VISION</label>
                <label className='abouttext'>Our Vision is to enable business through streamlined, innovative, optimised and cost-effective solutions, focusing on ICT managed services, ICT resourcing and project management, and consultation.</label>
            </div>
            <div>
                <div className="containerThree">
                    <img className='socialimage' src={social} alt="socialImage" />
                    <div className='labeldiv'>
                    <label className="labelsGrey">
                        An example of this is the End User Computing Project for the migration to Windows 7 within the Customer environment. This project provided us with the ideal platform to execute on our commitment. In the execution, we utilised engineers from the region where the services were required as opposed to utilising engineers from Gauteng. The minimum skillset for the engineers was A+ and N+ and the engineers were provided with all the training and support required to execute tasks effectively.
                    </label>
                    </div>
                    
                </div>
            </div>

            <div>
                <label className='aboutheadingtext'>We've partnered with some of the biggest brands</label>
                <div className='wrapperOne'>
                    <div className='itemclass item1'></div>
                    <div className='itemclass item2'></div>
                    <div className='itemclass item3'></div>
                    <div className='itemclass item4'></div>
                    <div className='itemclass item5'></div>
                    <div className='itemclass item6'></div>
                    <div className='itemclass item7'></div>
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

export default About;
