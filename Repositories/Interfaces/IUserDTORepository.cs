using GamersChat.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface IUserDTORepository
    {
        public ApplicationUserDTO getUserAttributes(Guid userId);
        public ApplicationUserDTO setUserAttributes(ApplicationUserDTO userAttributes);
        public ApplicationUserDTO editUserAttributes(ApplicationUserDTO newAttributes);
    }
}
