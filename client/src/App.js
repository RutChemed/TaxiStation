// import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { urlDriverTemporaryLocation } from './endpoints';
import { useEffect } from 'react';
import DriverTemporaryLocation from './DriverTemporaryLocation';

function App() { 
  return (
      <>
        <DriverTemporaryLocation></DriverTemporaryLocation>
      </>
    );
}

export default App;


