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

        //Get all saved trips in the database - passed swagger testing

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavedTripDTO>>> GetSavedTrips()
        {
            var savedTrips = await _context.SavedTrips.Select(s => new SavedTripDTO
            {
                UId = s.UId,
                TripId = s.TripId,
                UserId = s.UserId,
                Season = s.Season,
                MaxBudget = s.MaxBudget,
                NumOfTravelers = s.NumOfTravelers,
                PassportStatus = s.PassportStatus,
                ClimatePref = s.ClimatePref
            }).ToListAsync();
            return Ok(savedTrips);
        }

        //Get all the saved trips for a specific user using their user id - passed swagger testing

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<SavedTripDTO>>> GetSavedTripByUserId(int userId)
        {
            var savedTrips = await _context.SavedTrips.Where(s => s.UserId == userId).Select(s => new SavedTripDTO
            {
                UId = s.UId,
                TripId = s.TripId,
                UserId = s.UserId,
                Season = s.Season,
                MaxBudget = s.MaxBudget,
                NumOfTravelers = s.NumOfTravelers,
                PassportStatus = s.PassportStatus,
                ClimatePref = s.ClimatePref
            }).ToListAsync();
            return Ok(savedTrips);
        }

        //Add a new saved trip - passed swagger testing

        [HttpPost]
        public async Task<ActionResult<SavedTripDTO>> AddSavedTrip(SavedTripDTO savedTripDTO)
        {
            SavedTrip savedTrip = new SavedTrip
            {
                UId = savedTripDTO.UId,
                TripId = savedTripDTO.TripId,
                UserId = savedTripDTO.UserId,
                Season = savedTripDTO.Season,
                MaxBudget = savedTripDTO.MaxBudget,
                NumOfTravelers = savedTripDTO.NumOfTravelers,
                PassportStatus = savedTripDTO.PassportStatus,
                ClimatePref = savedTripDTO.ClimatePref
            };
            _context.SavedTrips.Add(savedTrip);
            await _context.SaveChangesAsync();
            return Ok(savedTripDTO);
        }

        //Delete a saved trip using the Uid (Primary Key) - passed swagger testing

        [HttpDelete("{UId}")]
        public async Task<ActionResult> DeleteSavedTrip(int UId)
        {
            var savedTrip = await _context.SavedTrips.FirstOrDefaultAsync(s => s.UId == UId);
            if (savedTrip != null)
            {
                _context.SavedTrips.Remove(savedTrip);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        //Update a specific saved trip using the Uid (Primary Key) = passed swagger testing

        [HttpPut("{UId}")]
        public async Task<ActionResult<SavedTripDTO>> UpdateSavedTrip(int UId, SavedTripDTO savedTripDTO)
        {
            var savedTrip = await _context.SavedTrips.FirstOrDefaultAsync(s => s.UId == UId);
            if (savedTrip != null)
            {
                savedTrip.TripId = savedTripDTO.TripId;
                savedTrip.UserId = savedTripDTO.UserId;
                savedTrip.Season = savedTripDTO.Season;
                savedTrip.MaxBudget = savedTripDTO.MaxBudget;
                savedTrip.NumOfTravelers = savedTripDTO.NumOfTravelers;
                savedTrip.PassportStatus = savedTripDTO.PassportStatus;
                savedTrip.ClimatePref = savedTripDTO.ClimatePref;
                await _context.SaveChangesAsync();
                return Ok(savedTripDTO);
            }
            else
            {
                return NotFound();
            }
        }




    }
}