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
    [Route("[controller]")]

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
                .Include(t => t.TravelType)
                .Include(t => t.Climate)
                .Include(t => t.Location)
                .Select(t => new TripDTO
            {
                TripName = t.TripName,
                MaxBudget = t.MaxBudget,
                NeedsPassport = t.NeedsPassport,
               ActivityName = t.Activities.ActivityName, //need to figure out how to get ActivityName to work
                LocationName = t.Location.LocationName,
                ClimateType = t.Climate.ClimateType,
                TravelTypeName = t.TravelType.TravelTypeName


            }).ToList();
            return trips;
        }
        [HttpGet("{TripId}")]
        public ActionResult<TripDTO> GetTripById(int Id)
        {
            var trip = _context.Trips.Find(Id);
            var tripDTO = new TripDTO{
                TripName = trip.TripName,
                TripId = trip.Id,
                MaxBudget = trip.MaxBudget,
                NeedsPassport = trip.NeedsPassport,
                ActivityName = ICollection<Activity>.Activities, //need to figure out how to do this
                LocationName = trip.Location.LocationName,
                ClimateType = trip.Climate.ClimateType,
                TravelTypeName = trip.TravelType.TravelTypeName

            };
            return tripDTO;
        }

        [HttpPost]
        public async Task<ActionResult<TripDTO>> PostTrip(TripDTO tripDTO)
        {
            var activities =  _context.Activities.Where(a => tripDTO.ActivityName.Contains(a.ActivityName)).ToList();
            var location =  _context.Locations.FirstOrDefault(l => l.LocationName == tripDTO.LocationName);
            var climate =  _context.Climates.FirstOrDefault(c => c.ClimateType == tripDTO.ClimateType);
            var travelType =  _context.TravelTypes.FirstOrDefault(t => t.TravelTypeName == tripDTO.TravelTypeName);


            var trip = new Trip
            {
                TripName = tripDTO.TripName,
                MaxBudget = tripDTO.MaxBudget,
                NeedsPassport = tripDTO.NeedsPassport,
                Activities = activities,
                Location = location,
                Climate = climate,
                TravelType = travelType

            };
            _context.Trips.Add(trip);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTrips), new { ProductId = trip.Id}, tripDTO);
        }
        [HttpPut("{TripId}")]
        public ActionResult<TripDTO> UpdateTrip(int Id, TripDTO UpdatedTrip)
        {
            var trip = _context.Trips.Include(t => t.Location)
                .Include(t => t.Climate) 
                .Include(t => t.TravelType)
                .Include(t => t.Activities)
                .FirstOrDefault(t => t.Id == Id);
            var location = _context.Locations.FirstOrDefault(l => l.LocationName == UpdatedTrip.LocationName);   
            var climate = _context.Climates.FirstOrDefault(c => c.ClimateType == UpdatedTrip.ClimateType);
            var travelType = _context.TravelTypes.FirstOrDefault(t => t.TravelTypeName == UpdatedTrip.TravelTypeName);
            var activities = _context.Activities.Where(a => UpdatedTrip.ActivityName.Contains(a.ActivityName)).ToList();

            trip.TripName = UpdatedTrip.TripName;
            trip.MaxBudget = UpdatedTrip.MaxBudget;
            trip.NeedsPassport = UpdatedTrip.NeedsPassport;
            trip.Activities = activities;
            trip.Location = location;
            trip.Climate = climate;
            trip.TravelType = travelType;


            _context.Trips.Update(trip);
            _context.SaveChanges();

            return Ok(UpdatedTrip);
        }
        [HttpDelete("{TripId}")]
        public IActionResult DeleteTrip(int id)
        {
            var trip = _context.Trips.Find(id);
            _context.Trips.Remove(trip);
            _context.SaveChanges();

            return Ok();
        }
        
    }

}