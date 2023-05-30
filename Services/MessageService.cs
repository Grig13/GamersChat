using GamersChat.Models;
using GamersChat.Repositories;
using GamersChat.Repositories.Interfaces;

namespace GamersChat.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void AddMessage(Message message)
        {
            _messageRepository.AddMessage(message);
        }

        public void EditMessage(Message message)
        {
            _messageRepository.EditMessage(message);
        }

        public void DeleteMessage(Guid messageId)
        {
            _messageRepository.DeleteMessage(messageId);
        }

        public Message GetMessage(Guid messageId)
        {
            return _messageRepository.GetMessage(messageId);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return _messageRepository.GetAllMessages();
        }
    }
}
