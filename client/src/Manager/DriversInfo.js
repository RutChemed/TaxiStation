import React from 'react';
import '../styles/DriversInfo.css';

const DriversInfo = () => {
    const drivers = []; // כאן ייכנסו פרטי הנהגים

    return (
        <div className='driver-info'>
            <h2>Driver details</h2>
            <ul>
                {drivers.map((driver, index) => (
                    <li key={index}>{driver.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default DriversInfo;