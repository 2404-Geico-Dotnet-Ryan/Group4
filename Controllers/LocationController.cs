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
        // private readonly AppDbContext _context;
        // public LocationController(AppDbContext context)
        // {
        //     _context = context;
        // }
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpPost]
        public ActionResult<Location> AddLocation(LocationDTO locationDTO)
        {
            // _context.Locations.Add(location);
            // _context.SaveChanges();
            var locations = _locationService.AddLocation(locationDTO);
            return CreatedAtAction(nameof(GetLocationById), new { locationId = locationDTO.LocationId}, locationDTO);
        }
        [HttpGet]
        public ActionResult<IEnumerable<LocationDTO>> GetLocations()
        {
            // var locations = _context.Locations.ToList();
            var locations = _locationService.GetAllLocations();
            return Ok(locations);
        }
        [HttpGet("{locationId}")]
        public ActionResult<Location> GetLocationById(int locationId)
        {
            // var location = _context.Locations.Find(locationId);
            var location = _locationService.GetLocationById(locationId);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }
       
        [HttpPut("{locationId}")]
        public ActionResult<LocationDTO> UpdatedLocation(int locationId, LocationDTO updatedLocation)
        {
            if (locationId != updatedLocation.LocationId)
            {
                return BadRequest();
            }
            // _context.Update(updatedLocation);
            // _context.SaveChanges();
            _locationService.UpdateLocation(locationId, updatedLocation);
            return Ok(updatedLocation);
        }
        [HttpDelete("{locationId}")]
        public ActionResult<Location> DeleteLocation(int locationId)
        {
            _locationService.DeleteLocation(locationId);
            // var location = _context.Locations.Find(locationId);
            // if (location == null)
            // {
            //     return NotFound();
            // }
            // _context.Locations.Remove(location);
            // _context.SaveChanges();
            return NoContent();
        }
    }

}