import React from 'react';
import '../styles/BookRide.css'; 

const BookRide = () => {
    const handleBooking = () => {
        // לוגיקת הזמנת הנסיעה
    };

    return (
        <div className="book-ride">
            <h2>Travel booking</h2>
            <button onClick={handleBooking}>Order now</button>
        </div>
    );
};

export default BookRide;