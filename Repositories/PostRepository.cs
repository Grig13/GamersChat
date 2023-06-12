using GamersChat.Data;
using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamersChat.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _dbContext.Posts.Include(p => p.Comments).ToList();
        }

        public Post GetPostById(Guid id)
        {
            return _dbContext.Posts
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<PostComment> GetCommentsForPost(Guid postId)
        {
            return _dbContext.PostComments.Where(c => c.PostId == postId).ToList();
        }

        public void CreatePost(Post post)
        {
            post.Id = Guid.NewGuid();
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _dbContext.Entry(post).State= EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeletePost(Guid id)
        {
            var post = _dbContext.Posts.Find(id);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                _dbContext.SaveChanges();
            }
        }
    }
}
