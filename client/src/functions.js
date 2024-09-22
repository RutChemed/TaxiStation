import './App.css';
import axios from 'axios';
import { useEffect,useState } from 'react';


function Functions() { 

    // useEffect(() => {
  //   setDatetime(new Date().toISOString());
  // }, []);

  const [datetime, setDatetime] = useState(new Date().toISOString());

  const [order, setOrder] = useState({
    origin: '',
    destination: '',
    time: null,
    passengersNum: 0,
    clientPhone:''
  });

  const handleChange = (event) => {
    setOrder({
      ...order,
      [event.target.name]: event.target.value
    });
  };

  const handleInputChange = (e) => {
    setDatetime(e.target.value);
  };

  return (
      <>
      <h1>Order a Taxi</h1>
      <form>
      {/* // onSubmit={handleSubmit} */}
        <label>Enter origin:</label>
        <input type="text" name="origin" value={order.origin} onChange={handleChange} required />
        <br/>
        <label>Enter a destination:</label>
        <input type="text" name="destination" value={order.destination} onChange={handleChange} required />
        <br/>
        <label>The time of travel:</label>
        <input type="datetime-local" value={datetime} onChange={handleInputChange}/>
        <br/>
        <button type='submit'>order a taxi</button>
      </form>
      <br />
      </>
    );
}

export default Functions;

// 1.הזמנת נסיעה – לקוח מזין מוצא ויעד ומבקש להזמין מונית
// איך בדיוק עושים את זה?.
// 2.הרשמה - הגשת מועמדות לתפקיד נהג – הנהג משלים פרטים והטופס נשלח למנהל
// 3.כניסה – התחברות עבור הצוות. 
// לנהג יש אפשרות ל-
// 4.קבלת פרטי הנסיעה הנוכחית והעתידיות שלו
// 5.העברת הנסיעה לנהג אחר
// 6.עריכת הפרטים האישיים
// 7.עריכת הסטטוס מזמין ללא זמין
// למנהל יש אפשרות ל-
// 6.עדכון פרטים אישיים
// 8.הוספת נהג
// 9.קבלת פרטי כל הנהגים
// 6.קבלת פרטי נהג מסוים
// 10.מחיקת נהג – עדכון תאריך עזיבה
// הכנס לאזור האישי – קבלת הסטטוס של נהג מסוים
// 4.,5.,6.,7. – רק קבלת מידע ללא אפשרות עריכה 
// 11.שליחת הודעה לכל הנהגים