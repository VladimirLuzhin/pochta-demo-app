using System.Threading.Tasks;
using Pochta.Test.Consumer.Application.Message.Repository;

namespace Pochta.Test.Consumer.Application.Message
{
    /// <summary>
    /// Сервис по работе с сообщениями
    /// </summary>
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="messageRepository">Реализация репозитория</param>
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        /// <summary>
        /// Сохранение сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        public Task SaveMessageAsync(Message message)
        {
            return _messageRepository.SaveMessageAsync(message);
        }
    }
}