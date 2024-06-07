namespace Project2.Models
{
    public class Activity
    {
        public int ActivityId { get; set; } //Primary Key
        public string? ActivityName { get; set; }
        public ICollection<Trip> Trips { get; set; }  // Navigation property

        public Activity()
        {

        }

        public Activity(int activityId, string activityName)
        {
            ActivityId = activityId;
            ActivityName = activityName;
        }

        public override string ToString()
        {
            return $"{{Activity Id: {ActivityId}, Activity Name: {ActivityName}}}";
        }
    }
}