using CsvHelper.Configuration;
using CsvHelper;
using OpenFlights.Models;
using System.Globalization;
using Route = OpenFlights.Models.Route;

namespace OpenFlights.Services
{
    public class DataService
    {
        private readonly HttpClient _client;
        private readonly CsvConfiguration _csvConfiguration;

        public DataService()
        {
            _client = new HttpClient();

            _csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
        }

        public async Task<IList<Route>> GetRoutes()
        {
            return await GetAndParseCsv<Route>("https://raw.githubusercontent.com/jpatokal/openflights/master/data/routes.dat");
        }

        public async Task<IList<Airport>> GetAirports()
        {
            return await GetAndParseCsv<Airport>("https://raw.githubusercontent.com/jpatokal/openflights/master/data/airports.dat");
        }

        public async Task<IList<T>> GetAndParseCsv<T>(string uri)
        {
            var csvAsString = (await (await _client.GetAsync(uri)).Content.ReadAsStringAsync()).Replace("\\N", "");

            using var reader = new StringReader(csvAsString);
            using var csv = new CsvReader(reader, _csvConfiguration);
            return csv.GetRecords<T>().ToList();
        }
    }
}
