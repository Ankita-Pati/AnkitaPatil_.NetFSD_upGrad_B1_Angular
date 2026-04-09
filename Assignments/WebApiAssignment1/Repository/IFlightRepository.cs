using WebApiAssignment1.Models;

namespace WebApiAssignment1.Repository
{
    public interface IFlightRepository
    {
        void AddFlight(Flight flight);
        Flight GetFlight(int id);
        List<Flight> GetAllFlights();
        void EditFlight(Flight flight);
        void DeleteFlight(int id);
    }
}
