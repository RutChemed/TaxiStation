// src/LoginPage.js

import React, { useState } from 'react';

const LoginPage = ({ onLogin }) => {
    const [role, setRole] = useState('');

    const handleRoleChange = (e) => {
        setRole(e.target.value);
    };

    const handleLogin = () => {
        onLogin(role); // הפעל פונקציית הכניסה עם תפקיד המשתמש
    };

    return (
        <div>
            <h2>כניסת משתמש</h2>
            <select value={role} onChange={handleRoleChange}>
                <option value="">בחר תפקיד</option>
                <option value="customer">לקוח</option>
                <option value="driver">נהג</option>
                <option value="support">צוות תמיכה</option>
            </select>
            <button onClick={handleLogin}>כניסה</button>
        </div>
    );
};

export default LoginPage;