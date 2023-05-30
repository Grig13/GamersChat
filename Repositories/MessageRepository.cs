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

        public void AddMessage(Message message)
        {
            message.Id = Guid.NewGuid();
            _context.Messages.Add(message);
            _context.SaveChanges();
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
            return _context.Messages.Find(messageId);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }
    }
}
