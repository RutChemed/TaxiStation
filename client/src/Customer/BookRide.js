// import React, { useState, useEffect } from 'react';
// import '../styles/BookRide.css'; 
// import { HiX } from "react-icons/hi";
// import axios from 'axios';

// function BookRide({ isOpen, onClose }) {
//     const [dateTime, setDateTime] = useState(() => {
//         const now = new Date();
//         now.setHours(now.getHours() + 2); // הוספת שעתיים
//         return now.toISOString().slice(0, 16);
//     });    
//     const [location, setLocation] = useState('');
//     const [source, setSource] = useState("");
//     const [places, setPlaces] = useState(4);
//     const [email, setEmail] = useState("");
//     const [target, setTarget] = useState("");

//     useEffect(() => {
//         if (navigator.geolocation) {
//         navigator.geolocation.getCurrentPosition(async (position) => {
//             const { latitude, longitude } = position.coords;
//             try {
//               const response = await axios.get(
//                 `https://nominatim.openstreetmap.org/reverse?format=json&lat=${latitude}&lon=${longitude}&accept-language=en`
//               );
//               const addressData = response.data.address;
//               const buildingNumber = response.data.place_rank || '';
//               const road = addressData.road || '';
//               const town = addressData.town || '';
              
//               const addressParts = [
//                 road && buildingNumber ? `${road} ${buildingNumber}` : road,
//                 town,
//               ];
              
//               setSource(addressParts.filter(Boolean).join(", "));
//             } catch (error) {
//               console.error("Error fetching address:", error);
//             }
//           });
//         } else {
//             setSource('Location not available');
//         }
//       }, []);

//   if (!isOpen) return null;

//   return (
//     <div className="modal-overlay">
//       <div className="modal-content">
//         <button className="modal-close" onClick={onClose}>
//           <HiX className="text-black text-2xl" />
//         </button>
//         <form className="modal-form">
//           <label>Travel Booking</label>
//           <label>
//             Time:
//             <input 
//               type="datetime-local" 
//               value={dateTime} 
//               onChange={(e) => setDateTime(e.target.value)} 
//               required 
//               className="input-field"
//             />
//           </label>
        
//           <label>
//             Source:
//             <input
//               placeholder="Enter source location"
//               type="text"
//               value={source}
//               onChange={(e) => setSource(e.target.value)}           
//               className="input-field"
//             />
//           </label>
//           <label>
//             Target:
//             <input 
//               type="text" 
//               placeholder="Enter target location" 
//               required 
//               className="input-field"
//             />
//           </label>
//           <label>
//             Number of Places:
//             <input 
//               type="number" 
//               min="1" 
//               required  
//               value={places}
//               onChange={(e) => setPlaces(e.target.value)} 
//               className="input-field"
//             />
//           </label>
//           {/* שדה אימייל */}
//           <label>Email</label>
//           <input
//             type="email"
//             value={email}
//             onChange={(e) => setEmail(e.target.value)}
//             placeholder="Enter your email"
//             className="input-field"
//           />
//           <div className="modal-buttons">
//             <button type="button" className="cancel-btn" onClick={onClose}>Cancel</button>
//             <button type="submit" className="send-btn" onClick={onClose}>Send</button>
//           </div>
//         </form>
//       </div>
//     </div>
//   );
// }

// export default BookRide;
import React, { useState, useEffect } from 'react';
import '../styles/BookRide.css'; 
import { HiX } from "react-icons/hi";
import axios from 'axios';

function BookRide({ isOpen, onClose }) {
    const [dateTime, setDateTime] = useState(() => {
        const now = new Date();
        now.setHours(now.getHours() + 2); // הוספת שעתיים
        return now.toISOString().slice(0, 16);
    });    
    const [location, setLocation] = useState('');
    const [source, setSource] = useState("");
    const [places, setPlaces] = useState(4);
    const [email, setEmail] = useState("");
    const [target, setTarget] = useState("");
    const [message, setMessage] = useState(""); // הוספת סטייט עבור ההודעה

    useEffect(() => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(async (position) => {
                const { latitude, longitude } = position.coords;
                try {
                    const response = await axios.get(
                        `https://nominatim.openstreetmap.org/reverse?format=json&lat=${latitude}&lon=${longitude}&accept-language=en`
                    );
                    const addressData = response.data.address;
                    const buildingNumber = response.data.place_rank || '';
                    const road = addressData.road || '';
                    const town = addressData.town || '';
                    
                    const addressParts = [
                        road && buildingNumber ? `${road} ${buildingNumber}` : road,
                        town,
                    ];
                    
                    setSource(addressParts.filter(Boolean).join(", "));
                } catch (error) {
                    console.error("Error fetching address:", error);
                }
            });
        } else {
            setSource('Location not available');
        }
    }, []);

    const handleSubmit = (e) => {
        setEmail(e)
        // e.preventDefault(); // למנוע מהטופס להישלח
        alert("A taxi is on its way to you, driver's name: Avi, phone: 0556689748"); // הוספת הודעה

        // להסתיר את ההודעה לאחר 10 שניות
        // setTimeout(() => {
        //     setMessage("");
        // }, 10000);

        // כאן תוכל להוסיף את הלוגיקה לשליחת הבקשה לשרת
        // onClose(); // סוגר את המודאל לאחר שליחת הבקשה
    };

    if (!isOpen) return null;

    return (
        <div className="modal-overlay">
            <div className="modal-content">
                <button className="modal-close" onClick={onClose}>
                    <HiX className="text-black text-2xl" />
                </button>
                <form className="modal-form" onSubmit={handleSubmit}>
                    <label>Travel Booking</label>
                    <label>
                        Time:
                        <input 
                            type="datetime-local" 
                            value={dateTime} 
                            onChange={(e) => setDateTime(e.target.value)} 
                            required 
                            className="input-field"
                        />
                    </label>
                
                    <label>
                        Source:
                        <input
                            placeholder="Enter source location"
                            type="text"
                            value={source}
                            onChange={(e) => setSource(e.target.value)}           
                            className="input-field"
                        />
                    </label>
                    <label>
                        Target:
                        <input 
                            type="text" 
                            placeholder="Enter target location" 
                            required 
                            onChange={(e) => setTarget(e.target.value)} // שמירה על ה-target
                            className="input-field"
                        />
                    </label>
                    <label>
                        Number of Places:
                        <input 
                            type="number" 
                            min="1" 
                            required  
                            value={places}
                            onChange={(e) => setPlaces(e.target.value)} 
                            className="input-field"
                        />
                    </label>
                    {/* שדה אימייל */}
                    <label>Email</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => handleSubmit(e.target.value)
                            // setEmail(e.target.value)
                        }
                        placeholder="Enter your email"
                        className="input-field"
                    />
                    <div className="modal-buttons">
                        <button type="button" className="cancel-btn" onClick={onClose}>Cancel</button>
                        <button type="submit" className="send-btn" onClick={handleSubmit}>Send</button>
                    </div>
                    {message && <div className="message">{message}</div>} {/* הצגת ההודעה */}

                </form>
                {/* {message && <div className="message">{message}</div>} הצגת ההודעה */}
            </div>
        </div>
    );
}

export default BookRide;
