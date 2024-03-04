import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { urlWeather } from './endpoints';
import { useEffect } from 'react';

function App() {
  useEffect(()=>{
    axios.get(urlWeather).then((response)=>{
      console.log(response.data);}
    )
  },[])  
  return (
    <>
<p>hi</p>
    </>
  );
}

export default App;
// import { useEffect } from 'react';
// import './App.css';
// import {urlWeather} from './endpoints';
// import axios,{AxiosResponse} from 'axios';

// function App() {

//   useEffect(() => {
//     axios.get(urlWeather).then((response: AxiosResponse<any>) => {
//       // axios.get(urlWeather).then((response) => {
//       console.log(response.data);
//     })
//   },[])