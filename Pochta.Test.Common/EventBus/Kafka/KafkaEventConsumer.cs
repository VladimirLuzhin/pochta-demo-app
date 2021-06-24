using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Pochta.Test.Common.EventBus.Kafka
{
    /// <summary>
    /// Консьюмер для чтения доменых событий из Kafka 
    /// </summary>
    public class KafkaEventConsumer : IEventConsumer
    {
        private readonly IConsumer<Ignore, string> _consumer;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="consumerConfig">Конфигурация консьюмера</param>
        /// <param name="topics">Топики для чтения</param>
        public KafkaEventConsumer(ConsumerConfig consumerConfig, string[] topics)
        {
            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

            foreach (var topic in topics)
            {
                _consumer.Subscribe(topic);
            }
        }
        
        /// <inheritdoc />
        public Task<string> ConsumeAsync(CancellationToken cancellationToken)
        {
            var result = _consumer.Consume(cancellationToken);
            _consumer.StoreOffset(result);
                
            return Task.FromResult(result.Message.Value);
        }

        /// <inheritdoc />
        public void Commit()
        {
            _consumer.Commit();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _consumer.Close();
            _consumer.Dispose();
        }
    }
}