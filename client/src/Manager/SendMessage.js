import React from 'react';
import '../styles/SendMessage.css';

const SendMessage = () => {
    const handleSend = () => {
        // לוגיקת שליחת הודעה
    };

    return (
        <div className='send-massage'>
            <h2>Send a message</h2>
            <button onClick={handleSend}>Send</button>
        </div>
    );
};

export default SendMessage;