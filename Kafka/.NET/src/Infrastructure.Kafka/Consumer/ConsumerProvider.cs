using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace Infrastructure.Kafka.Consumer;

public interface IConsumerProvider
{
    IConsumer<Null, string> Consumer { get; }
}

public class ConsumerProvider : IConsumerProvider
{
    private readonly Lazy<IConsumer<Null, string>> _consumer;
    public ConsumerProvider(IOptions<KafkaConsumerConfig> optionsAccessor)
    {
        _consumer = new Lazy<IConsumer<Null, string>>(() =>
        {
            var options = optionsAccessor.Value;
            var config = new ConsumerConfig
            {
                BootstrapServers = options.BootstrapServers,
                Acks = options.Acks,
                ClientId = options.ClientId,
                AutoOffsetReset = options.AutoOffsetReset,
                GroupId = options.GroupId,
                EnableAutoCommit = options.EnableAutoCommit,
                

            };
            return new ConsumerBuilder<Null, string>(config).Build();
        });
    }

    public IConsumer<Null, string> Consumer => _consumer.Value;
}

