using Microsoft.EntityFrameworkCore;

namespace Project2.Models;

[Index(nameof(Username), IsUnique = true)]
public class User
{
    public int UserId { get; set; } 
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string FirstName { get; set; }   
    public string LastName { get; set; }
    public int? MaxBudget { get; set; } = 0;
    public bool IsAdmin { get; set; } = false;
    public ICollection<SavedTrip> SavedTrips {get;set;}
    
    public User()
    { }

    public User(int userId, string username, string password, string firstName, string lastName, int maxBudget, bool isAdmin)
    {
        UserId = userId;
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;    
        MaxBudget = maxBudget;  
        IsAdmin = isAdmin;          
    }

    public override string ToString()
    {
        return $"{{UserId: {UserId},FirstName: {FirstName}, LastName: {LastName}, Max Budget: {MaxBudget}, Admin?: {IsAdmin}}}";;
    }
}