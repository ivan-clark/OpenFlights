import React, { useState } from 'react';
import axios from 'axios';
import CircularProgress from '@mui/material/CircularProgress';
import Search from "./components/Search"
import Table from "./components/Table"

const App = () => {
  const [flights, setFlights] = useState([]);
  const [isProcessing, setIsProcessing] = useState(false);

  const getFlightsData = (departure, destination) => {
    setFlights([]);
    setIsProcessing(true);
    axios.get(`https://localhost:7216/api/Flights?departureAirport=${departure}&destinationAirport=${destination}`)
    .then(function (response) {
      setIsProcessing(false);
      setFlights(response.data);
    })
  };

  return (
    <>
      <Search getFlightsData={getFlightsData} isProcessing={isProcessing}/>
      <Table flights={flights}/>
      {isProcessing && <CircularProgress />}
    </>
  );
}

export default App;
