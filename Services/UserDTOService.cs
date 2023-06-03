using GamersChat.Models;
using GamersChat.Repositories.Interfaces;

namespace GamersChat.Services
{
    public class UserDTOService
    {
        private readonly IUserDTORepository userRepository;

        public UserDTOService(IUserDTORepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ApplicationUserDTO GetAttributes(Guid userId)
        {
            return this.userRepository.getUserAttributes(userId);
        }

        public ApplicationUserDTO SetAttributes(ApplicationUserDTO userAttributes)
        {
            return this.userRepository.setUserAttributes(userAttributes);
        }

        public ApplicationUserDTO EditAttributes(ApplicationUserDTO newAttributes)
        {
            return this.userRepository.editUserAttributes(newAttributes);
        }
    }
}
