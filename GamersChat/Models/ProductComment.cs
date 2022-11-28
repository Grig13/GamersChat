namespace GamersChat.Models
{
    public class ProductComment
    {
        public Guid Id { get; set; }
        public string CommentContent { get; set; }
        public int? Grade { get; set; }
    }
}
