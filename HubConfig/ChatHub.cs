using GamersChat.Models;
using Microsoft.AspNetCore.SignalR;

namespace GamersChat.HubConfig
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
