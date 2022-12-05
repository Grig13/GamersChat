using System.ComponentModel.DataAnnotations.Schema;

namespace GamersChat.Models
{
    [Table("PostsComments")]
    public class PostComment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }   
        public Guid PostId { get; set; }
        public string CommentContent { get; set; }
    }
}
