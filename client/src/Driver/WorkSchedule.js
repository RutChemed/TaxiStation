import '../styles/WorkSchedule.css';
import HistoryTravel from '../HistoryTravel'; 
import OrderingTravel from '../OrderingTravel'; 
import React, { useState, useEffect } from 'react';
import axios from 'axios';
// import Calendar from 'react-calendar';
// import 'react-calendar/dist/Calendar.css'; 
import { urlOrderingTravel } from "../endpoints";
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';


const localizer = momentLocalizer(moment);


const WorkSchedule = () => {
    const [data, setData] = useState([]);
    const [value, setValue] = useState(new Date()); // התאריך הנבחר
    const [events, setEvents] = useState([]); // האירועים בתאריך הנבחר

    const fetchData = async () => {
        try {
            const response = await axios.get(urlOrderingTravel);
            setData(response.data);
            console.log(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    // כאשר הנתונים נטענים, נעדכן את האירועים לפי התאריך
    useEffect(() => {
        fetchData();
    }, []);

    useEffect(() => {
        // המרת הנתונים לפורמט שניתן לשימוש בלוח שנה
        const formattedEvents = data.map(item => ({
            id: item.id,
            title: item.subject, // נושא האירוע
            start: new Date(item.startTime), // תאריך ושעת ההתחלה
            end: new Date(item.endTime), // תאריך ושעת הסיום
            exitLatitudes:item.exitLatitudes,
            exitLongitudes:item.exitLongitudes,
            targetLatitudes:item.targetLatitudes,
            targetLongitudes:item.targetLongitudes,
            passengersNum:item.passengersNum,
            driver:item.driver,
            clientPhone:item.clientPhone,
            driverNavigation:item.driverNavigation
        }));
        setEvents(formattedEvents);
    }, [data]);

    const handleSelectEvent = (event) => {
        alert(`Event: ${event.title}\nStart: ${event.start}\nEnd: ${event.end}`);
        // כאן תוכל להוסיף לוגיקה כדי להציג את פרטי האירוע במודאל אם תרצה
    };

    const handleDateChange = (date) => {
        setValue(date);
    };

    const handleSelectSlot = ({ start, end }) => {
        const title = window.prompt('New Event name');
        if (title) {
            setEvents(prevEvents => [
                ...prevEvents,
                {
                    start,
                    end,
                    title,
                    id: prevEvents.length + 1,
                },
            ]);
        }
    };

    return (
        <div>
        <Calendar
            localizer={localizer}
            events={events}
            startAccessor="start"
            endAccessor="end"
            style={{ height: 600, margin: "50px" }}
            views={['month', 'week', 'day']} // אפשרויות תצוגה
            defaultView="month" // ברירת מחדל
            onSelectEvent={handleSelectEvent} // פונקציה בלחיצה על אירוע
            selectable // אפשרות לבחור תאריכים
        />
    </div>

    
        // <div>
        //     <h1>Event Calendar</h1>
        //     <Calendar
        //         onChange={handleDateChange}
        //         value={value}
        //     />
        //     <h2>Events for {value.toDateString()}</h2>
        //     <ul>
        //         {events.length > 0 ? (
        //             events.map(item => (
        //                 <li key={item.id}>
        //                     <p><strong>Start Time:</strong> {item.startTime}</p>
        //           <p><strong>End Time:</strong> {item.endTime}</p>
        //           <p><strong>Exit Latitudes:</strong> {item.exitLatitudes}</p>
        //           <p><strong>Exit Longitudes:</strong> {item.exitLongitudes}</p>
        //           <p><strong>Target Latitudes:</strong> {item.targetLatitudes}</p>
        //           <p><strong>Target Longitudes:</strong> {item.targetLongitudes}</p>
        //           <p><strong>Passengers Num:</strong> {item.passengersNum}</p>
        //           <p><strong>Driver:</strong> {item.driver}</p>
        //           <p><strong>Client Phone:</strong> {item.clientPhone}</p>
        //           <p><strong>Driver Navigation:</strong> {item.driverNavigation}</p>
        //                     {/* הוסף כאן שדות נוספים כרצוי */}
        //                 </li>
        //             ))
        //         ) : (
        //             <p>No events found for this date.</p>
        //         )}
        //     </ul>
        //          <OrderingTravel></OrderingTravel>

        // </div>
    );
};


//     const schedule = []; // כאן ייכנסו פרטי הנסיעות

//     return (
//         <div>
//         <div className="work-schedule">
//             <h2>Work diary</h2>
//             <ul>
//                 {schedule.map((ride, index) => (
//                     <li key={index}>{ride.details}</li>
//                 ))}
//             </ul>
//         </div>
//         <HistoryTravel></HistoryTravel>
//         <OrderingTravel></OrderingTravel>
//         </div>

//     );
// };

export default WorkSchedule;
