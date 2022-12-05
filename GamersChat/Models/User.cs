using System.ComponentModel.DataAnnotations.Schema;

namespace GamersChat.Models
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public ICollection<Post>? Posts { get; set; }

    }
}
