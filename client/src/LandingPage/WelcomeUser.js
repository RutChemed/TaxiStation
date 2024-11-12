import { jwtDecode } from "jwt-decode";
import { useEffect, useState } from "react";

function WelcomeUser() {
    const[welcomeIsOpen, setWelcomeIsOpen] = useState(false)

    useEffect(() => {
        const token = localStorage.getItem("token"); // הבאת הטוקן מ-localStorage
        if (token && typeof token === "string") {
          try {
            const decoded = jwtDecode(token);
            const expirationTime = decoded.exp * 1000;
            if (Date.now() < expirationTime) {
              // בדוק אם הטוקן בתוקף
              const userRole =
                decoded[
                  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                ];
                console.log(decoded)
                localStorage.setItem('userRole', userRole);
              const userName =
                decoded[
                  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
                ];
                localStorage.setItem('userName', userName);
                setWelcomeIsOpen(true);
            }
            else{
                localStorage.removeItem("token");
                setWelcomeIsOpen(false);
            }
          } catch (error) {
            console.error("שגיאה בפענוח האסימון:", error);
            localStorage.removeItem("token");
            setWelcomeIsOpen(false);
          }
        }
      }, []);
  
    return (
        <div id="welcome" isOpen = {welcomeIsOpen}>
          <h1 id="hello">Hello {localStorage.getItem('userName')}</h1>
          <h3 id="role">{localStorage.getItem('userRole').toLowerCase()}</h3>
        </div>
    );
  }
  
  export default WelcomeUser;
  