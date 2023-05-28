using GamersChatAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace GamersChat.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Description { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}