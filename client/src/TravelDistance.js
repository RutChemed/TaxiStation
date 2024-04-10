import React, { useState } from 'react';
import axios from 'axios';

const getLocationCoordinates = async (locationName) => {
    try {
        const response = await axios.get(`https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(locationName)}`);
        if (response.data.length > 0) {
            const { lat, lon } = response.data[0];
            return { latitude: lat, longitude: lon };
        } else {
            throw new Error('Location not found');
        }
    } catch (error) {
        console.error('Error fetching location coordinates:', error);
        return null;
    }
};

const TravelDistance = () => {

    const [origin, setOrigin] = useState('');
    const [originCoordinates, setOriginCoordinates] = useState(null);

    const [destination, setDestination] = useState('');
    const [destinationCoordinates, setDestinationCoordinates] = useState(null);

    const handleInputChange = (event, callback) => {
        if (typeof callback === 'function') {
            callback(event.target.value);
        }
    };

    const getTravelDistance = async (lat1, lon1, lat2, lon2) => {
        const url = `http://router.project-osrm.org/route/v1/driving/${lon1},${lat1};${lon2},${lat2}?overview=false`;
        
        try {
            const response = await fetch(url);
            const data = await response.json();
            
            // The distance is in meters (data.routes[0].distance)
            return data.routes[0].distance;
        } catch (error) {
            console.error('Error fetching data from OSRM:', error);
            return null;
        }
    }

    const handleSearch = async () => {
        const originCoords = await getLocationCoordinates(origin);
        const destinationCoords = await getLocationCoordinates(destination);
        getTravelDistance(originCoords.latitude, originCoords.longitude, destinationCoords.latitude, destinationCoords.longitude)
            .then(distance => {
                console.log('Travel distance in meters:', distance);
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
    

    return (
        <>
        <input
        type="text"
        placeholder="Enter Origin location name"
        value={origin}
        onChange={(event) => handleInputChange(event, setOrigin)}/>
        <br></br>                
        <input
        type="text"
        placeholder="Enter Destination location name"
        value={destination}
        onChange={(event) => handleInputChange(event, setDestination)}/>
        <button onClick={handleSearch}>Search</button>
        </>
    )
}
export default TravelDistance;