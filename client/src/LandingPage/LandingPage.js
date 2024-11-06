import React, { useEffect, useState } from "react";
import "./LandingStyle.css";
import { Drawer } from "flowbite-react";
import Header from "./Header";
import CustomSidebar from "./CustomSidebar";
import { FaRegComments } from "react-icons/fa";
import { jwtDecode } from "jwt-decode";

function LandingPage() {
  const [isOpen, setIsOpen] = useState(false);
  const [showContactForm, setShowContactForm] = useState(false);
  const [userName, setUserName] = useState(null);
  const [role, setRole] = useState(null);

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
          setRole(userRole);
          const userName =
            decoded[
              "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
            ];
          setUserName(userName);
        }
      } catch (error) {
        console.error("שגיאה בפענוח האסימון:", error);
        localStorage.removeItem("token");
      }
    }
  }, []);
  const handleClose = () => {
    setIsOpen(false);
    setShowContactForm(false);
  };

  const handleDrawerToggle = () => {
    setIsOpen(!isOpen);
  };

  return (
    <div className="landing-page">
      <Header isOpen={isOpen} onDrawerToggle={handleDrawerToggle} />
      {userName && (
        <div id="welcome">
          <h1 id="hello">Hello {userName}</h1>
          <h3 id="role">{role.toLowerCase()}</h3>
        </div>
      )}

      <section className="features">
        <ul>
          <li>Taxis available within minutes</li>
          <li>24H service</li>
          <li>Real time taxi tracking</li>
        </ul>
      </section>

      <footer className="footer">
        <FaRegComments className="chat-icon" />
        <a
          href="https://yourchatlink.com"
          target="_blank"
          rel="noopener noreferrer"
        >
          Online support chat
        </a>
      </footer>

      <Drawer open={isOpen} onClose={handleClose}>
        <CustomSidebar
          role={role}
          setRole={setRole}
          showContactForm={showContactForm}
          onContactFormToggle={() => setShowContactForm(!showContactForm)}
          onClose={handleClose}
        />{" "}
      </Drawer>
    </div>
  );
}

export default LandingPage;
