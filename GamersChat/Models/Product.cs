using System.ComponentModel.DataAnnotations.Schema;

namespace GamersChat.Models
{
    [Table("Products")]
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int Price { get; set; }
        public ICollection<ProductComment> Comments { get; set; }

    }
}
