using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Kafka.Producer;

public interface IMessagePublisher
{
    Task PublishAsync(string message);
}

public class MessagePublisher(IProducerProvider producerProvider, ILogger<MessagePublisher> logger, IOptions<KafkaProducerConfig> optionsAccessor) : IMessagePublisher
{
    private readonly KafkaProducerConfig options = optionsAccessor.Value;

    public async Task PublishAsync(string message)
    {
        var producer = producerProvider.Producer;
        try
        {
            await producer.ProduceAsync(options.TopicName, new Message<Null, string>
            {
                Value = message
            });
        }
        catch (ProduceException<Null, string> exception)
        {
            logger.LogError(exception, "An error occured when producing message");
        }
    }
}
