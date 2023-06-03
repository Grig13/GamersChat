using GamersChat.Models;
using GamersChat.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GamersChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserAttributesController : Controller
    {
        private readonly UserDTOService userService;

        public UserAttributesController(UserDTOService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public ApplicationUserDTO GetAttributes(Guid userId)
        {
            return this.userService.GetAttributes(userId);  
        }

        [HttpPost]
        public ApplicationUserDTO SetAttributes(ApplicationUserDTO userAttributes)
        {
            var attributesToAdd = new ApplicationUserDTO
            {
                UserId = userAttributes.UserId,
                FirstName = userAttributes.FirstName,
                LastName = userAttributes.LastName,
                ProfilePicture = userAttributes.ProfilePicture,
                Description = userAttributes.Description,
            };

            return this.userService.SetAttributes(attributesToAdd);
        }

        [HttpPut("{id}")]
        public ApplicationUserDTO UpdateAttributes(Guid id, [FromBody] ApplicationUserDTO attributes)
        {
            var attributesToEdit = this.userService.GetAttributes(id);
            attributesToEdit.FirstName = attributes.FirstName;
            attributesToEdit.LastName = attributes.LastName;
            attributesToEdit.ProfilePicture = attributes.ProfilePicture;
            attributesToEdit.Description = attributes.Description;
            return this.userService.EditAttributes(attributesToEdit);
        }
    }
}
