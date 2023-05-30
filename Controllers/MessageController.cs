using GamersChat.Models;
using GamersChat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GamersChat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IEnumerable<Message> GetAllMessages()
        {
            return _messageService.GetAllMessages();
        }

        [HttpGet("{id}")]
        public ActionResult<Message> GetMessage(Guid id)
        {
            var message = _messageService.GetMessage(id);
            if (message == null)
            {
                return NotFound();
            }
            return message;
        }

        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            _messageService.AddMessage(message);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditMessage(Guid id, Message message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }
            _messageService.EditMessage(message);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(Guid id)
        {
            _messageService.DeleteMessage(id);
            return Ok();
        }
    }
}
