using GamersChat.Data;
using GamersChat.Models;
using GamersChat.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamersChat.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        protected readonly ApplicationDbContext dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApplicationUser Add(ApplicationUser userToAdd)
        {
            var user = this.dbContext.Add<ApplicationUser>(userToAdd);
            this.dbContext.SaveChanges();
            return user.Entity;
        }

        public void DeleteById(string id)
        {
            var user = GetById(id);
            dbContext.Set<ApplicationUser>().Remove(user);
            dbContext.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetAdminUsers()
        {
            return dbContext.Set<ApplicationUser>().Where(a => a.UserName == "admin").Include(b => b.Posts).ToList();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return dbContext.Set<ApplicationUser>().ToList();
        }

        public ApplicationUser GetById(string id)
        {
            var user = dbContext.Set<ApplicationUser>().Where(a => a.Id == id).FirstOrDefault();
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }
            return user;
        }

        public IEnumerable<ApplicationUser> GetNormalUsers()
        {
            return dbContext.Set<ApplicationUser>().Where(a => a.UserName != "admin").Include(b => b.Posts).ToList();
        }

        public ApplicationUser Update(ApplicationUser userToUpdate)
        {
            dbContext.Set<ApplicationUser>().Update(userToUpdate);
            dbContext.SaveChanges();
            return userToUpdate;
        }
    }
}
