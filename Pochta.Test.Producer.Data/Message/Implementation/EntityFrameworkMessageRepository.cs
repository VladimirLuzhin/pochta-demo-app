using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pochta.Test.Producer.Application.Message.Repository;

namespace Pochta.Test.Producer.Data.Message.Implementation
{
    /// <summary>
    /// Реализация репозиторий с использованием EF Core
    /// </summary>
    public class EntityFrameworkMessageRepository : IMessageRepository
    {
        private readonly MessageContext _messageContext;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="messageContext">Контекст для работы с таблицей сообщений</param>
        public EntityFrameworkMessageRepository(MessageContext messageContext)
        {
            _messageContext = messageContext;
        }

        /// <inheritdoc />
        public async Task SaveMessageAsync(Application.Message.Message message)
        {
            await _messageContext.Messages.AddAsync(message);
            await _messageContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task MarkMessageAsSentAsync(int indexNumber)
        {
            var message = await _messageContext.Messages.FirstOrDefaultAsync(m => m.IndexNumber == indexNumber);
            message.IsWasSendedToBroker = true;

            _messageContext.Messages.Update(message);
            await _messageContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<(Application.Message.Message Message, string Hash)> GetNextMessageToSendAndStorageHashAsync()
        {
            // услонвый "хэш" последнего состояния БД,
            var messagesHash = (await _messageContext.Messages.SumAsync(m => m.IndexNumber)).ToString();
            var message = await _messageContext.Messages
                .Where(m => !m.IsWasSendedToBroker)
                .OrderBy(m => m.IndexNumber)
                .FirstOrDefaultAsync();

            return (message, messagesHash);
        }
    }
}