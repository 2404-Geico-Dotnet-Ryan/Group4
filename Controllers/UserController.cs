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

        [HttpPost] //Done
        public async Task<ActionResult<UserDTO>> AddUser(UserDTO userDTO)
        {
            await _userService.AddUser(userDTO);
            return CreatedAtAction(nameof(GetUser), new { userId = userDTO.UserId }, userDTO);
        }

        [HttpGet] //Done
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return users;
        }

        [HttpGet("{userId:int}")] //Done
        public async Task<ActionResult<UserDTO>> GetUser(int userId)
        {
            var user = await _userService.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpGet("{username}")] //Done
        public async Task<ActionResult<UserDTO>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // Replaced by Login method
        // [HttpGet("{username}/{password}")] 
        // public ActionResult<UserDTO> GetUserByUsernameAndPassword(string username, string password)
        // {
        //     var user = _userService.GetUserByUsernameAndPassword(username, password);
        //     return Ok(user);
        // }

        [HttpPut("{userId}")] //Done
        public async Task<IActionResult> UpdateUser(int userId, UserDTO userDTO)
        {
            var updatedUserDTO = await _userService.UpdateUser(userId, userDTO);
            if (updatedUserDTO == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("login")] //Done
        public async Task<ActionResult<UserDTO>> Login(UserLoginDTO userLogin)
        {
            var user = await _userService.LoginUser(userLogin);

            if (user == null)
            {
                return Unauthorized();
            }
//TODO: Implement this method for admin login
          //  Response.Headers.Add("Authorization", "Admin" ();
            return user;
        }

        // [HttpGet("protected")] 
        // public async Task<ActionResult> ProtectedEndpoint([FromHeader] string authorization)
        // {
//TODO: Implement this method
        // }
    }
}