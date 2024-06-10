using Project2.Models;
using Project2.DTO;
using Project2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Project2.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Method to add a user // DONE
        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            var user = ConvertUserDTOToUser(userDTO);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return userDTO;
        }

        // Method to get all users // DONE
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _context.Users.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Username = u.Username,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
                MaxBudget = (int)u.MaxBudget,
                IsAdmin = u.IsAdmin
            }).ToListAsync();
            return users;
        }

        // Method to get a user by ID // DONE
        public async Task<ActionResult<UserDTO>> GetUser(int userId)
        {
            var userEntity = await GetUserById(userId); // call the helper method to get the user by ID

            if (userEntity == null)
            {
                return null;
            }
            // Convert the User entity to a UserDTO
            var user = ConvertUserToUserDTO(userEntity);

            return user;
        }

        // Method to get a user by username // DONE
        public async Task<ActionResult<UserDTO>> GetUserByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return null;
            }
            var userDTO = ConvertUserToUserDTO(user);
            return userDTO;
        }

        // Method to log in a user // DONE
        public async Task<ActionResult<UserDTO>> LoginUser(UserLoginDTO userLogin)
        {
            // Find the user by username and password
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userLogin.Username && u.Password == userLogin.Password);

            if (user == null)
            {
                return null; // Indicate failure to find the user
            }

            // Convert the User entity to a UserDTO
            var userDto = ConvertUserToUserDTO(user);

            return userDto;
        }

        // Method to update a user // DONE
        public async Task<UserDTO> UpdateUser(int userId, UserDTO userDTO)
        {
            // Find the user by ID
            var user = await GetUserById(userId);

            if (user == null)
            {
                return null;
            }
            // Update the user's properties
            user.Username = userDTO.Username;
            user.Password = userDTO.Password;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.MaxBudget = userDTO.MaxBudget;
            user.IsAdmin = userDTO.IsAdmin;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return userDTO;
        }

        // Method to convert a User entity to a UserDTO // DONE
        private UserDTO ConvertUserToUserDTO(User user)
        {
            return new UserDTO
            {
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MaxBudget = (int)user.MaxBudget,
                IsAdmin = user.IsAdmin
            };
        }

        // Method to convert a UserDTO to a User entity // DONE
        private User ConvertUserDTOToUser(UserDTO userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                MaxBudget = userDto.MaxBudget,
                IsAdmin = userDto.IsAdmin
            };
        }

        // Helper Method to get a user by ID // DONE
        private async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        // GetUser by UserId and Password - Replaced by Login method
        // public UserDTO GetUserByUsernameAndPassword(string username, string password)
        // {
        //     var user = _context.Users.Single(u => u.Username == username && u.Password == password);

        //     if (user == null)
        //     {
        //         return null;
        //     }
        //     var userDTO = new UserDTO
        //     {
        //         UserId = user.UserId,
        //         Username = user.Username,
        //         Password = user.Password,
        //         FirstName = user.FirstName,
        //         LastName = user.LastName,
        //         MaxBudget = user.MaxBudget
        //     };
        //     return userDTO;
        // }
    }
}