import React, { useState } from 'react';

const Search = (props) => {
  const [departure, setDeparture] = useState("");
  const [destination, setDestination] = useState("");

  return (
    <div>
      <h1>Welcome to Open Flights</h1>
      <input type="text" placeholder="Enter departure" disabled={props.isProcessing} value={departure} onChange={(e) => setDeparture(e.target.value)} />
      <input type="text" placeholder="Enter destination" disabled={props.isProcessing} value={destination} onChange={(e) => setDestination(e.target.value)} />
      <button onClick={()=>props.getFlightsData(departure, destination)} disabled={props.isProcessing}>SEARCH</button>
  </div>
  );
}

export default Search;
