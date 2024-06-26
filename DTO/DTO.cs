namespace Project2.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? MaxBudget { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class UserLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDTO
    {
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class SavedTripDTO
    {
        public int TripId { get; set; }
        public int UId { get; set; }
        public int UserId { get; set; }
        public string? Season { get; set; }
        public string? Location { get; set; }
        public int MaxBudget { get; set; }
        public int NumOfTravelers { get; set; }
        public string? TravelType { get; set; }
        public string? ClimatePref { get; set; }
        public bool PassportStatus { get; set; }
        //public string? ActivityName { get; set; }
    }

    public class TripDTO
    {
        public int TripId { get; set; }
        public string TripName { get; set; }
        public string? LocationName { get; set; }
        public int MaxBudget { get; set; }
        public string? TravelTypeName { get; set; }
        public string? ClimateType { get; set; }
        public bool NeedsPassport { get; set; }
        public string? ActivityName { get; set; }
    }
    public class ActivityDTO
    {
        public int ActivityId { get; set; }
        public string? ActivityName { get; set; }
    }
    public class ClimateDTO
    {
        public int ClimateId { get; set; }
        public string? ClimateType { get; set; }
    }
    public class LocationDTO
    {
        public int LocationId { get; set; }
        public string? LocationName { get; set; }
    }

}