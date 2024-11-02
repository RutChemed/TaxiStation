import React, { useState, useEffect } from 'react';
import '../styles/StatusToggle.css';
import { urlPutPhysicalDriverDetails , urlGetPhysicalDriverDetailsByEmployee} from "../endpoints";
import axios from 'axios';

const StatusToggle = ({ userId }) => {

  const [dataSorted, setDataSorted] = useState({available: true,
    employee
    : 
    3,
    id
    : 
    11,
    latitudes
    : 
    0,
    longitudes
    : 
    0,
    numPlaces
    : 
    0});
  const [driverStatus, setDriverStatus] = useState(false);

  useEffect(() => {
    const fetchDriverStatus = async () => {
      try {
        const response = await axios.get(`${urlGetPhysicalDriverDetailsByEmployee}/${userId}`);
        if(response){
            setDataSorted(response.data);
            console.log("dataSorted",dataSorted);
            // setDriverStatus(response.data.available);
            // console.error(response);
        }
        // setDataSorted(response.data);
        // setDriverStatus(response.data.available);
        // console.error(response);
        console.log("dataSorted",dataSorted);

      } 
    //   catch (error) {
        // console.error('שגיאה בטעינת הסטטוס:', error);
        catch (error) {
            console.error('שגיאה בטעינת :', error.message);
            console.error(error.response ? error.response.data : error); // מדפיס תוספים מהתגובות אם קיימות
        }
      
    };
    fetchDriverStatus();
  }, []);

  const handleStatusToggle = async () => {
    const newStatus = !driverStatus;
    setDriverStatus(newStatus);
    setDataSorted((prevData) => ({
        ...prevData,
        ["Available"]: newStatus
    }));
    try {
        const response = await axios.put(`${urlPutPhysicalDriverDetails}/${userId}`, dataSorted);
      } 
      catch (error) {
        setDriverStatus(!newStatus);
      }
    }
  ;
  
console.log("dataSorted----",dataSorted.available);
  return (
<>
<input className="toggle" type="checkbox" checked={!dataSorted.available} onChange={handleStatusToggle}/>
</> 
  );
}

export default StatusToggle;
