using FlightService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private static List<Flight> flights = new List<Flight>
    {
        new Flight { Id = 1, FlightNumber = "AI101", Source = "Hyderabad", Destination = "Delhi" }
    };

        [HttpGet]
        public IActionResult Get() => Ok(flights);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var flight = flights.FirstOrDefault(f => f.Id == id);
            return Ok(flight);
        }

        [HttpPost]
        public IActionResult Post(Flight flight)
        {
            flights.Add(flight);
            return Ok(flight);
        }
    }
}
