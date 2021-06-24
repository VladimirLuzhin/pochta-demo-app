using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pochta.Test.Common.EventBus;
using Pochta.Test.Common.Transport;
using Pochta.Test.Producer.Application.Message.Repository;

namespace Pochta.Test.Producer.Application.Message
{
    public class MessageProducer : BackgroundService
    {
        private readonly IDisposable _serviceScope;
        private readonly ILogger _logger;
        private readonly IEventProducer _eventProducer;
        private readonly MessageService _messageService;

        private readonly TimeSpan _period = TimeSpan.FromSeconds(1);
        
        public MessageProducer(IServiceScopeFactory scopeFactory, IEventProducer eventProducer, ILoggerFactory loggerFactory)
        {
            var serviceScope = scopeFactory.CreateScope();
            
            _serviceScope = serviceScope;
            _messageService = serviceScope
                .ServiceProvider
                .GetService<MessageService>();
            
            _eventProducer = eventProducer;
            _logger = loggerFactory.CreateLogger<MessageProducer>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var (message, hash) = await _messageService.GetNextMessageToSendAndStorageHashAsync();
                    if (message == null)
                    {
                        await Task.Delay(_period);
                        continue;
                    }
                    
                    var isDelivered = await _eventProducer.ProduceAsync(JsonConvert.SerializeObject(new MessageContainer(message.IndexNumber, message.Text, hash)));
                    if (isDelivered)
                    {
                        await _messageService.MarkMessageAsSentAsync(message.IndexNumber);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError($"При попытке отправить сообщение в брокер произошла ошибка: {e}");
                }
                
                await Task.Delay(_period);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _serviceScope.Dispose();
        }
    }
}