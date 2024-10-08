import React, { useState } from 'react';
import './LandingStyle.css';
import { Drawer } from "flowbite-react";
import Header from './Header';
import CustomSidebar from './CustomSidebar';
import { FaRegComments } from 'react-icons/fa'; 

function LandingPage() {
  const [isOpen, setIsOpen] = useState(false);
  const [showContactForm, setShowContactForm] = useState(false); 

  const handleClose = () => {
    setIsOpen(false); 
    setShowContactForm(false); 
  };

  const handleDrawerToggle = () => {
    setIsOpen(!isOpen);
  };

  return (
    <div className="landing-page">
      <Header isOpen={isOpen} onDrawerToggle={handleDrawerToggle} />
      
      <section className="features">
        <ul>
          <li>Taxis available within minutes</li>
          <li>24H service</li>
          <li>Real time taxi tracking</li>
        </ul>
      </section>

      <footer className="footer">
        <FaRegComments className="chat-icon" />
        <a href="https://yourchatlink.com" target="_blank" rel="noopener noreferrer">
          Online support chat
        </a>
      </footer>

      <Drawer open={isOpen} onClose={handleClose}>
      <CustomSidebar showContactForm={showContactForm} onContactFormToggle={() => setShowContactForm(!showContactForm)} onClose={handleClose} />      </Drawer>
    </div>
  );
}

export default LandingPage;