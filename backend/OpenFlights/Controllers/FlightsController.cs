using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenFlights.Services;

namespace OpenFlights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly DataService _dataService;

        public FlightsController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<List<Models.Route>> GetFlightsAsync(string? departureAirport=null, string? destinationAirport=null)
        {
            var routes = await _dataService.GetRoutes();
            var airports = await _dataService.GetAirports();
            var flights = routes;

            if (!string.IsNullOrEmpty(departureAirport))
            {
                flights = flights.Where(route =>
                    airports.Any(airport => airport.Iata == departureAirport && airport.Id == route.SourceAirportId)
                ).ToList();
            }

            if (!string.IsNullOrEmpty(destinationAirport))
            {
                flights = flights.Where(route =>
                    airports.Any(airport => airport.Iata == destinationAirport && airport.Id == route.DestinationAirportId)
                ).ToList();
            }

            return flights.ToList();
        }
    }
}
