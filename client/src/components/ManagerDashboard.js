import React from 'react';
import { Link } from 'react-router-dom';

const ManagerDashboard = () => {
    return (
        <nav className="navbar">
            <ul className="flex space-x-4">
                <li>
                    <Link to="/sendMessage">Send Message</Link>
                </li>
                <li>
                    <Link to="/fireDriver">Fire Driver</Link>
                </li>
                <li>
                    <Link to="/EditManager">Edit Manager</Link>
                </li>
                <li>
                    <Link to="/driversInfo">Drivers Info</Link>
                </li>
                <li>
                    <Link to="/addDriver">Add Driver</Link>
                </li>
            </ul>
        </nav>
    );
};

export default ManagerDashboard;
