using System.ComponentModel.DataAnnotations.Schema;

namespace GamersChat.Models
{
    [Table("ProductsComments")]
    public class ProductComment
    {
        public Guid Id { get; set; }
        public string CommentContent { get; set; }
        public int? Grade { get; set; }
        public Guid PorudctId { get; set; }

        public Product? Product { get; set; } = null!;
    }
}
