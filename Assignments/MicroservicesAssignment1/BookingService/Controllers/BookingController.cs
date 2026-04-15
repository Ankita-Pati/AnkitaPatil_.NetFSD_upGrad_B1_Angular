using BookingService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private static List<Booking> bookings = new List<Booking>();

        [HttpGet]
        public IActionResult Get() => Ok(bookings);

        [HttpPost]
        public IActionResult Post(Booking booking)
        {
            bookings.Add(booking);
            return Ok(booking);
        }
    }
}
