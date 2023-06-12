using GamersChatAPI.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface IPostCommentRepository
    {
        public PostComment GetCommentById(Guid id);
        public void CreateComment(PostComment comment);
        public void DeleteComment(Guid id);
    }
}
