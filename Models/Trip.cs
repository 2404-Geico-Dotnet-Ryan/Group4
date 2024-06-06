namespace Project2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class Trip 
{
    public int TripId { get; set; } //Primary Key
    public string? Location { get; set; } //Foreign Key - Location.cs
    public int MaxBudget { get; set; }
    public string? TravelType { get; set; } //Foreign Key - TravelType.cs
    public string? Climate { get; set; } //Foreign Key - Climate.cs
    public bool NeedsPassport { get; set; }
    
    // This establishes a one-to-many relationship between Trip and SavedTrip
    // A Trip can have many SavedTrips
    public ICollection<SavedTrip> SavedTrips {get; set;}
    public ICollection<Activity> Activities { get; set; } //FK Class

    public Trip()
    {

    }

    public Trip(int tripId,  string location, int maxBudget, string travelType, string climate, bool needsPassport, List<Activity> activities)
    {
        TripId = tripId;
        Location = location;
        MaxBudget = maxBudget;        
        TravelType = travelType;
        Climate = climate;
        NeedsPassport = needsPassport;
        Activities = new List<Activity>(activities);   
    
    }

    public override string ToString()
    {
        return $"{{Trip Id: {TripId}, Destination: {Location}, All-Inclusive Cost: {MaxBudget}, Travel Type: {TravelType}, Climate: {Climate}, Requires Passport: {NeedsPassport}, Activities: {Activities}}}";
    }


}