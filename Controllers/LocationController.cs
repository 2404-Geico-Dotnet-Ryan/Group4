using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Project2.Data;
using Project2.Models;
using Project2.Services;
using Project2.DTO;
using Microsoft.Identity.Client;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LocationController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LocationController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult<Location> AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLocationById), new { locationId = location.LocationId}, location);
        }
        [HttpGet]
        public ActionResult<IEnumerable<LocationDTO>> GetLocations()
        {
            var locations = _context.Locations.ToList();
            return Ok(locations);
        }
        [HttpGet("{locationId}")]
        public ActionResult<Location> GetLocationById(int locationId)
        {
            var location = _context.Locations.Find(locationId);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(locationId);
        }
       
        [HttpPut("{locationId}")]
        public ActionResult<Location> UpdatedLocation(int locationId, Location updatedLocation)
        {
            if (locationId != updatedLocation.LocationId)
            {
                return BadRequest();
            }
            _context.Update(updatedLocation);
            _context.SaveChanges();
            return updatedLocation;
        }
        [HttpDelete("{locationId}")]
        public ActionResult<Location> DeleteLocation(int locationId)
        {
            var location = _context.Locations.Find(locationId);
            if (location == null)
            {
                return NotFound();
            }
            _context.Locations.Remove(location);
            _context.SaveChanges();
            return NoContent();
        }
    }

}