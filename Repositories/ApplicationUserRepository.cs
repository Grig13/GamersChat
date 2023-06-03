using GamersChat.Data;
using GamersChat.Models;
using GamersChat.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GamersChat.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        protected readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUserRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> UserManager)
        {
            this.userManager = userManager;
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

        public ApplicationUser GetUserById(string userId)
        {
            return userManager.FindByIdAsync(userId).Result;
        }

        public bool UpdateUserAttributes(ApplicationUser user, ApplicationUserDTO attributes)
        {
            user.FirstName = attributes.FirstName;
            user.LastName = attributes.LastName;
            user.ProfilePicture = attributes.ProfilePicture;
            user.Description = attributes.Description;

            var result = userManager.UpdateAsync(user).Result;
            return result.Succeeded;
        }

        public async Task<bool> CreateOrUpdateUserAttributesAsync(string userId, ApplicationUserDTO attributes)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                // User doesn't exist, handle the error or return false
                return false;
            }

            // Update the user attributes
            user.FirstName = attributes.FirstName;
            user.LastName = attributes.LastName;
            user.ProfilePicture = attributes.ProfilePicture;
            user.Description = attributes.Description;

            var result = await userManager.UpdateAsync(user);

            return result.Succeeded;
        }
    }
}
