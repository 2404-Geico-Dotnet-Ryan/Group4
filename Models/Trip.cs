namespace Project2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class Trip 
{
    public int Id { get; set; }
    public string? Location { get; set; }
    public int MaxBudget { get; set; }
    public string? TravelType { get; set; }
    public string? Climate { get; set; }
    public bool NeedsPassport { get; set; }
    public string? IncludedActivities { get; set; }
    public ICollection<SavedTrip> SavedTrips {get; set;}

    public Trip()
    {

    }

    public Trip(int id,  string location, int maxBudget, string travelType, string climate, bool needsPassport, string includedActivities)
    {
        Id = id;
        Location = location;
        MaxBudget = maxBudget;        
        TravelType = travelType;
        Climate = climate;
        NeedsPassport = needsPassport;
        IncludedActivities = includedActivities;
    
    }

    public override string ToString()
    {
        return $"{{Trip Id: {Id}, Destination: {Location}, All-Inclusive Cost: {MaxBudget}, Travel Type: {TravelType}, Climate: {Climate}, Requires Passport: {NeedsPassport}, Included Activities: {IncludedActivities}}}";
    }


}