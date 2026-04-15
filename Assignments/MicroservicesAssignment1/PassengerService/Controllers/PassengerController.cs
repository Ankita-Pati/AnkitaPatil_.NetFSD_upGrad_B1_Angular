using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassengerService.Model;

namespace PassengerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private static List<Passenger> passengers = new List<Passenger>();

        [HttpGet]
        public IActionResult Get() => Ok(passengers);

        [HttpPost]
        public IActionResult Post(Passenger passenger)
        {
            passengers.Add(passenger);
            return Ok(passenger);
        }
    }
}
