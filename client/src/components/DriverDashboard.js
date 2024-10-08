
import React from 'react';
import { Link } from 'react-router-dom';

const DriverDashboard = () => {
    return (
        <nav className="navbar">
            <ul className="flex space-x-4">
                <li>
                    <Link to="/dashboard">Dashboard</Link>
                </li>
                <li>
                    <Link to="/work-schedule">Work Schedule</Link>
                </li>
                <li>
                    <Link to="/transfer-ride">Transfer Ride</Link>
                </li>
                <li>
                    <Link to="/edit-profile">Edit Profile</Link>
                </li>
                <li>
                    <Link to="/status-toggle">Driver Status</Link>
                </li>
            </ul>
        </nav>
    );
};

export default DriverDashboard;
