namespace Project2.Models;
public class SavedTrip 
{


    public int UId { get; set; } //Primary Key
    public int TripId { get; set; } //Foreign Key
    public int UserId { get; set; } //Foreign Key

    public string? Season { get; set; }
    public string? Location { get; set; }
    public int MaxBudget { get; set; }
    public int NumOfTravelers { get; set; }
    public string? TravelType { get; set; }
    public string? ClimatePref { get; set; }
    public bool PassportStatus { get; set; }
    public string? IncludedActivities { get; set; }
    public User User {get; set;} //Navigation Property - FK Class
    public Trip Trip {get; set;} //Navigation Property - FK Class
    
    // SavedTrip has a foreign key relationship with Trip and User
    // A SavedTrip can have one Trip and one User
    // SavedTrip will hold the foreign key associated with the Trip and User

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