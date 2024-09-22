import React, { useState } from 'react';
import '../styles/StatusToggle.css';

const StatusToggle = () => {
    const [isAvailable, setIsAvailable] = useState(true);

    const toggleStatus = () => {
        setIsAvailable(!isAvailable);
        // הוספת לוגיקה לעדכון הסטטוס בשרת
    };

    return (
        <div className='status-toggle'>
            <h2>Driver Status</h2>
            <button onClick={toggleStatus}>
                {isAvailable ? 'Busy' : 'Available'}
            </button>
            <label class="switch">
                <input type="checkbox" checked></input>
            <span class="slider round"></span>
            </label>

        </div>
    );
};

export default StatusToggle;