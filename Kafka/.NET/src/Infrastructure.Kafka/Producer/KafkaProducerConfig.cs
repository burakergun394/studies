using Confluent.Kafka;

namespace Infrastructure.Kafka.Producer;

public class KafkaProducerConfig
{
    public string BootstrapServers { get; set; } = "localhost:9092";
    public Acks Acks { get; set; } = Acks.All;
    public string TopicName { get; set; } = "test";
    public string ClientId { get; set; } = $"{Environment.MachineName}-Producer";
}
