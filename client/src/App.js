import React, { useState } from 'react';
import LandingPage from "./LandingPage/LandingPage";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import WorkSchedule from './Driver/WorkSchedule';
import TransferRide from './Driver/TransferRide';
// import EditProfile from './Driver/EditProfile';
import StatusToggle from './Driver/StatusToggle';
import SendMessage from './Manager/SendMessage'
import FireDriver from './Manager/FireDriver'
import EditManager from './Manager/EditManager'
import DriversInfo from './Manager/DriversInfo'
import AddDriver from './Manager/AddDriver'
import HelpChatBot from './LandingPage/HelpChatBot';

const App = () => {

  const [isLoggedIn, setIsLoggedIn] = useState(false); 
  const [userRole, setUserRole] = useState(""); 

    const handleLogin = (role) => {
        setIsLoggedIn(true);
        setUserRole(role); 
    };


  return (
      <>
            <Router>
              <div>
              <Routes>
                <Route path="/" element={<LandingPage />} /> 
                <Route path="/work-schedule" element={<WorkSchedule />} />
                <Route path="/transfer-ride" element={<TransferRide />} />
                {/* <Route path="/edit-profile" element={<EditProfile />} /> */}
                <Route path="/status-toggle" element={<StatusToggle />} />
                <Route path="/sendMessage" element={<SendMessage />} />
                <Route path="/fireDriver" element={<FireDriver />} />
                <Route path="/editManager" element={<EditManager />} />
                <Route path="/driversInfo" element={<DriversInfo />} />
                <Route path="/addDriver" element={<AddDriver />} />
              </Routes>
              </div>
            </Router> 
                  {/* <LandingPage></LandingPage> */}
                     {/* <BookRide />
                   <ApplyDriver />
                    <WorkSchedule />
                   <TransferRide />
                     <EditProfile />
                     <StatusToggle />
                    <EditManager />
                    <AddDriver />
                    <DriversInfo />
                    <FireDriver />
                     <SendMessage />
                   <Schedule /> */}
</>
  );
};

export default App;
