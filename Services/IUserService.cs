using Project2.Models;
using Project2.DTO;

namespace Project2.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO GetUserById(int userId);
        UserDTO GetUserByUsername(string username);
        UserDTO GetUserByUsernameAndPassword(string username, string password);
        User AddUser(UserDTO UserDTO);
        void UpdateUser(int userId, UserDTO UpdatedUser);
    }
}