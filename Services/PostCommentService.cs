using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;

namespace GamersChat.Services
{
    public class PostCommentService
    {
        private readonly IPostCommentRepository _postCommentRepository;

        public PostCommentService(IPostCommentRepository postCommentRepository)
        {
            _postCommentRepository = postCommentRepository;
        }

        public PostComment GetCommentById(Guid id)
        {
            return _postCommentRepository.GetCommentById(id);
        }

        public void CreateComment(PostComment comment)
        {
            _postCommentRepository.CreateComment(comment);
        }

        public void DeleteComment(Guid id)
        {
            _postCommentRepository.DeleteComment(id);
        }
    }
}
