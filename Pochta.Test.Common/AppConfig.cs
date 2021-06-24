namespace Pochta.Test.Common
{
    public class AppConfig
    {
        public string[] KafkaReadTopics { get; set; }
        public string KafkaWriteTopic { get; set; }
        public string[] KafkaAddresses { get; set; }
        public string ConsumerGroup { get; set; }
        public string SqlConnectionString { get; set; }
    }
}