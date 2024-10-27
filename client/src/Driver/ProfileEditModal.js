import React, { useState, useEffect } from 'react';
import { getUserById, updateUser } from './driverService';
import './styles.css';
import { urlGetTechnicalDriverDetails ,urlPutTechnicalDriverDetails} from "../endpoints";
import axios from 'axios';
import { HiX } from "react-icons/hi";
import { FaUndo } from 'react-icons/fa'; // סמל איקון של Undo מ-react-icons

const ProfileEditModal = ({ userId, onClose }) => {
  const [user, setUser] = useState(null);
  const [dataSorted, setDataSorted] = useState(null);
  const [id, setId] = useState('');
  const [data, setData] = useState([]);
  const [errorMessage, setErrorMessage] = useState('');

  useEffect(() => {
    fetchDataById()
  },[])
  
  const fetchDataById = async () => {
    try {
      const response = await axios.get(`${urlGetTechnicalDriverDetails}/${userId}`);
      // If successful, set the response data
      setDataSorted(response.data);
      setUser(response.data);
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

  const handleChange = (e) => {
    const { name, value } = e.target;
    setDataSorted((prevData) => ({
        ...prevData,
        [name]: value
    }));
  };

  const restoreData = () => {
    setDataSorted(user);
  };

  const handleSave = async () => {
    const response = await axios.put(`${urlGetTechnicalDriverDetails}/${userId}`, dataSorted);
    console.log(' response:', response);

    // dataSorted;
  };

  return(
    <div className="modal">
      <div className="modal-overlay">
        <div className="modal-content">
        <div className="modal-header">
    <button type="button" className="restore-btn" onClick={restoreData}>
        <FaUndo className="restore-icon" />
    </button>
    <button className="modal-close" onClick={onClose}>
        <div className="close-circle">
            <HiX className="close-icon" />
        </div>
    </button>
</div>
{!dataSorted && (<p>Loading...</p>)}
          {dataSorted && (
          <form className="modal-form">
            <label>First Name </label>
            <input type="text" name="firstName" value={dataSorted.firstName} onChange={handleChange} />
            <label>Last Name  </label>
            <input type="text" name="lastName" value={dataSorted.lastName} onChange={handleChange} />
            <label>Phone  </label>
            <input type="text" name="phone" value={dataSorted.phone} onChange={handleChange} />
            <label>Email  </label>
            <input type="email" name="email" value={dataSorted.email} onChange={handleChange} />
            <label>Role </label>
            <input type="text" name="role" value={dataSorted.role} onChange={handleChange} />
            <button type="button" onClick={handleSave}>Save</button>
            <button type="button" onClick={onClose}>Cancel</button>
          </form>
          )}
        </div>
      </div>
    </div>
  );
}
export default ProfileEditModal;