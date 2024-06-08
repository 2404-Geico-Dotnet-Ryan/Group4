using Project2.DTO;
using Project2.Data;
using Project2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net.Http.Headers;

namespace Project2.Controllers
{
    [ApiController]
    [Route("controller")]

    public class TripController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TripController(AppDbContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        public ActionResult<IEnumerable<TripDTO>> GetTrips()
        {
            var trips = _context.Trips
                .Include( t=> t.Activities)
                .Select(t => new TripDTO
            {
                TripName = t.TripName,
                MaxBudget = t.MaxBudget,
                NeedsPassport = t.NeedsPassport,
                ActivityName = t.Activities.ActivityName

            }).ToList();
            return trips;
        }
        //[HttpGet("{TripId}")]

        [HttpPost]
        public async Task<ActionResult<TripDTO>> PostTrip(TripDTO tripDTO)
        {
            var activities = await _context.Activities.FirstAsync(a => a.ActivityName == tripDTO.ActivityName);

            var trip = new Trip
            {
                TripName = tripDTO.TripName,
                MaxBudget = tripDTO.MaxBudget,
                NeedsPassport = tripDTO.NeedsPassport,
                Activities = (ICollection<Activity>)activities

            };
            _context.Trips.Add(trip);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTrips), new { ProductId = trip.TripId}, tripDTO);
        }
        //[HttpPut("{TripId}")]
        //[HttpDelete("{TripId}")]
        
    }

}