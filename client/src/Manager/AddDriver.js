import React from 'react';
import '../styles/AddDriver.css';

const AddDriver = () => {
    const handleAddDriver = () => {
        // לוגיקת הוספת נהג
    };

    return (
        <div className='add-driver'>
            <h2>Add a driver</h2>
            <button onClick={handleAddDriver}>Add</button>
        </div>
    );
};

export default AddDriver;