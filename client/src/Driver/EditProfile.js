import React from 'react';
import '../styles/EditProfile.css';

const EditProfile = () => {
    const handleEdit = () => {
        // לוגיקת עריכת פרטים אישיים
    };

    return (
        <div className="edit-profile">
            <h2>Edit personal details</h2>
            <button onClick={handleEdit}>Save Changes</button>
        </div>
    );
};

export default EditProfile;