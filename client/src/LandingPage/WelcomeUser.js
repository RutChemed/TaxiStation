import { jwtDecode } from "jwt-decode";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { userLogin } from "../redux/actions/userLogin";

function WelcomeUser({isLoggedIn, setIsLoggedIn }) {
  const dispatch = useDispatch()
  const [welcomeIsOpen, setWelcomeIsOpen] = useState(false);
  const user = useSelector((state) => state.usersReducer); //get the user from the store
  
 
  const isLoggedInFunction = () => {
    if (user && user.token && typeof user.token === "string") {
      try {
        const decoded = jwtDecode(user.token);
        const expirationTime = decoded.exp * 1000;
        if (Date.now() < expirationTime) {
          // בדוק אם הטוקן בתוקף
          console.log( user.role);
          setWelcomeIsOpen(true);
        } else {
          dispatch(userLogin(null))
          setWelcomeIsOpen(false);
        }
      } catch (error) {
        console.error("שגיאה בפענוח האסימון:", error);
        dispatch(userLogin(null))
        setWelcomeIsOpen(false);
      }
    }
    else(setWelcomeIsOpen(false))
  };
  useEffect(isLoggedInFunction, []);
  if (isLoggedIn && welcomeIsOpen) {
    return (
      <div id="welcome">
        <h1 id="hello">Hello {user.name}</h1>
        <h3 id="role">{user.role.toLowerCase()}</h3>
      </div>
    );
  }
  return <></>;
}

export default WelcomeUser;
