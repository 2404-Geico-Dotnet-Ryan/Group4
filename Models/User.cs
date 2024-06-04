namespace Project2.Models;
public class User
{
    public int UserId { get; set; } 
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }   
    public string LastName { get; set; }
    public int MaxBudget { get; set; }
    public ICollection<SavedTrip> SavedTrips {get;set;}
    
    public Dictionary<int, User> userInfo = [];



    public User()
    {
        Username = "";
        Password = "";
        FirstName = "";
        LastName = "";
    }

    public User(int userId, string username, string password, string firstName, string lastName)
    {
        UserId = userId;
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;                
    }

    public override string ToString()
    {
        return $"{{UserId: {UserId},FirstName: {FirstName}, LastName: {LastName}}}";;
    }
}