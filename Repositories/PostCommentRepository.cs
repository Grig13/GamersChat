using GamersChat.Data;
using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamersChat.Repositories
{
    public class PostCommentRepository : IPostCommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PostCommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PostComment GetCommentById(Guid id)
        {
            return _dbContext.PostComments.Find(id);
        }

        public void CreateComment(PostComment comment)
        {
            _dbContext.PostComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void DeleteComment(Guid id) 
        {
            var comment = _dbContext.PostComments.Find(id);
            if(comment != null)
            {
                _dbContext.PostComments.Remove(comment);
                _dbContext.SaveChanges();
            }
        }
    }
}
