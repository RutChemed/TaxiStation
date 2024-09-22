import React from 'react';
import '../styles/TransferRide.css';

const TransferRide = () => {
    const handleTransfer = () => {
        // לוגיקת העברת נסיעה לנהג אחר
    };

    return (
        <div className="transfer-ride ">
            <h2>Transfer a ride</h2>
            <button onClick={handleTransfer}>Transfer</button>
        </div>
    );
};

export default TransferRide;