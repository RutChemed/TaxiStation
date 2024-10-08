import React, { useState } from 'react';
import axios from 'axios';
import {jwtDecode} from 'jwt-decode'; // הייבוא הנכון
import { urlLogin } from '../endpoints';

const LoginPage = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [role, setRole] = useState(null); // שמירת ה-role

    const handleLogin = async () => {
        try {
            const response = await axios.post(urlLogin, {
                email,
                password
            });
            
            // שמירת הטוקן ב-localStorage
            const token = response.data.token;
            localStorage.setItem('token', token);

            // פענוח הטוקן
            const decodedToken = jwtDecode(token); // שימוש נכון ב-jwtDecode

            // שמירת ה-role מהטוקן
            setRole(decodedToken.role);
            console.log("Welcome, Driver       !",decodedToken.role);

            // הפניית המשתמש לפי ה-role
            if (decodedToken.role === 'manager') {
                // הפניה לדף המנהל
                console.log("Welcome, Manager!");
                // Perform redirect or UI update
            } else if (decodedToken.role === 'Driver') {
                // הפניה לדף הנהג
                console.log("Welcome, Driver!");
                // Perform redirect or UI update
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

            {role && <p>Logged in as: {role}</p>} {/* הצגת ה-role */}
        </div>
    );
};

export default LoginPage;
