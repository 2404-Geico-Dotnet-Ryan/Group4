using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project2.Data;
using Project2.Models;
using Project2.DTO;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class SavedTripController : ControllerBase
    {
        private readonly AppDbContext _context; //this is used to interact with our database 

        public SavedTripController(AppDbContext context) //this is the constructor for the saved trip controller
        {
            _context = context;
        }

        [HttpPost] //Post is used to add a saved trip
        public ActionResult<SavedTrip> AddSavedTrip(SavedTrip savedTrip)
        {
            _context.SavedTrips.Add(savedTrip);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSavedTripById), new { tripId = savedTrip.TripId }, savedTrip);
        }

        [HttpGet] //Get is used to get a list of saved trips - all trips
        public ActionResult<IEnumerable<SavedTripDTO>> GetSavedTrips()
        {
            var savedTrips = _context.SavedTrips.ToList();
            return Ok(savedTrips);
        }

        [HttpGet("{tripId}")] //Get is used to get a saved trip by id - only 1 specific trip
        public ActionResult<SavedTrip> GetSavedTripById(int tripId)
        {
            var savedTrip = _context.SavedTrips.Find(tripId);
            if (savedTrip == null)
            {
                return NotFound();
            }
            return Ok(savedTrip);
        }

        [HttpPut("{tripId}")]
        public ActionResult<SavedTrip> UpdateSavedTrip(int tripId, SavedTrip updatedSavedTrip)
        {
            if (tripId != updatedSavedTrip.TripId)
            {
                return BadRequest();
            }
            _context.Entry(updatedSavedTrip).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{tripId}")]
        public ActionResult<SavedTrip> DeleteSavedTrip(int tripId)
        {
            var savedTrip = _context.SavedTrips.Find(tripId);
            if (savedTrip == null)
            {
                return NotFound();
            }
            _context.SavedTrips.Remove(savedTrip);
            _context.SaveChanges();
            return NoContent();
        }
    }
}