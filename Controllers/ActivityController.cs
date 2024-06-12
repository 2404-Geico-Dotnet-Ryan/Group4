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

    public class ActivityController : ControllerBase
    {
        // private readonly AppDbContext _context;

        // public ActivityController(AppDbContext context)
        // {
        //     _context = context;
        // }

        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost]
        public ActionResult<Activity> AddActivity(ActivityDTO activityDTO)
        {
            var activities = _activityService.AddActivity(activityDTO);
            // _context.Activities.Add(activity);
            // _context.SaveChanges();
            return CreatedAtAction(nameof(GetActivityById), new { activityId = activityDTO.ActivityId}, activityDTO);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ActivityDTO>> GetActivities()
        {
            // var activities = _context.Activities.ToList();
            var activities = _activityService.GetAllActivities();
            return Ok(activities);
        }
        [HttpGet("{activityId}")]
        public ActionResult<Activity> GetActivityById(int activityId)
        {
            // var activity = _context.Activities.Find(activityId);
            var activity = _activityService.GetActivityById(activityId);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }
        [HttpPut("{activityId}")]
        public ActionResult<ActivityDTO> UpdateActivity(int activityId, ActivityDTO updatedActivity)
        {
            if (activityId != updatedActivity.ActivityId)
            {
                return BadRequest();
            }
            _activityService.UpdateActivity(activityId, updatedActivity);
            // _context.Update(updatedActivity);
            // _context.SaveChanges();
            return Ok(updatedActivity);
        }
        [HttpDelete("{activityId}")]
        public ActionResult<Activity> DeleteActivity(int activityId)
        {
            _activityService.DeleteActivity(activityId);
            // var activity = _context.Activities.Find(activityId);
            // if (activity == null)
            // {
            //     return NotFound();
            // }
            // _context.Activities.Remove(activity);
            // _context.SaveChanges();
            return NoContent();
        }
    }
}