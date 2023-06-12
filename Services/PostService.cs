using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;

namespace GamersChat.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post GetPostById(Guid id)
        {
            return _postRepository.GetPostById(id);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }

        public IEnumerable<PostComment> GetCommentsForPost(Guid postId)
        {
            return _postRepository.GetCommentsForPost(postId);
        }


        public void CreatePost(Post post)
        {
            _postRepository.CreatePost(post);
        }

        public void UpdatePost(Post post)
        {
            _postRepository.UpdatePost(post);
        }

        public void DeletePost(Guid id)
        {
            _postRepository.DeletePost(id);
        }
    }
}
