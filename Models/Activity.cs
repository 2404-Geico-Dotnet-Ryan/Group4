namespace Project2.Models
{
    public class Activity
    {
        public int ActivityId { get; set; } //Primary Key
        public string? ActivityName { get; set; }
        public Trip? Trip { get; set; }
        public Activity()
        {

        }

        public Activity(int activityId, string activityName, string activityType, string activityLocation, string activityDescription, string activityCost, string activityDuration, string activityRating, string activityImage)
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