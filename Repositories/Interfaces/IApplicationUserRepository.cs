using GamersChat.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface IApplicationUserRepository
    {
        public IEnumerable<ApplicationUser> GetAll();
        public IEnumerable<ApplicationUser> GetNormalUsers();
        public IEnumerable<ApplicationUser> GetAdminUsers();
        public void DeleteById(string id);
        public ApplicationUser Add(ApplicationUser userToAdd);
        public ApplicationUser Update(ApplicationUser userToUpdate);
        public ApplicationUser GetById(string id);
    }
}
