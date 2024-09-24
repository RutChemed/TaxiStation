import React from 'react';
import { Link } from 'react-router-dom';

const HomePage = () => {
  return (
    <div>
      <h1>ברוכים הבאים לאפליקציה שלנו!</h1>
      
      <h2>פונקציות ללקוחות:</h2>
      <ul>
        <li><Link to="/browse">הצג מוצרים</Link></li>
        <li><Link to="/orders">הזמנות שלי</Link></li>
        <li><Link to="/support">תמיכה</Link></li>
      </ul>

      <h2>חיבור עבור נהגים ומנהל:</h2>
      <Link to="/login">היכנס כנהג/מנהל</Link>
    </div>
  );
};

export default HomePage;