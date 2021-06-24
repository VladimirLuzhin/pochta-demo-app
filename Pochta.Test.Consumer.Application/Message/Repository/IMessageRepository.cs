using System.Threading.Tasks;

namespace Pochta.Test.Consumer.Application.Message.Repository
{
    /// <summary>
    /// Репозиторий по работе с сообщениями
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Сохранение сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        Task SaveMessageAsync(Message message);
    }
}