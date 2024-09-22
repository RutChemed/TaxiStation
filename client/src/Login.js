import React, { useState } from 'react';
import axios from 'axios';
import { urlLogin } from './endpoints';

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        try {
            const response = await axios.post(urlLogin, {
                email,
                password
            });
            localStorage.setItem('token', response.data.token);
            // Redirect or update UI after login
        } catch (error) {
            console.error('Login failed', error);
        }
    };

    return (
        <div>
            <h2>Login</h2>
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
        </div>
    );
};

export default Login;
