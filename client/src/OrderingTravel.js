import { urlOrderingTravel } from "./endpoints";
import React, { useState } from 'react';
import axios from 'axios';

function OrderingTravel(){

    const [dataSorted, setDataSorted] = useState(null);
    const [id, setId] = useState('');
    const [data, setData] = useState([]);
    const [errorMessage, setErrorMessage] = useState('');

    const fetchDataById = async () => {
        try {
          const response = await axios.get(`${urlOrderingTravel}/${id}`);
          // If successful, set the response data
          setDataSorted(response.data);
        } catch (error) {
          if (error.response && error.response.status === 404) {
            setErrorMessage("No item was found with the id you entered");
            setTimeout(() => {
              setErrorMessage('');
            }, 5000);
          } else {
            console.error(error);
          }
        }
    };

    const handleInputChange = (event) => {
        setId(event.target.value);
    };

    const fetchData = async () => {
        try {
        const response = await axios.get(urlOrderingTravel);
        setData(response.data);
        console.log(response.data)
        } catch (error) {
        console.error(error);
        }
    };

    return(
    //     "id": 1,
    // "startTime": "2022-04-22T10:34:23",
    // "endTime": "2022-04-22T10:34:23",
    // "exitLatitudes": "6.2",
    // "exitLongitudes": "6.3",
    // "targetLatitudes": "65.9",
    // "targetLongitudes": "6.7",
    // "passengersNum": 4,
    // "driver": 1,
    // "clientPhone": "0583232020",
    // "driverNavigation": null
        <>
        <h1>OrderingTravel</h1>
        <button onClick={fetchData}>Fetch Data</button>
            <ul>
              {data.map(item => (
              <li key={item.id}>
                  <p><strong>Start Time:</strong> {item.startTime}</p>
                  <p><strong>End Time:</strong> {item.endTime}</p>
                  <p><strong>Exit Latitudes:</strong> {item.exitLatitudes}</p>
                  <p><strong>Exit Longitudes:</strong> {item.exitLongitudes}</p>
                  <p><strong>Target Latitudes:</strong> {item.targetLatitudes}</p>
                  <p><strong>Target Longitudes:</strong> {item.targetLongitudes}</p>
                  <p><strong>Passengers Num:</strong> {item.passengersNum}</p>
                  <p><strong>Driver:</strong> {item.driver}</p>
                  <p><strong>Client Phone:</strong> {item.clientPhone}</p>
                  <p><strong>Driver Navigation:</strong> {item.driverNavigation}</p>
                  {/* <button onClick={() => handleDelete(item.id)}>Delete</button> */}
             </li>
              ))}
            </ul> 
            <br/>
            <input type="text" placeholder="Enter ID" value={id} onChange={handleInputChange} />
            <button onClick={fetchDataById}>Get Data by ID</button>
            {errorMessage && <p className="blinking">{errorMessage}</p>}
            {dataSorted && (
            <div>
              <h2>Data for ID {id}:</h2>
              {/* <p><strong>Start Time:</strong> {dataSorted.startTime}</p>
              <p><strong>End Time:</strong> {dataSorted.endTime}</p>
              <p><strong>Latitude:</strong> {dataSorted.latitudes}</p>
              <p><strong>Longitude:</strong> {dataSorted.longitudes}</p> */}
            </div>
            )}
            <br/>
        </>
    );
}
export default OrderingTravel;