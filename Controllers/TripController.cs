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
        private readonly AppDbContext _context;
        public TripController(AppDbContext context)
        {
            _context = context;
        }
        // private readonly ITripService _tripService;

        // public TripController(ITripService tripService)
        // {
        //     _tripService = tripService;
        // }

        [HttpGet]
        public ActionResult<IEnumerable<TripDTO>> GetTrips()
        {
            var trips = _context.Trips.ToList();
            return Ok(trips);
        }
        [HttpGet("{tripId}")]
        public ActionResult<Trip> GetTripById(int tripId)
        {
            var trip = _context.Trips.Find(tripId);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        [HttpPost]
        public ActionResult<Trip> AddTrip(Trip trip)
        // public async Task<ActionResult<TripDTO>> PostTrip(TripDTO tripDTO)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
            // var trip = _tripService.AddTrip(tripDTO);

            return CreatedAtAction(nameof(GetTrips), new { tripId = trip.TripId }, trip);
        }
        [HttpPut("{tripId}")]
        public ActionResult<Trip> UpdateTrip(int tripId, TripDTO tripDTO)
        {
            var trip = _context.Trips.Find(tripId);
            if (tripId != trip.TripId)
            {
                return BadRequest();
            }
            _context.Update(tripDTO);
            _context.SaveChanges();
            return Ok(tripDTO);
        }


        [HttpDelete("{TripId}")]
        public IActionResult DeleteTrip(int tripId)
        {
            var trip = _context.Trips.Find(tripId);
            if (trip == null)
            {
                return NotFound();
            }
            _context.Trips.Remove(trip);
            _context.SaveChanges();
            // _tripService.DeleteTrip(tripId);

            return Ok();
        }

    }

}