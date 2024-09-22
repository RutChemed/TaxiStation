import React from 'react';
import '../styles/FireDriver.css';

const FireDriver = () => {
    const handleFire = () => {
        // לוגיקת פיטורין
    };

    return (
        <div className='fire-driver'>
            <h2>Dismissal</h2>
            <button onClick={handleFire}>Fire a driver</button>
        </div>
    );
};

export default FireDriver;