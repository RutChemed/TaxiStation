import { urlDriverTemporaryLocation } from './endpoints';
import React, { useState } from 'react';
import axios from 'axios';

function DriverTemporaryLocation() {
    const [dataSorted, setDataSorted] = useState(null);
    const [id, setId] = useState('');
    const [data, setData] = useState([]);

    const [postData, setPostData] = useState({
        startTime: '',
        endTime: '',
        latitudes: '',
        longitudes: ''
      });
    
      const handleChange = (event) => {
        setPostData({
          ...postData,
          [event.target.name]: event.target.value
        });
      };
    
      const handleSubmit = async (event) => {
        event.preventDefault();
        try {
          const response = await axios.post(urlDriverTemporaryLocation, postData);
          console.log('New object created:', response.data);
        } catch (error) {
          console.error(error);
        }
      };
  
    const fetchDataById = async () => {
      try {
        const response = await axios.get(`${urlDriverTemporaryLocation}/${id}`);
        setDataSorted(response.data);
      } catch (error) {
        console.error(error);
      }
    };
  
    const handleInputChange = (event) => {
      setId(event.target.value);
    };

    const fetchData = async () => {
        try {
        const response = await axios.get(urlDriverTemporaryLocation);
        setData(response.data);
        } catch (error) {
        console.error(error);
        }
    };

    const handleDelete = async (id) => {
        try {
          await axios.delete(`${urlDriverTemporaryLocation}/${id}`);
        //   setData(null);
        //   setId('');
        } catch (error) {
          console.error(error);
        }
      };

    return (
        <div>
         <button onClick={fetchData}>Fetch Data</button>

         <ul>
             {data.map(item => (
            <li key={item.id}>
                <p><strong>Start Time:</strong> {item.startTime}</p>
                <p><strong>End Time:</strong> {item.endTime}</p>
                <p><strong>Latitude:</strong> {item.latitudes}</p>
                <p><strong>Longitude:</strong> {item.longitudes}</p>
                <button onClick={() => handleDelete(item.id)}>Delete</button>
            </li>
            ))}
        </ul>
        <br/>
            <input type="text" placeholder="Enter ID" value={id} onChange={handleInputChange} />
            <button onClick={fetchDataById}>Get Data by ID</button>
            {dataSorted && (
            <div>
                <h2>Data for ID {id}:</h2>
                <p><strong>Start Time:</strong> {dataSorted.startTime}</p>
                <p><strong>End Time:</strong> {dataSorted.endTime}</p>
                <p><strong>Latitude:</strong> {dataSorted.latitudes}</p>
                <p><strong>Longitude:</strong> {dataSorted.longitudes}</p>
            </div>
            )}
            <br/>
            <div>
            <h2>Create a new object</h2>
            <form onSubmit={handleSubmit}>
                <label>Start Time: </label>
                <input type="text" name="startTime" value={postData.startTime} onChange={handleChange} />
                <br />
                <label>End Time: </label>
                <input type="text" name="endTime" value={postData.endTime} onChange={handleChange} />
                <br />
                <label>Latitude: </label>
                <input type="text" name="latitudes" value={postData.latitudes} onChange={handleChange} />
                <br />
                <label>Longitude: </label>
                <input type="text" name="longitudes" value={postData.longitudes} onChange={handleChange} />
                <br />
                <button type="submit">Create Object</button>
            </form>
            </div>
        </div>
    );
}

export default DriverTemporaryLocation;