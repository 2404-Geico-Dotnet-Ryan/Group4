
using Project2.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Services
{
    public interface IUserService
    {
        Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers(); //done
        Task<ActionResult<UserDTO>> GetUser(int userId); //done
        Task<ActionResult<UserDTO>> GetUserByUsername(string username);
        Task<UserDTO> AddUser(UserDTO userDTO); //done
        Task<UserDTO> UpdateUser(int userId, UserDTO userDTO); //done
        Task<UserDTO> LoginUser(UserLoginDTO userLogin); //done
    }
}