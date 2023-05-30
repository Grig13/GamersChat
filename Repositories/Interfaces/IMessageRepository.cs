using GamersChat.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAllMessages();
        Message GetMessage(Guid messageId);
        void DeleteMessage(Guid messageId);
        void EditMessage(Message message);
        void AddMessage(Message message);
    }
}
