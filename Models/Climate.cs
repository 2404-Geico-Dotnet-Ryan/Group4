namespace Project2.Models;

public class Climate
{
    public int ClimateId { get; set; } //Primary Key
    public string? ClimateType { get; set; }
    public ICollection<Trip> Trips { get; set; }  // Navigation property

    public Climate()
    {

    }

    public Climate(int climateId, string climateType)
    {
        ClimateId = climateId;
        ClimateType = climateType;
    }

    public override string ToString()
    {
        return $"{{Climate Id: {ClimateId}, Climate Type: {ClimateType}}}";
    }
}