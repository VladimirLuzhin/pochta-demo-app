namespace Pochta.Test.Common.EventBus
{
    /// <summary>
    /// Фабрика для создания участников работы с событийной шиной
    /// </summary>
    public interface IEventBusParticipantsFactory
    {
        /// <summary>
        /// Создать консьюмера
        /// </summary>
        IEventConsumer CreateConsumer();

        /// <summary>
        /// Создать продьюсера
        /// </summary>
        IEventProducer CreateProducer();
    }
}