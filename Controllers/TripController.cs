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
        [HttpGet("{TripId}")]
        public ActionResult<TripDTO> GetTripById(int Id)
        {
           var trip = _tripService.GetTripById(Id);
           return trip;
        }

        [HttpPost]
        public async Task<ActionResult<TripDTO>> PostTrip(TripDTO tripDTO)
        {
            var trip = _tripService.AddTrip(tripDTO);

            return CreatedAtAction(nameof(GetTrips), new { TripId = trip.Id}, tripDTO);
        }
        [HttpPut("{TripId}")]
        public ActionResult<TripDTO> UpdateTrip(int Id, TripDTO UpdatedTrip)
        {
           _tripService.UpdateTrip(Id, UpdatedTrip);

            return Ok(UpdatedTrip);
        }
        [HttpDelete("{TripId}")]
        public IActionResult DeleteTrip(int id)
        {
            _tripService.DeleteTrip(id);

            return Ok();
        }
        
    }

}