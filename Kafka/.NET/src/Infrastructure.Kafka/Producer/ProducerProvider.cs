using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace Infrastructure.Kafka.Producer;

public interface IProducerProvider
{
    IProducer<Null, string> Producer { get; }
}

public class ProducerProvider : IProducerProvider, IDisposable
{
    private readonly Lazy<IProducer<Null, string>> _producer;
    private bool _isDisposed;

    public ProducerProvider(IOptions<KafkaProducerConfig> optionsAccessor)
    {
        _producer = new Lazy<IProducer<Null, string>>(() =>
        {
            var options = optionsAccessor.Value;
            var config = new ProducerConfig
            {
                BootstrapServers = options.BootstrapServers,
                Acks = options.Acks,
                ClientId = options.ClientId
            };
            return new ProducerBuilder<Null, string>(config).Build();
        });
    }

    public IProducer<Null, string> Producer => _producer.Value;

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        _producer.Value.Dispose();
       _isDisposed = true;
    }
}
