using Confluent.Kafka;

namespace Infrastructure.Kafka.Consumer;

public class ConsumeEvent
{
    public string TopicName { get; set; }
    public Func<ConsumeResult<Null, string> ,Task> ConsumeAsync { get; set; } 
}