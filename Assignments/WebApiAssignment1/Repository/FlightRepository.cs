using WebApiAssignment1.Models;

namespace WebApiAssignment1.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private static List<Flight> flights = new List<Flight>();

        public void AddFlight(Flight flight)
        {
            flight.Id = flights.Count + 1;
            flights.Add(flight);
        }

        public Flight GetFlight(int id)
        {
            return flights.FirstOrDefault(f => f.Id == id);
        }

        public List<Flight> GetAllFlights()
        {
            return flights;
        }

        public void EditFlight(Flight flight)
        {
            var existing = flights.FirstOrDefault(f => f.Id == flight.Id);
            if (existing != null)
            {
                existing.FlightCode = flight.FlightCode;
                existing.Seat = flight.Seat;
                existing.FlightType = flight.FlightType;
                existing.Company = flight.Company;
            }
        }

        public void DeleteFlight(int id)
        {
            var flight = flights.FirstOrDefault(f => f.Id == id);
            if (flight != null)
            {
                flights.Remove(flight);
            }
        }
    }
}
