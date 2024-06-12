using Project2.Models;
using Project2.DTO;

namespace Project2.Services
{
    public interface IActivityService
    {
        IEnumerable<ActivityDTO> GetAllActivities();
        ActivityDTO GetActivityById(int activityId);
        Activity AddActivity(ActivityDTO activityDTO);
        ActivityDTO UpdateActivity(int activityId, ActivityDTO updatedActivity);
        void DeleteActivity(int activityId);
    }
}