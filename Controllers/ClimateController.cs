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

    public class ClimateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClimateController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult<Climate> AddClimate(Climate climate)
        {
            _context.Climates.Add(climate);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClimateById), new { climateId = climate.ClimateId}, climate);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ClimateDTO>> GetClimates()
        {
            var climates = _context.Climates.ToList();
            return Ok(climates);      
        }
        [HttpGet("{climateId}")]
        public ActionResult<Climate> GetClimateById(int climateId)
        {
            var climate = _context.Climates.Find(climateId);
            if (climate == null)
            {
                return NotFound();
            }
            return Ok(climateId);
        }
        [HttpPut("{climateId}")]
        public ActionResult<Climate> UpdatedClimate(int climateId, Climate updatedClimate)
        {
            if (climateId != updatedClimate.ClimateId)
            {
                return BadRequest();
            }
            _context.Update(updatedClimate);
            _context.SaveChanges();
            return updatedClimate;
        }
        [HttpDelete("{climateId}")]
        public ActionResult<Climate> DeleteClimate(int climateId)
        {
            var climate = _context.Climates.Find(climateId);
            if (climate == null)
            {
                return NotFound();
            }
            _context.Climates.Remove(climate);
            _context.SaveChanges();
            return NoContent();
        }
        
    }

}