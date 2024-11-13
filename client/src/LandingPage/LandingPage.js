import React, {useState} from 'react';
import './LandingStyle.css';
import { Drawer } from "flowbite-react";
import Header from './Header';
import CustomSidebar from './CustomSidebar';
import { FaRegComments } from 'react-icons/fa'; 
import WelcomeUser from './WelcomeUser';
import HelpChatBot from './HelpChatBot';

function LandingPage() {  
  const [isChatBotOpen, setIsChatBotOpen] = useState(false);
  const [isOpen, setIsOpen] = useState(false);
  const [showContactForm, setShowContactForm] = useState(false); 
  const[isLoggedIn, setIsLoggedIn] = useState(false)
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
      <WelcomeUser isLoggedIn = {isLoggedIn} setIsLoggedIn = {setIsLoggedIn}/>
      <section className="features">
        <ul>
          <li>Taxis available within minutes</li>
          <li>24H service</li>
          <li>Real time taxi tracking</li>
        </ul>
      </section>

      <footer className="footer" onClick={() => setIsChatBotOpen(true)}>
        <FaRegComments className="chat-icon" />
        <p target="_blank" rel="noopener noreferrer">
          Online support chat
        </p>
      </footer>

      <Drawer open={isOpen} onClose={handleClose}>
        <CustomSidebar 
          isLoggedIn={isLoggedIn}
          setIsLoggedIn = {setIsLoggedIn}
          showContactForm={showContactForm} 
          onContactFormToggle={
            () => setShowContactForm(!showContactForm)} onClose={handleClose} />      
        </Drawer>
        {isChatBotOpen && <HelpChatBot onClose={() => setIsChatBotOpen(!isChatBotOpen)}/>} 
      
    </div>
  );
}

export default LandingPage;