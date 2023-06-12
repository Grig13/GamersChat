using GamersChat.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface IUserAttributesRepository
    {
        Task<ApplicationUser> GetUserAttributesById(string userId);
    }
}
