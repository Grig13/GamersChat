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
    }
}
