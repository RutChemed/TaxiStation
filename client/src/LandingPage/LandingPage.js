import React, {useState} from 'react';
import './LandingStyle.css';
import { Drawer } from "flowbite-react";
import Header from './Header';
import CustomSidebar from './CustomSidebar';
import { FaRegComments } from 'react-icons/fa'; 
import WelcomeUser from './WelcomeUser';
import { useDispatch, useSelector } from 'react-redux';
import HelpChatBot from './HelpChatBot';

function LandingPage() {
  const user = useSelector((state) => state.userReducer);
  const dispatch = useDispatch();
  const [isChatBotOpen, setIsChatBotOpen] = useState(false);
  const [isOpen, setIsOpen] = useState(false);
  const [showContactForm, setShowContactForm] = useState(false); 
  const [role, setRole] = useState(null);


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
      <WelcomeUser isOpen={false}/>
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
          showContactForm={showContactForm} 
          onContactFormToggle={
            () => setShowContactForm(!showContactForm)} onClose={handleClose} />      
        </Drawer>
        {isChatBotOpen && <HelpChatBot onClose={() => setIsChatBotOpen(!isChatBotOpen)}/>} 
      
    </div>
  );
}

export default LandingPage;