using GamersChatAPI.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface IPostCommentRepository
    {
        public IEnumerable<PostComment> GetAll();
        public void DeleteById(Guid id);
        public void Add(PostComment commentToAdd);
        public PostComment Update(PostComment commentToUpdate);
        public PostComment GetById(Guid id);
    }
}
