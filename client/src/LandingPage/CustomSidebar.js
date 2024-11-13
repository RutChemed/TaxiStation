import React, { useState, useEffect } from 'react';
import { Sidebar as FlowbiteSidebar, TextInput, Label, Textarea, Button } from "flowbite-react";
import { HiMail, HiInformationCircle, HiLogin, HiLogout, HiSearch, HiPaperClip, HiX, HiChat, HiUserRemove, HiUserAdd, HiUserGroup, HiPencilAlt } from "react-icons/hi";
import { RiSendPlaneFill } from "react-icons/ri";
import { Link } from "react-router-dom"; 
import { jwtDecode } from 'jwt-decode'; 
import './LandingStyle.css';
import LoginModal from './LoginModal'; 
import ProfileEditModal from '../Driver/ProfileEditModal';
import DriverStatusToggle from '../Driver/StatusToggle';
import { useDispatch, useSelector } from 'react-redux';
import { userLogin } from '../redux/actions/userLogin';



function CustomSidebar({ showContactForm, onContactFormToggle, onClose, setIsLoggedIn ,isLoggedIn}) {
  const [isLoginModalOpen, setIsLoginModalOpen] = useState(false);
  const [role, setRole] = useState(null);
  const [showReRegisterMessage, setShowReRegisterMessage] = useState(false);
  // const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [isEditProfileModalOpen, setIsEditProfileModalOpen] = useState(false);
  const [userId, setUserId] = useState('');
  const [showStatusToggle, setShowStatusToggle] = useState(false);
  const user = useSelector((state) => state.usersReducer);//get the user from the store
  const dispatch = useDispatch();

  useEffect(() => {
    
    if (user && user.token && typeof user.token === 'string') {
      try {
        const decoded = jwtDecode(user.token);
        const expirationTime = decoded.exp * 1000; 
        if(Date.now() < expirationTime) { // בדוק אם הטוקן בתוקף
          setIsLoggedIn(true); // אם הטוקן בתוקף, לעדכן את הסטייט
          const userRole = user.userRole;
          setRole(userRole);
          const userId = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
          console.log('User ID:', userId);
          setUserId(userId);

        } else {
          setShowReRegisterMessage(true); 
        }
      } catch (error) {
        console.error('שגיאה בפענוח האסימון:', error);
        localStorage.removeItem('token'); 
        setShowReRegisterMessage(true);
      }
    } else {
      setShowReRegisterMessage(true); 
    }
  }, []);

  const toggleStatusDisplay = () => {
    setShowStatusToggle(!showStatusToggle);
  };

  const toggleLoginModal = () => {
    setIsLoginModalOpen(!isLoginModalOpen);
  };

  const toggleEditProfileModal = () => {
    setIsEditProfileModalOpen(!isEditProfileModalOpen);
  };

  const handleLogout = () => {
    setRole(null); 
    dispatch(userLogin(null));
    setIsLoggedIn(false); // עדכון הסטייט לאחר יציאה
  };

  return (
    <FlowbiteSidebar aria-label="Sidebar" className="sidebar">
      <div className="sidebar-header">
        <div className="flex-grow"></div>
        <button onClick={onClose} className="sidebar-button">
          <HiX className="text-black text-2xl" />
        </button>
      </div>
      <div className="flex flex-col justify-between py-2">
        <form className="pb-3 md:hidden">
          <TextInput icon={HiSearch} type="search" placeholder="Search" required size={32} />
        </form>
        
        {showReRegisterMessage && (
          <div className="reRegisterMessage">
            Log in again
          </div>
        )}
              <FlowbiteSidebar.Items>
          <FlowbiteSidebar.ItemGroup>
            {!isLoggedIn && (
              <FlowbiteSidebar.Item onClick={() => setIsLoginModalOpen(true)} icon={HiLogin}>
                <div className="flex items-center cursor-pointer">
                  Sign in
                </div>
              </FlowbiteSidebar.Item>
            )}

            {role === 'Manager' && (
              <>
                <FlowbiteSidebar.Item icon={HiChat}>
                  <Link to="/sendMessage">Send Message</Link>
                </FlowbiteSidebar.Item>
                <FlowbiteSidebar.Item icon={HiUserRemove}>
                  <Link to="/fireDriver">Fire Driver</Link>
                </FlowbiteSidebar.Item>
                <FlowbiteSidebar.Item icon={HiPencilAlt}>
                  <Link to="/EditManager">Edit Manager</Link>
                </FlowbiteSidebar.Item>
                <FlowbiteSidebar.Item icon={HiUserGroup}>
                  <Link to="/driversInfo">Drivers Info</Link>
                </FlowbiteSidebar.Item>
                <FlowbiteSidebar.Item icon={HiUserAdd}>
                  <Link to="/addDriver">Add Driver</Link>
                </FlowbiteSidebar.Item>
              </>
            )}

            {role === 'Driver' && (
              <>
                  <FlowbiteSidebar.Item icon={HiChat} onClick={toggleStatusDisplay}>
                <div className="flex items-center cursor-pointer">
              Driver Status
              </div>
                </FlowbiteSidebar.Item>
                {showStatusToggle && <DriverStatusToggle userId={userId}/>}

                  <FlowbiteSidebar.Item onClick={() => setIsEditProfileModalOpen(true)} icon={HiUserRemove}>
                  Edit Profile
                </FlowbiteSidebar.Item>
                <FlowbiteSidebar.Item icon={HiPencilAlt}>
                  <Link to="/transfer-ride">Transfer Ride</Link>
                </FlowbiteSidebar.Item>
                <FlowbiteSidebar.Item icon={HiUserGroup}>
                  <Link to="/work-schedule">Work Schedule</Link>
                </FlowbiteSidebar.Item>
                <FlowbiteSidebar.Item icon={HiUserAdd}>
                  <Link to="/dashboard">Dashboard</Link>
                </FlowbiteSidebar.Item>
              </>
            )}

            <FlowbiteSidebar.Item href="https://github.com/themesberg/flowbite-react/issues" icon={HiInformationCircle}>
              Help
            </FlowbiteSidebar.Item>
            <FlowbiteSidebar.Item href="#" icon={HiLogout} onClick={handleLogout}>
              Sign out
            </FlowbiteSidebar.Item>
            <FlowbiteSidebar.Item href="#" icon={HiMail} onClick={onContactFormToggle}>
              Contact Us
            </FlowbiteSidebar.Item>
          </FlowbiteSidebar.ItemGroup>
        </FlowbiteSidebar.Items>

        {showContactForm && (
          <form action="#" className="mail_form">
            <div className="mb-6 mt-3">
              <Label htmlFor="email" className="mb-2 block">Your email</Label>
              <TextInput id="email" name="email" placeholder="name@company.com" type="email" />
            </div>
            <div className="mb-6">
              <Label htmlFor="subject" className="mb-2 block">Subject</Label>
              <TextInput id="subject" name="subject" placeholder="Let us know how we can help you" />
            </div>
            <div className="mb-6">
              <Label htmlFor="message" className="mb-2 block">Your message</Label>
              <Textarea id="message" name="message" placeholder="Your message..." rows={4} />
            </div>
            <div className="mb-6 flex items-center">
              <input 
                type="file" 
                id="file" 
                name="file" 
                accept="image/*,application/pdf" 
                className="hidden" 
              />
              <label htmlFor="file">
                <Button className="flex items-center" icon={HiPaperClip}>
                </Button>
              </label>
            </div>
            <div>
              <Button type="submit" className="mail-btn" icon={RiSendPlaneFill}>send</Button>
            </div>
          </form>
        )}
      </div>

      {isLoginModalOpen && <LoginModal onClose={toggleLoginModal} setShowReRegisterMessage={setShowReRegisterMessage} setIsLoggedIn={setIsLoggedIn}/>} 
      {isEditProfileModalOpen && <ProfileEditModal userId={userId} onClose={toggleEditProfileModal} />}
    </FlowbiteSidebar>
  );
}

export default CustomSidebar;
