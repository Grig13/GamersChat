using GamersChat.Data;
using GamersChat.Models;
using GamersChat.Repositories.Interfaces;

namespace GamersChat.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public void EditMessage(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
        }

        public void DeleteMessage(Guid messageId)
        {
            var message = _context.Messages.Find(messageId);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }
        }

        public Message GetMessage(Guid messageId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Messages.Find(messageId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }
    }
}
