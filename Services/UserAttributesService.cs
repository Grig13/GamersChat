using GamersChat.Models;
using GamersChat.Repositories.Interfaces;

namespace GamersChat.Services
{
    public class UserAttributesService
    {
        private readonly IUserAttributesRepository _userRepository;

        public UserAttributesService(IUserAttributesRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUserDTO> GetUserAttributes(string id)
        {
            var user = await _userRepository.GetUserAttributesById(id);

            if (user == null)
            {
                return null;
            }

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

            return userDetailsDto;
        }
    }
}
