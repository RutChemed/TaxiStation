import React, { useState, useEffect } from 'react';
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import './Schedule.css'; // קובץ CSS מותאם ללוח שנה

const localizer = momentLocalizer(moment);

const Schedule = ({ events }) => {
  const [myEvents, setMyEvents] = useState([]);

  useEffect(() => {
    // הפוך את אירועי הנסיעות שלך לפורמט התואם ללוח השנה
    const formattedEvents = events.map(event => ({
      id: event.Id,
      title: `נסיעה ל-${event.TargetLatitudes}, ${event.TargetLongitudes}`,
      start: new Date(event.StartTime),
      end: new Date(event.EndTime),
    }));
    setMyEvents(formattedEvents);
  }, [events]);

  const handleSelectEvent = (event) => {
    alert(`נבחר אירוע: ${event.title}`);
  };

  const handleSelectSlot = ({ start, end }) => {
    const title = window.prompt('נא להזין את שם האירוע:');
    if (title) {
      setMyEvents(prevEvents => [
        ...prevEvents,
        {
          start,
          end,
          title,
        },
      ]);
    }
  };

  return (
    <div className="schedule">
      <Calendar
        localizer={localizer}
        events={myEvents}
        startAccessor="start"
        endAccessor="end"
        style={{ height: 500, margin: "50px" }}
        onSelectEvent={handleSelectEvent}
        onSelectSlot={handleSelectSlot}
        selectable
      />
    </div>
  );
};

export default Schedule;