using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pochta.Test.Common.EventBus;
using Pochta.Test.Common.Transport;

namespace Pochta.Test.Consumer.Application.Message
{
    /// <summary>
    /// Фоновый сервис, который обрабатывает сообщения из брокера
    /// </summary>
    public class MessageConsumer : BackgroundService
    {
        private readonly MessageService _messageService;
        private readonly IEventBusParticipantsFactory _factory;
        private readonly ILogger _logger;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="factory">Фабрика для создания консьюмера</param>
        /// <param name="logger">Логгер</param>
        /// <param name="messageService">Сервис по работе с сообщениями</param>
        public MessageConsumer(IEventBusParticipantsFactory factory, ILogger logger, MessageService messageService)
        {
            _factory = factory;
            _logger = logger;
            _messageService = messageService;
        }

        /// <inheritdoc />
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = _factory.CreateConsumer();
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var json = await consumer.ConsumeAsync(stoppingToken);
                    var messageContainer = JsonConvert.DeserializeObject<MessageContainer>(json);
                    var message = new Message(messageContainer.IndexNumber, messageContainer.Text, messageContainer.SendDateTime, messageContainer.PreviousStorageStateHash);

                    await _messageService.SaveMessageAsync(message);
                }
                catch (Exception e)
                {
                    _logger.LogError($"При получении сообщения из брокера произошла ошбика: {e}");
                }
            }
        }
    }
}