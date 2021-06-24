using System.Threading.Tasks;
using Confluent.Kafka;

namespace Pochta.Test.Common.EventBus.Kafka
{
    /// <summary>
    /// Продьюсер для записи доменых событий из Kafka 
    /// </summary>
    public class KafkaEventProducer : IEventProducer
    {
        private readonly IProducer<Null, string> _producer;
        private readonly string _kafkaTopic;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="producerConfig">Конфигурация продьюсера</param>
        /// <param name="kafkaTopic">Топик в который должен писать продьюсер</param>
        public KafkaEventProducer(ProducerConfig producerConfig, string kafkaTopic)
        {
            _kafkaTopic = kafkaTopic;
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
        }

        /// <inheritdoc />
        public async Task<bool> ProduceAsync(string eventJson)
        {
            var result = await _producer.ProduceAsync(_kafkaTopic, new Message<Null, string>
            {
                Value = eventJson
            });

            return result.Status == PersistenceStatus.Persisted;
        }
        
        /// <inheritdoc />
        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}