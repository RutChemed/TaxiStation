// import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { urlDriverTemporaryLocation } from './endpoints';
import { useEffect } from 'react';
import DriverTemporaryLocation from './DriverTemporaryLocation';
import BookRide from './Customer/BookRide';
import ApplyDriver from './Customer/ApplyDriver';
import WorkSchedule from './Driver/WorkSchedule';
import TransferRide from './Driver/TransferRide';
import EditProfile from './Driver/EditProfile';
import StatusToggle from './Driver/StatusToggle';
import EditManager from './Manager/EditManager';
import AddDriver from './Manager/AddDriver';
import DriversInfo from './Manager/DriversInfo';
import FireDriver from './Manager/FireDriver';
import SendMessage from './Manager/SendMessage';

function App() { 
  return (
      <>
        {/* <DriverTemporaryLocation></DriverTemporaryLocation> */}
        <div className="app-container">
            <h1>Taxi Station</h1>
            <div className="components-container">
                <BookRide />
                <ApplyDriver />
                <WorkSchedule />
                <TransferRide />
                <EditProfile />
                <StatusToggle />
                <EditManager />
                <AddDriver />
                <DriversInfo />
                <FireDriver />
                <SendMessage />
            </div>
        </div>
      </>
    );
}

export default App;
// import React, { useState } from 'react';
// import axios from 'axios';
// import { getDistance } from 'geolib';
// import { getPreciseDistance } from 'geolib';
// import { MapComponent } from './MapComponent';

// const getLocationCoordinates = async (locationName) => {
//     try {
//         const response = await axios.get(`https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(locationName)}`);
//         if (response.data.length > 0) {
//             const { lat, lon } = response.data[0];
//             return { latitude: lat, longitude: lon };
//         } else {
//             throw new Error('Location not found');
//         }
//     } catch (error) {
//         console.error('Error fetching location coordinates:', error);
//         return null;
//     }
// };

// const Mix = () => {

//     const [origin, setOrigin] = useState('');
//     const [originCoordinates, setOriginCoordinates] = useState(null);

//     const [destination, setDestination] = useState('');
//     const [destinationCoordinates, setDestinationCoordinates] = useState(null);

//     const handleInputChange = (event, callback) => {
//         if (typeof callback === 'function') {
//             callback(event.target.value);
//         }
//     };

//     // const calculatePreciseDistance = (coordinates1, coordinates2) => {
//     // const pdis = getPreciseDistance(coordinates1, coordinates2);
//     // alert(`Precise Distance\n\n${pdis} Meter\nOR\n${pdis / 1000} KM`);
//     // };

//     // const handleSearch = async () => {
//     //     const originCoords = await getLocationCoordinates(origin);
//     //     const destinationCoords = await getLocationCoordinates(destination);
//     //     calculatePreciseDistance(originCoords,destinationCoords);
//     // };
//     const getTravelDistance = async (lat1, lon1, lat2, lon2) => {
// // 
//     // }
//     // async function getTravelDistance(lat1, lon1, lat2, lon2) {
//         const url = `http://router.project-osrm.org/route/v1/driving/${lon1},${lat1};${lon2},${lat2}?overview=false`;
        
//         try {
//             const response = await fetch(url);
//             const data = await response.json();
            
//             // The distance is in meters (data.routes[0].distance)
//             return data.routes[0].distance;
//         } catch (error) {
//             console.error('Error fetching data from OSRM:', error);
//             return null;
//         }
//     }
    
//     // Example usage:
//     // const lat1 = 40.7128; // Latitude of point 1
//     // const lon1 = -74.006; // Longitude of point 1
//     // const lat2 = 34.0522; // Latitude of point 2
//     // const lon2 = -118.2437; // Longitude of point 2
//     const handleSearch = async () => {
//         const originCoords = await getLocationCoordinates(origin);
//         const destinationCoords = await getLocationCoordinates(destination);
//         // getTravelDistance(lat1, lon1, lat2, lon2)
//         getTravelDistance(originCoords.latitude, originCoords.longitude, destinationCoords.latitude, destinationCoords.longitude)
//             .then(distance => {
//                 console.log('Travel distance in meters:', distance/1000);
//             })
//             .catch(error => {
//                 console.error('Error:', error);
//             });
//     }
    

//     return (
//         <>
//         <input
//         type="text"
//         placeholder="Enter Origin location name"
//         value={origin}
//         onChange={(event) => handleInputChange(event, setOrigin)}/>
//         <br></br>                
//         <input
//         type="text"
//         placeholder="Enter Destination location name"
//         value={destination}
//         onChange={(event) => handleInputChange(event, setDestination)}/>
//         <button onClick={handleSearch}>Search</button>
//         </>
//     )
// }
// export default Mix;

