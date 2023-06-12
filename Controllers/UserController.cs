using GamersChat.Models;
using GamersChat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamersChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserAttributesService _userService;

        public UserController(UserManager<ApplicationUser> userManager, UserAttributesService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoggedInUserData()
        {
            // Get the user ID of the currently authenticated user
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return BadRequest("User ID not found");
            }

            var userId = userIdClaim.Value;

            var user = await _userManager.FindByIdAsync(userId);

            var userDetailsDto = new ApplicationUserDTO
            {
                UserId = user.Id,
                Email = user.Email,
                ProfileImageUrl = user.ProfilePicture,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                City = user.City
            };

            return Ok(userDetailsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAttributes(string id)
        {
            var userDetailsDto = await _userService.GetUserAttributes(id);

            if (userDetailsDto == null)
            {
                return NotFound($"User with ID '{id}' not found");
            }

            return Ok(userDetailsDto);
        }



    }
}
