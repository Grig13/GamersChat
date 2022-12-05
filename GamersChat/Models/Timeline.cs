using System.ComponentModel.DataAnnotations.Schema;

namespace GamersChat.Models
{
    [Table("Timeline")]
    public class Timeline
    {
        public Guid Id { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
