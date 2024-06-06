namespace Project2.Models;
public class SavedTrip 
{
    public int UId { get; set; }
    public int TripId { get; set; } 
    public int UserId { get; set; } 
    public string? Season { get; set; }
    public string? Location { get; set; }
    public int MaxBudget { get; set; }
    public int NumOfTravelers { get; set; }
    public string? TravelType { get; set; }
    public string? ClimatePref { get; set; }
    public bool PassportStatus { get; set; }
    public string? IncludedActivities { get; set; }
    public User User {get; set;}
    public Trip Trip {get; set;}

    public SavedTrip()
    {

    }

    public SavedTrip(int userId, int tripId, string location, int maxBudget, int numOfTravelers, string travelType, string climatePref, bool passportStat, string includedActivities)
    {
        TripId = tripId;
        UserId = userId;
        Location = location;
        MaxBudget = maxBudget;
        NumOfTravelers = numOfTravelers;
        TravelType = travelType;
        ClimatePref = climatePref;
        PassportStatus = passportStat;
        IncludedActivities = includedActivities;
    }

    public override string ToString()
    {
        return $"{{ Trip Id: {TripId}, Destination: {Location}, All-Inclusive Cost: {MaxBudget}, TravelType: {TravelType}, Climate: {ClimatePref}, Requires Passport: {PassportStatus}, Included Activities: {IncludedActivities}}}";
    }

}