using System.Threading.Tasks;
using Pochta.Test.Consumer.Application.Message.Repository;

namespace Pochta.Test.Consumer.Data.Message.Implementation
{
    /// <summary>
    /// Реализация репозитория с использование EF 
    /// </summary>
    public class EntityFrameworkMessageRepository : IMessageRepository
    {
        private readonly MessageContext _messageContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="messageContext">Контекст БД сообщений</param>
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
    }
}