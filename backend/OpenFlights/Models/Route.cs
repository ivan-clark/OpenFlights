using CsvHelper.Configuration.Attributes;

namespace OpenFlights.Models
{
    public class Route
    {
        [Index(0)]
        public string Airline { get; set; }

        [Index(1)]
        public int? AirlineId { get; set; }

        [Index(2)]
        public string SourceAirport { get; set; }

        [Index(3)]
        public int? SourceAirportId { get; set; }

        [Index(4)]
        public string DestinationAirport { get; set; }

        [Index(5)]
        public int? DestinationAirportId { get; set; }

        [Index(6)]
        public string Codeshare { get; set; }

        [Index(7)]
        public int Stops { get; set; }

        [Index(8)]
        public string Equipment { get; set; }
    }
}
