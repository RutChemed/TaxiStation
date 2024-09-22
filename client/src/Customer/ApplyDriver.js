import React from 'react';
import '../styles/ApplyDriver.css';

const ApplyDriver = () => {
    const handleApplication = () => {
        // לוגיקת הגשת מועמדות
    };

    return (
        <div className="apply-driver">
            <h2>Apply for a driver position</h2>
            <button onClick={handleApplication}>Apply</button>
        </div>
    );
};

export default ApplyDriver;