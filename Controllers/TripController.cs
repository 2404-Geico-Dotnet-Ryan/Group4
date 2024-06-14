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
        public ActionResult<IEnumerable<TripDTO>> GetTrips()
        {
           var trips = _tripService.GetAllTrips();
            return Ok(trips);
        }
        [HttpGet("{tripId}")]
        public ActionResult<TripDTO> GetTripById(int tripId)
        {
           var trip = _tripService.GetTripById(tripId);
           return trip;
        }
        [Route("locations/{locationName}")]
        [HttpGet]
        public ActionResult<TripDTO> GetTripByLocation(string locationName)
        {
           var trip = _tripService.GetTripByLocation(locationName);
           return Ok(trip);
        }

        [HttpPost]
        public async Task<ActionResult<TripDTO>> PostTrip(TripDTO tripDTO)
        {
            var trip = _tripService.AddTrip(tripDTO);

            return CreatedAtAction(nameof(GetTrips), new { tripId = trip.TripId}, tripDTO);
        }
        [HttpPut("{tripId}")]
        public ActionResult<TripDTO> UpdateTrip(int tripId, TripDTO UpdatedTrip)
        {
           _tripService.UpdateTrip(tripId, UpdatedTrip);

            return Ok(UpdatedTrip);
        }
        [HttpDelete("{tripId}")]
        public IActionResult DeleteTrip(int tripId)
        {
            _tripService.DeleteTrip(tripId);

            return Ok();
        }
        
    }

}