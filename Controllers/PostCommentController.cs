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
    public class PostCommentController : ControllerBase
    {
        private readonly PostCommentService _postCommentService;

        public PostCommentController(PostCommentService postCommentService)
        {
            _postCommentService = postCommentService;
        }

        [HttpGet("{id}")]
        public ActionResult<PostComment> GetComment(Guid id)
        {
            var comment = _postCommentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        [HttpPost]
        public ActionResult<PostComment> CreateComment([FromBody] PostComment comment)
        {
            _postCommentService.CreateComment(comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(Guid id)
        {
            _postCommentService.DeleteComment(id);
            return NoContent();
        }
    }
}
