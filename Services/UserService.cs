using Project2.Models;
using Project2.DTO;
using Project2.Data;
using System.Linq;

namespace Project2.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public User AddUser(UserDTO userDTO)
        {
            User user = new User
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                MaxBudget = userDTO.MaxBudget
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _context.Users.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Username = u.Username,
                Password = u.Password,
                FirstName = u.FirstName,
                LastName = u.LastName,
                MaxBudget = u.MaxBudget
            }).ToList();
            return users;
        }

        public UserDTO GetUserById(int userId)
        {
           var user = _context.Users.Find(userId);
        //TODO: Add User Not Found Exception
            if (user == null)
            {
                return null;
            }
            var userDTO = new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MaxBudget = user.MaxBudget
            };
            return userDTO;
        }

        public UserDTO GetUserByUsername(string username)
        {
          var user = _context.Users.FirstOrDefault(u => u.Username == username);
        //TODO: Add User Not Found Exception
            if (user == null)
            {
                return null;
            }
            var userDTO = new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MaxBudget = user.MaxBudget
            };
            return userDTO;
        }

        public UserDTO GetUserByUsernameAndPassword(string username, string password)
        {
           var user = _context.Users.Single(u => u.Username == username && u.Password == password);
        //TODO: Add User Not Found Exception; re-enter username and password
            if (user == null)
            {
                return null;
            }
            var userDTO = new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MaxBudget = user.MaxBudget
            };
            return userDTO;
        }

        public void UpdateUser(int userId, UserDTO updatedUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            {
                user.UserId = userId;
                user.Username = updatedUser.Username;
                user.Password = updatedUser.Password;
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.MaxBudget = updatedUser.MaxBudget;
            };
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}