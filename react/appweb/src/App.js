import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import Home from './home'; // Ensure this path is correct
import HomeNav from './HomeLayout'; // Ensure this path is correct
import About from './about';
import Services from './service';

function App() {
  return (
    <Router>
      <div className='App'>
        <HomeNav /> {/* Render the navbar on every page */}
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About/>}/>
          <Route path="/services" element={<Services/>}/>
          {/* Add more routes here as needed */}
        </Routes>
      </div>
    </Router>
  );
}

export default App;
