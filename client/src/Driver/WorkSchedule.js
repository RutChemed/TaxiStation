import React from 'react';
import '../styles/WorkSchedule.css';

const WorkSchedule = () => {
    const schedule = []; // כאן ייכנסו פרטי הנסיעות

    return (
        <div className="work-schedule">
            <h2>Work diary</h2>
            <ul>
                {schedule.map((ride, index) => (
                    <li key={index}>{ride.details}</li>
                ))}
            </ul>
        </div>
    );
};

export default WorkSchedule;