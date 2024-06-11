using Project2.Models;
using Project2.DTO;
using Project2.Data;
using Project2.Controllers;

namespace Project2.Services

{
    public class ActivityService : IActivityService
    {
        private readonly AppDbContext _context; 
        public ActivityService(AppDbContext context)
        {
            _context = context;
        }
        public ActivityDTO AddActivity(ActivityDTO activityDTO)
        {
            Activity activity = new Activity
            {
                ActivityId = activityDTO.ActivityId,
                ActivityName = activityDTO.ActivityName
            };
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return activityDTO;
        }

        public void DeleteActivity(int activityId)
        {
            var activity = _context.Activities.FirstOrDefault(a => a.ActivityId == activityId);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Activity not found.");
            }
        }

        public ActivityDTO GetActivityById(int activityId)
        {
            var activity = _context.Activities.Find(activityId);
            if (activity != null)
            {
                var activityDTO = new ActivityDTO
                {
                    ActivityId = activity.ActivityId,
                    ActivityName = activity.ActivityName
                };
                return activityDTO;
            }
            else
            {
                throw new Exception("Activity not found");
            }
        }

        public IEnumerable<ActivityDTO> GetAllActivities()
        {
            var activities = _context.Activities.Select(a => new ActivityDTO
            {
                ActivityId = a.ActivityId,
                ActivityName = a.ActivityName
            }).ToList();
            return activities;
        }

        public ActivityDTO UpdateActivity(int activityId, ActivityDTO updatedActivity)
        {
            var activity = _context.Activities.Find(activityId);
            if (activity == null)
            {
                return null;
            }
            activity.ActivityId = updatedActivity.ActivityId;
            activity.ActivityName = updatedActivity.ActivityName;
            
            _context.Activities.Update(activity);

            return updatedActivity;
        }
    }
}