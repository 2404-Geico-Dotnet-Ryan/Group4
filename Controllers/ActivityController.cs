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
        private readonly AppDbContext _context;

        public ActivityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Activity> AddActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetActivityById), new { activityId = activity.ActivityId}, activity);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ActivityDTO>> GetActivities()
        {
            var activities = _context.Activities.ToList();
            return Ok(activities);
        }
        [HttpGet("{activityId}")]
        public ActionResult<Activity> GetActivityById(int activityId)
        {
            var activity = _context.Activities.Find(activityId);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }
        [HttpPut("{activityId}")]
        public ActionResult<Activity> UpdateActivity(int activityId, Activity updatedActivity)
        {
            if (activityId != updatedActivity.ActivityId)
            {
                return BadRequest();
            }
            _context.Update(updatedActivity);
            _context.SaveChanges();
            return updatedActivity;
        }
        [HttpDelete("{activityId}")]
        public ActionResult<Activity> DeleteActivity(int activityId)
        {
            var activity = _context.Activities.Find(activityId);
            if (activity == null)
            {
                return NotFound();
            }
            _context.Activities.Remove(activity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}