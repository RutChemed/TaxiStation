import React from 'react';
import '../styles/EditManager.css';

const EditManager = () => {
    const handleEdit = () => {
        // לוגיקת עריכת פרטים 
    };

    return (
        <div className='edit-manager'>
            <h2>Editing personal details</h2>
            <button onClick={handleEdit}>Save Changes</button>
        </div>
    );
};

export default EditManager;