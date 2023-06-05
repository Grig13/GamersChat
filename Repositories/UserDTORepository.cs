using GamersChat.Data;
using GamersChat.Models;
using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace GamersChat.Repositories
{
    public class UserDTORepository : IUserDTORepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public UserDTORepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            this.userManager = userManager;
        }

        public ApplicationUserDTO editUserAttributes(ApplicationUserDTO newAttributes)
        {
            var existingAttributes = getUserAttributes(newAttributes.UserId);
            if (existingAttributes == null)
            {
                throw new ArgumentException($"News with id: {newAttributes.Id} not found.");
            }
            existingAttributes.FirstName = newAttributes.FirstName;
            existingAttributes.LastName = newAttributes.LastName;
            existingAttributes.ProfilePicture = newAttributes.ProfilePicture;
            existingAttributes.Description = newAttributes.Description;
            existingAttributes.UserId= newAttributes.UserId;
            _dbContext.SaveChanges();
            return existingAttributes;
        }

        public ApplicationUserDTO getUserAttributes(Guid userId)
        {
            var attributesToReturn = _dbContext.Set<ApplicationUserDTO>().Where(p => p.UserId == userId).FirstOrDefault();

            //if (attributesToReturn == null)
            //{
            //    throw new KeyNotFoundException("Attributes not found.");
            //}

            return attributesToReturn;
        }

        public ApplicationUserDTO setUserAttributes(ApplicationUserDTO userAttributes)
        {
            _dbContext.ApplicationUsersDTO.Add(userAttributes);
            _dbContext.SaveChanges();
            return userAttributes;
        }
    }
}
