using Project2.DTO;
using Project2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserDTO> AddUser(UserDTO userDTO)
        {
            var user = _userService.AddUser(userDTO);
            return CreatedAtAction(nameof(GetUserById), new {userId = user.UserId}, userDTO);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId:int}")]
        public ActionResult<UserDTO> GetUserById(int userId)
        {
            var user = _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpGet("{username}")]
        public ActionResult<UserDTO> GetUserByUsername(string username)
        {
            var user = _userService.GetUserByUsername(username);
            return Ok(user);
        }

        [HttpGet("{username}/{password}")]
         public ActionResult<UserDTO> GetUserByUsernameAndPassword(string username, string password)
        {
            var user = _userService.GetUserByUsernameAndPassword(username, password);
            return Ok(user);
        }

        [HttpPut("{userId}")]
        public ActionResult<UserDTO> UpdateUser(int userId, UserDTO UpdatedUser)
        {
            _userService.UpdateUser(userId, UpdatedUser);
            return Ok(UpdatedUser);
        }
    }
}