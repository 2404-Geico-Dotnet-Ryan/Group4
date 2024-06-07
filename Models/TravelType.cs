namespace Project2.Models;

public class TravelType
{
    public int TravelTypeId { get; set; } //Primary Key
    public string? TravelTypeName { get; set; }
    public ICollection<Trip> Trips { get; set; }  // Navigation property

    public TravelType()
    {

    }

    public TravelType(int travelTypeId, string travelTypeName)
    {
        TravelTypeId = travelTypeId;
        TravelTypeName = travelTypeName;
    }

    public override string ToString()
    {
        return $"{{Travel Type Id: {TravelTypeId}, Travel Type Name: {TravelTypeName}}}";
    }
}