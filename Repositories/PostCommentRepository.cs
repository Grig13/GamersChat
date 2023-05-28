using GamersChat.Data;
using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;

namespace GamersChat.Repositories
{
    public class PostCommentRepository : IPostCommentRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public PostCommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteById(Guid id)
        {
            var postCommentToBeDeleted = GetById(id);
            _dbContext.Set<PostComment>().Remove(postCommentToBeDeleted);
            _dbContext.SaveChanges();
        }

        public IEnumerable<PostComment> GetAll()
        {
            return _dbContext.Set<PostComment>().ToList();
        }

        public void Add(PostComment commentToAdd)
        {
            _dbContext.PostComments.Add(commentToAdd);
            _dbContext.SaveChanges();
        }

        public PostComment GetById(Guid id)
        {
            var postCommentToReturn = _dbContext.Set<PostComment>().Where(a => a.Id == id).FirstOrDefault();
            if (postCommentToReturn == null)
            {
                throw new KeyNotFoundException("Post Comment not found.");
            }
            return postCommentToReturn;
        }

        public PostComment Update(PostComment commentToUpdate)
        {
            _dbContext.Set<PostComment>().Update(commentToUpdate);
            _dbContext.SaveChanges();
            return commentToUpdate;
        }
    }
}
