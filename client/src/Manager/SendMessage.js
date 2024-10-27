import React, { useState } from 'react';
import axios from 'axios';
import '../styles/SendMessage.css';
import { urlSendEmail } from "../endpoints";


const SendMessage = () => {
    const [toEmails, setToEmails] = useState('');
    const [subject, setSubject] = useState('');
    const [body, setBody] = useState('');
    const [attachments, setAttachments] = useState([]);

    const handleFileChange = (e) => {
        setAttachments(e.target.files);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const formData = new FormData();

        // Split the toEmails string by commas and add it as an array
        let emailsArray = toEmails.split(',')
        .map(email => email.trim()) // מסיר רווחים מיותרים
        .filter(email => email.length > 0); // מסנן מיילים ריקים
    
    if (emailsArray.length > 0) {
        formData.append('toEmails', 
            // JSON.stringify(
                emailsArray
            // )
        ); // להוסיף רק אם יש ערכים תקינים
    } else {
        formData.append('toEmails', ''); // במקרה של קלט ריק, שלח מחרוזת ריקה
    }
    

        // const emailsArray = toEmails.split(',').map(email => email.trim());
        // formData.append('toEmails', JSON.stringify(emailsArray)); // Send as JSON string
        
        formData.append('subject', subject);
        formData.append('body', body);

        // Add attachments
        for (let i = 0; i < attachments.length; i++) {
            formData.append('attachments', attachments[i]);
        }

        try {
            const response = await axios.post(`${urlSendEmail}`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
        
            // בדיקה אם קוד הסטטוס הוא בטווח 2xx (מצביע על הצלחה)
            if (response.status >= 200 && response.status < 300) {
                alert('Email sent successfully');
            } else {
                // טיפול במקרה שהסטטוס לא מצביע על הצלחה
                alert(`Failed to send email: ${response.statusText}`);
            }
        } catch (error) {
            console.error('Error sending email:', error);
            alert('Failed to send email');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h1>Send Your Email</h1>
            <div>
                <label>To (Emails separated by commas):</label>
                <input 
                    type="text" 
                    value={toEmails} 
                    onChange={(e) => setToEmails(e.target.value)} 
                />
            </div>
    
            <div>
                <label>Subject:</label>
                <input 
                    type="text" 
                    value={subject} 
                    onChange={(e) => setSubject(e.target.value)} 
                    required 
                />
            </div>
    
            <div>
                <label>Body:</label>
                <textarea 
                    value={body} 
                    onChange={(e) => setBody(e.target.value)} 
                    required 
                />
            </div>
    
            <div>
                <label>Attachments:</label>
                <input 
                    type="file" 
                    multiple 
                    onChange={handleFileChange} 
                />
            </div>
    
            <button type="submit">Send Email</button>
        </form>
    );
};

export default SendMessage;
