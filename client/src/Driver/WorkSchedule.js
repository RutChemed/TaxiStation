import React from 'react';
import '../styles/WorkSchedule.css';
import HistoryTravel from '../HistoryTravel'; 
import OrderingTravel from '../OrderingTravel'; 



const WorkSchedule = () => {
    const schedule = []; // כאן ייכנסו פרטי הנסיעות

    return (
        <div>
        <div className="work-schedule">
            <h2>Work diary</h2>
            <ul>
                {schedule.map((ride, index) => (
                    <li key={index}>{ride.details}</li>
                ))}
            </ul>
        </div>
        <HistoryTravel></HistoryTravel>
        <OrderingTravel></OrderingTravel>
        </div>

    );
};

export default WorkSchedule;