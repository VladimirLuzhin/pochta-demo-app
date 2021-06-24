using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace Pochta.Test.Common.EventBus.Kafka
{
    /// <summary>
    /// Фабрика для создания консьюмеров и продьюсеров кафки
    /// </summary>
    public class KafkaEventBusParticipantsFactory : IEventBusParticipantsFactory
    {
        private readonly ConsumerConfig _consumerConfig;
        private readonly ProducerConfig _producerConfig;

        private readonly string[] _readTopics;
        private readonly string _writeTopic;
        
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="appConfig">Конфигурация приложения</param>
        public KafkaEventBusParticipantsFactory(IOptions<AppConfig> appConfig)
        {
            _readTopics = appConfig.Value.KafkaReadTopics;
            _writeTopic = appConfig.Value.KafkaWriteTopic;

            var kafkaAddresses = string.Join(',', appConfig.Value.KafkaAddresses);
            
            _consumerConfig = new ConsumerConfig
            {
                GroupId = appConfig.Value.ConsumerGroup,
                BootstrapServers = kafkaAddresses,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoOffsetStore = false,
                EnableAutoCommit = false
            };

            _producerConfig = new ProducerConfig
            {
                BootstrapServers = kafkaAddresses,
                MessageSendMaxRetries = 3,
                BatchNumMessages = 50
            };
        }

        /// <inheritdoc />
        public IEventConsumer CreateConsumer()
        {
            return new KafkaEventConsumer(_consumerConfig, _readTopics);
        }

        /// <inheritdoc />
        public IEventProducer CreateProducer()
        {
            return new KafkaEventProducer(_producerConfig, _writeTopic);
        }
    }
}