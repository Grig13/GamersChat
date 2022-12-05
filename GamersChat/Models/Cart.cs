using System.ComponentModel.DataAnnotations.Schema;

namespace GamersChat.Models
{
    [Table("Carts")]
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
