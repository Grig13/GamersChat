using GamersChat.Models;
using GamersChat.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
namespace GamersChat.Repositories
{
    public class UserAttributesRepository : IUserAttributesRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserAttributesRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserAttributesById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
