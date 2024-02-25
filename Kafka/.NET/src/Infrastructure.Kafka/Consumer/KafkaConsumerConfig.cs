using Confluent.Kafka;

namespace Infrastructure.Kafka.Consumer;

public class KafkaConsumerConfig
{
    public string BootstrapServers { get; set; } = "localhost:9092";
    public Acks Acks { get; set; } = Acks.All;
    public string ClientId { get; set; } = $"{Environment.MachineName}-Consumer";
    public string GroupId { get; set; } = $"{Environment.MachineName}-Consumer-Group";
    public bool EnableAutoCommit { get; set; } = false;
    public AutoOffsetReset AutoOffsetReset { get; set; } = AutoOffsetReset.Earliest;

}
