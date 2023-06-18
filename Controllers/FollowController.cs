using GamersChat.Data;
using GamersChat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GamersChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class FollowController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public FollowController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> FollowUser(string followerId, string followedUserId)
        {
            var follower = await _userManager.FindByIdAsync(followerId);
            var followedUser = await _userManager.FindByIdAsync(followedUserId);

            if (follower == null || followedUser == null)
                return NotFound("User not found.");

            var existingFollow = _dbContext.Follows.FirstOrDefault(f => f.FollowerId == follower.Id && f.FollowedUserId == followedUserId);
            if (existingFollow != null)
                return BadRequest("You are already following this user.");

            var follow = new Follow
            {
                Id = Guid.NewGuid(),
                FollowerId = followerId,
                FollowedUserId = followedUserId
            };

            _dbContext.Follows.Add(follow);
            await _dbContext.SaveChangesAsync();

            return Ok("You are now following the user.");
        }

    }
}
