using GamersChat.Models;
using GamersChat.Repositories.Interfaces;

namespace GamersChat.Services
{
    public class ApplicationUserService
    {
        private readonly IApplicationUserRepository userRepository;

        public ApplicationUserService(IApplicationUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return this.userRepository.GetAll();
        }

        public ApplicationUser GetUserById(string userId)
        {
            return this.userRepository.GetById(userId);
        }

        public ApplicationUser UserUpdate(ApplicationUser userToUpdate)
        {
            return this.userRepository.Update(userToUpdate);
        }

        public void RemoveUser(string userId)
        {
            this.userRepository.DeleteById(userId);
        }

        public ApplicationUser AddUser(ApplicationUser userToAdd)
        {
            return this.userRepository.Add(userToAdd);
        }

        public IEnumerable<ApplicationUser> GetNormalUsers()
        {
            return this.userRepository.GetNormalUsers();
        }

        public IEnumerable<ApplicationUser> GetAdminUsers()
        {
            return this.userRepository.GetAdminUsers();
        }

        public ApplicationUserDTO GetUser(string userId)
        {
            var user = userRepository.GetUserById(userId);
            return MapToDto(user);
        }

        public bool UpdateUserAttributes(string userId, ApplicationUserDTO attributes)
        {
            var user = userRepository.GetUserById(userId);
            if (user == null)
            {
                // User not found, handle the error or return false
                return false;
            }

            return userRepository.UpdateUserAttributes(user, attributes);
        }

        public async Task<bool> CreateOrUpdateUserAttributesAsync(string userId, ApplicationUserDTO attributes)
        {
            return await userRepository.CreateOrUpdateUserAttributesAsync(userId, attributes);
        }

        private ApplicationUserDTO MapToDto(ApplicationUser user)
        {
            // Map the ApplicationUser to ApplicationUserDTO
            var userDto = new ApplicationUserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.ProfilePicture,
                Description = user.Description
            };

            return userDto;
        }


    }
}
