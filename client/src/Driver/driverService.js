import axios from 'axios';
import { urlGetTechnicalDriverDetails } from "../endpoints";

export const getUserById = async (id) => {
    try {
    //   const response = await axios.get(`${urlGetTechnicalDriverDetails}/${id}`);
          const response = await axios.get(`${urlGetTechnicalDriverDetails}/11`);
console.log("data",response.data)
      return response.data;
    } catch (error) {
      console.error('Error fetching user data:', error);
      throw error;
    }
  };
  

export const updateUser = (userId, updatedUser) => {
  return
//  axios.put(`${apiUrl}/${userId}`, updatedUser);
};