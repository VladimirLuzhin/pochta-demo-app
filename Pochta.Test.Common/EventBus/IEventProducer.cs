using System;
using System.Threading.Tasks;

namespace Pochta.Test.Common.EventBus
{
    /// <summary>
    /// Продьюсер эвентов
    /// </summary>
    public interface IEventProducer : IDisposable
    {
        /// <summary>
        /// Отправка события в шину
        /// </summary>
        /// <param name="eventJson">JSON события</param>
        /// <returns>Возвращает true, если сообщение точно доставлено, в противном случае false</returns>
        Task<bool> ProduceAsync(string eventJson);
    }
}