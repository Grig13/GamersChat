using GamersChatAPI.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface IPostRepository
    {
        public IEnumerable<Post> GetAllPosts();
        public Post GetPostById(Guid id);
        public IEnumerable<PostComment> GetCommentsForPost(Guid postId);
        public void CreatePost(Post post);
        public void UpdatePost(Post post);
        public void DeletePost(Guid id);
    }
}
