import React, { useState } from 'react';
import axios from 'axios';
import {jwtDecode} from 'jwt-decode'; 
import { urlLogin } from '../endpoints';
import { useNavigate } from 'react-router-dom'; 

const LoginPage = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [role, setRole] = useState(null); 
    const navigate = useNavigate(); 

    const handleLogin = async () => {
        try {
            const response = await axios.post(urlLogin, {
                email,
                password
            });

            const token = response.data.token;
            localStorage.setItem('token', token);
            
            const decodedToken = jwtDecode(token);
            const userRole = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

            setRole(userRole);

            if (userRole === 'Manager') {
                navigate('/manager-dashboard'); 
            } else if (userRole === 'Driver') {
                navigate('/driver-dashboard'); 
            }
        } catch (error) {
            console.error('Login failed', error);
        }
    };

    return (
        <div>
            <input
                type="text"
                placeholder="Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />
            <input
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <button onClick={handleLogin}>Login</button>

            {role && <p>Logged in as: {role}</p>} 
        </div>
    );
};

export default LoginPage;
