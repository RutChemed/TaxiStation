import React, { useState } from 'react';
import '../styles/StatusToggle.css';

const StatusToggle = () => {
    const [isAvailable, setIsAvailable] = useState(true);

    const toggleStatus = () => {
        setIsAvailable(!isAvailable);
        // הוספת לוגיקה לעדכון הסטטוס בשרת
    };

    return (
        <div className='status-toggle'>
            <h2>Driver Status</h2>
            {/* <button onClick={toggleStatus}>
                {isAvailable ? 'Busy' : 'Available'}
            </button> */}
        <label className="relative inline-flex items-center cursor-pointer">
      <input type="checkbox" value={true} className="sr-only peer" />
      <div className="peer ring-0 bg-rose-400  rounded-full outline-none duration-300 after:duration-500 w-12 h-12  shadow-md peer-checked:bg-emerald-500  peer-focus:outline-none  after:content-['\u2716\uFE0F'] after:rounded-full after:absolute after:outline-none after:h-10 after:w-10 after:bg-gray-50 after:top-1 after:left-1 after:flex after:justify-center after:items-center  peer-hover:after:scale-75 peer-checked:after:content-['\u2714\uFE0F'] after:-rotate-180 peer-checked:after:rotate-0"></div>
        </label>
        </div>
    );
};

export default StatusToggle;


