import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import DriverTemporaryLocation from "./DriverTemporaryLocation";
import Functions from "./functions";
import TechnicalEmployeeDetail from "./TechnicalEmployeeDetail";
import PhysicalEmployeeDetail from "./PhysicalEmployeeDetail";
import OrderingTravel from "./OrderingTravel";
import HistoryTravel from "./HistoryTravel";

function RouterComponent() {

    return (
        <div>
            <Router>
                <div>
                    <ul>
                        <li><Link to="/Functions">Order a Taxi</Link></li>
                        <li><Link to="/DriverTemporaryLocation">DriverTemporaryLocation</Link></li>
                        <li><Link to="/TechnicalEmployeeDetail">TechnicalEmployeeDetail</Link></li>
                        <li><Link to="/PhysicalEmployeeDetail">PhysicalEmployeeDetail</Link></li>
                        <li><Link to="/OrderingTravel">OrderingTravel</Link></li>
                        <li><Link to="/HistoryTravel">HistoryTravel</Link></li>
                    </ul>
                    <hr />
                <Routes>
                    <Route path="/Functions" element={<Functions />} />
                    <Route path="/DriverTemporaryLocation" element={<DriverTemporaryLocation/>} />
                    <Route path="/TechnicalEmployeeDetail" element={<TechnicalEmployeeDetail />} /> 
                    <Route path="/PhysicalEmployeeDetail" element={<PhysicalEmployeeDetail />} />
                    <Route path="/OrderingTravel" element={<OrderingTravel />} />
                    <Route path="/HistoryTravel" element={<HistoryTravel />} />
                </Routes>
                </div>
            </Router>
        </div>
    );
}
export default RouterComponent;
