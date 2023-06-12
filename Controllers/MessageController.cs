using GamersChat.Models;
using GamersChat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GamersChat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MessageController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDTO messageDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var message = new Message
            {
                Id = Guid.NewGuid(),
                UserName = user.UserName,
                Content = messageDTO.Content,
                Timestamp = DateTime.Now,
                UserId = user.Id,
                Sender = user
            };

            // Save the message to your data store (e.g., database)

            // You can also broadcast the message to other users using SignalR
            // Here's an example of sending a message to all connected clients
            // using a SignalR hub called "ChatHub":
            // await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.UserName, message.Content);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            // Retrieve messages for the user from your data store (e.g., database)

            // Example code for retrieving messages using LINQ:
            // var messages = _dbContext.Messages
            //     .Where(m => m.UserId == user.Id)
            //     .OrderByDescending(m => m.Timestamp)
            //     .ToList();

            // Return the retrieved messages
            // return Ok(messages);

            return Ok();
        }
    }

    public class MessageDTO
    {
        public string Content { get; set; }
    }
}
