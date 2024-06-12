namespace Project2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class Trip
{
    public int TripId { get; set; } //Primary Key
    public string? TripName { get; set; }
    public int MaxBudget { get; set; }
    public bool NeedsPassport { get; set; }
    public int LocationId { get; set; } //Foreign Key - Location.cs
    public int TravelTypeId { get; set; } //Foreign Key - TravelType.cs
    public int? ClimateId { get; set; } //Foreign Key - Climate.cs
    public int ActivityId { get; set; }

    // This establishes a one-to-many relationship between Trip and SavedTrip
    // A Trip can have many SavedTrips
    public virtual ICollection<SavedTrip> SavedTrips { get; set; }
    public Activity Activity { get; set; } //FK Class
    public TravelType TravelType { get; set; } //Navigation Property - FK Class
    public Climate? Climate { get; set; } //Navigation Property - FK Class
    public Location Location { get; set; } //Navigation Property - FK Class

    public Trip()
    {

    }

    public Trip(int tripId, string tripName, int locationId, int maxBudget, int travelTypeId, int climateId, bool needsPassport, int activityId)
    {
        TripId = tripId;
        TripName = tripName;
        LocationId = locationId;
        MaxBudget = maxBudget;
        TravelTypeId = travelTypeId;
        ClimateId = climateId;
        NeedsPassport = needsPassport;
        ActivityId = activityId;
    }

    public override string ToString()
    {
        return $"{{Trip Id: {TripId}, Trip Name: {TripName}, Location Id: {LocationId}, Max Budget: {MaxBudget}, Travel Type Id: {TravelTypeId}, Climate Id: {ClimateId}, Needs Passport: {NeedsPassport}, Activity Id: {ActivityId}}}";
    }

}