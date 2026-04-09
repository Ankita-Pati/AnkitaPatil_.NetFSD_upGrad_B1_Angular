using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssignment1.Models;
using WebApiAssignment1.Repository;

namespace WebApiAssignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _repo;

        public FlightController(IFlightRepository repo)
        {
            _repo = repo;
        }

        // GET: api/flight/getall
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var flights = _repo.GetAllFlights();
            return Ok(flights);
        }

        // GET: api/flight/get/1
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var flight = _repo.GetFlight(id);
            if (flight == null)
                return NotFound();

            return Ok(flight);
        }

        // POST: api/flight/add
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Flight flight)
        {
            _repo.AddFlight(flight);
            return Ok("Flight Added");
        }

        // PUT: api/flight/edit
        [HttpPut("Edit")]
        public IActionResult Edit([FromBody] Flight flight)
        {
            _repo.EditFlight(flight);
            return Ok("Flight Updated");
        }

        // DELETE: api/flight/delete/1
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _repo.DeleteFlight(id);
            return Ok("Flight Deleted");
        }
    }
}
