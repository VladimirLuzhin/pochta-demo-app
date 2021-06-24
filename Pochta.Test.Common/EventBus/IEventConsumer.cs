using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pochta.Test.Common.EventBus
{
    /// <summary>
    /// Интерфейс консьюмера
    /// </summary>
    public interface IEventConsumer : IDisposable
    {
        /// <summary>
        /// Получить событие из шины
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<string> ConsumeAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Комитим подверждение получения данных из шины 
        /// </summary>
        void Commit();
    }
}