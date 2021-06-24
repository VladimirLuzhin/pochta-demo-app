using System.Threading.Tasks;
using Pochta.Test.Producer.Application.Message.Repository;

namespace Pochta.Test.Producer.Application.Message
{
    /// <summary>
    /// Сервис для работы с сообщениями
    /// </summary>
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="messageRepository">Реализация репозитория</param>
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        /// <summary>
        /// Сохранения сообщения
        /// </summary>
        /// <param name="text">Текст для сообщения</param>
        public Task SaveMessageAsync(string text)
        {
            var message = new Message(text);
            return _messageRepository.SaveMessageAsync(message);
        }

        /// <summary>
        /// Пометить сообщение как прочитанное
        /// </summary>
        /// <param name="indexNumber">порядковый номер сообщения</param>
        public Task MarkMessageAsSentAsync(int indexNumber)
        {
            return _messageRepository.MarkMessageAsSentAsync(indexNumber);
        }

        /// <summary>
        /// Получение следующего сообщения для отправки и хэш текущего состояния БД
        /// </summary>
        public Task<(Message,string)> GetNextMessageToSendAndStorageHashAsync()
        {
            return _messageRepository.GetNextMessageToSendAndStorageHashAsync();
        }
    }
}