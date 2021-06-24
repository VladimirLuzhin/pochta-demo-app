using System.Threading.Tasks;

namespace Pochta.Test.Producer.Application.Message.Repository
{
    /// <summary>
    /// Репозиторий для работы с сообщениями
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Сохаренние сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        Task SaveMessageAsync(Message message);
        
        /// <summary>
        /// Пометить сообщение как отправленно в брокер
        /// </summary>
        /// <param name="indexNumber">Порядковый номер сообщения</param>
        Task MarkMessageAsSentAsync(int indexNumber);

        /// <summary>
        /// Получение сообщения для отправки в порядке очереди и хэша текущего состояния БД
        /// </summary>
        Task<(Message Message, string Hash)> GetNextMessageToSendAndStorageHashAsync();
    }
}