namespace Project2.Models;

public class Location
{
    public int LocationId { get; set; } //Primary Key
    public string? LocationName { get; set; }
    public ICollection<Trip> Trips { get; set; }  // Navigation property

    public Location()
    {

    }

    public Location(int locationId, string locationName)
    {
        LocationId = locationId;
        LocationName = locationName;
    }

    public override string ToString()
    {
        return $"{{Location Id: {LocationId}, Location Name: {LocationName}}}";
    }
}