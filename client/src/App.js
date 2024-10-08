import LandingPage from "./LandingPage/LandingPage";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Login from './components/LoginPage'; 

const App = () => {


  return (
<>
            <Router>
              <Routes>
              <Route path="/" element={<LandingPage />} /> 
                <Route path="/login" element={<Login />} />
                {/* Add more routes as needed */}
              </Routes>
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
