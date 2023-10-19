import React from 'react';

const Table = (props) => {
  return (
    <table className="flight-table">
      <tbody>
        <tr>
          <th>Airline</th>
          <th>Departure</th>
          <th>Destination</th>
          <th>Equipment</th>
          <th>Stops</th>
        </tr>
        {props.flights.map(flight => (
          <tr>
            <td>{flight.airline}</td>
            <td>{flight.sourceAirport}</td>
            <td>{flight.destinationAirport}</td>
            <td>{flight.equipment}</td>
            <td>{flight.stops}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default Table;
