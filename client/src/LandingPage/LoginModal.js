import { HiX } from "react-icons/hi";
import './LoginModal.css';
import React, { useState } from 'react';
import axios from 'axios';
import {jwtDecode} from 'jwt-decode'; 
import { urlLogin } from '../endpoints';
import { useDispatch } from "react-redux";
import { userLogin } from "../redux/actions/userLogin";
import CustomSidebar from "./CustomSidebar";

function LoginModal({ onClose,setShowReRegisterMessage ,setIsLoggedIn }) { 

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [errorMessage, setErrorMessage] = useState(''); 
  const dispatch = useDispatch();
  const handleLogin = async (event) => {
      event.preventDefault(); 
      try {
          const response = await axios.post(urlLogin, {
              email,
              password
          });
          const token = response.data.token;
          const decodedToken = jwtDecode(token);
          const userRole = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
          const userName = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
          dispatch(userLogin({token: token, role: userRole, name: userName})) 
          setShowReRegisterMessage(false);
          setIsLoggedIn(true);
          window.location.reload()
          onClose();
      } catch (error) {
          setErrorMessage('The username or password is incorrect'); 
          console.error('Login failed', error);
  };
  }
  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <button className="modal-close" onClick={onClose}>
          <div className="close-circle">
            <HiX className="close-icon" />
          </div>
        </button>
        <h2 className="modal-title">Login</h2>
        {errorMessage && <p className="error-message">{errorMessage}</p>} 
        <form className="modal-form" onSubmit={handleLogin}>
          <label htmlFor="email">Email</label>
          <input type="email" id="email" name="email" placeholder="name@company.com" value={email}
          onChange={(e) => setEmail(e.target.value)} required />
          
          <label htmlFor="password">Password</label>
          <input type="password" id="password" name="password" placeholder="Enter your password" required value={password}
          onChange={(e) => setPassword(e.target.value)} />
          
          <button type="submit" className="modal-submit-btn" >Sign In</button>
        </form>
      </div>
    </div>
  );
}


export default LoginModal;
