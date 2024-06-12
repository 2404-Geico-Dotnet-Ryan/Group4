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
        // private readonly AppDbContext _context;

        // public ClimateController(AppDbContext context)
        // {
        //     _context = context;
        // }
        private readonly IClimateService _climateService;
        public ClimateController(IClimateService climateService)
        {
            _climateService = climateService;
        }
        [HttpPost]
        public ActionResult<Climate> AddClimate(ClimateDTO climateDTO)
        {
            // _context.Climates.Add(climate);
            // _context.SaveChanges();
            var climates = _climateService.AddClimate(climateDTO);
            return CreatedAtAction(nameof(GetClimateById), new { climateId = climateDTO.ClimateId}, climateDTO);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ClimateDTO>> GetClimates()
        {
            // var climates = _context.Climates.ToList();
            var climates = _climateService.GetAllClimates();
            return Ok(climates);      
        }
        [HttpGet("{climateId}")]
        public ActionResult<Climate> GetClimateById(int climateId)
        {
            // var climate = _context.Climates.Find(climateId);
            var climate = _climateService.GetClimateById(climateId);
            if (climate == null)
            {
                return NotFound();
            }
            return Ok(climateId);
        }
        [HttpPut("{climateId}")]
        public ActionResult<Climate> UpdatedClimate(int climateId, ClimateDTO updatedClimate)
        {
            if (climateId != updatedClimate.ClimateId)
            {
                return BadRequest();
            }
            // _context.Update(updatedClimate);
            // _context.SaveChanges();
            _climateService.UpdateClimate(climateId, updatedClimate);
            return Ok(updatedClimate);
        }
        [HttpDelete("{climateId}")]
        public ActionResult<Climate> DeleteClimate(int climateId)
        {
            _climateService.DeleteClimate(climateId);
            // var climate = _context.Climates.Find(climateId);
            // if (climate == null)
            // {
            //     return NotFound();
            // }
            // _context.Climates.Remove(climate);
            // _context.SaveChanges();
            return NoContent();
        }
        
    }

}