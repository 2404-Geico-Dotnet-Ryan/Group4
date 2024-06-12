using Project2.DTO;
using Project2.Data;
using Project2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http.Headers;
using Project2.Services;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDTO>>> GetTrips()
        {
            var trips = await _tripService.GetAllTrips();
            return trips;
        }
        [HttpGet("{Id}")]
        public ActionResult<TripDTO> GetTripById(int Id)
        {
           var trip = _tripService.GetTripById(tripId);
           return trip;
        }

        [HttpPost]
        public async Task<ActionResult<TripDTO>> PostTrip(TripDTO tripDTO)
        {
            var trip = _tripService.AddTrip(tripDTO);

            return CreatedAtAction(nameof(GetTrips), new { tripId = trip.TripId}, tripDTO);
        }
        [HttpPut("{Id}")]
        public ActionResult<TripDTO> UpdateTrip(int Id, TripDTO UpdatedTrip)
        {
           _tripService.UpdateTrip(tripId, UpdatedTrip);

            return Ok(UpdatedTrip);
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteTrip(int id)
        {
            _tripService.DeleteTrip(tripId);

            return Ok();
        }
        
    }

}