using GamersChat.Services;
using GamersChatAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GamersChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IEnumerable<Post> GetAllPosts()
        {
            return _postService.GetAllPosts();
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(Guid id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        [HttpGet("{id}/comments")]
        public IEnumerable<PostComment> GetCommentsForPost(Guid id)
        {
            return _postService.GetCommentsForPost(id);
        }

        [HttpPost]
        public ActionResult<Post> CreatePost([FromBody] Post post)
        {
            _postService.CreatePost(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost(Guid id, [FromBody] Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            _postService.UpdatePost(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(Guid id)
        {
            _postService.DeletePost(id);
            return NoContent();
        }
    }
}
