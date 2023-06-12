using System.ComponentModel.DataAnnotations;

namespace GamersChat.Models
{
    public class ApplicationUserDTO
    {
        [Key]
        public string UserId { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }


    }
}
