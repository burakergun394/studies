using Confluent.Kafka;
using Infrastructure.Kafka.Producer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Kafka.Consumer;

public interface IMessageConsumer
{
    Task ConsumeAsync(ConsumeEvent consumeEvent, CancellationToken cancellationToken = default);
}


public class MessageConsumer(IConsumerProvider consumerProvider, ILogger<MessagePublisher> logger, IOptions<KafkaConsumerConfig> optionsAccessor): IMessageConsumer
{

    private readonly KafkaConsumerConfig options = optionsAccessor.Value;

    public async Task ConsumeAsync(ConsumeEvent consumeEvent, CancellationToken cancellationToken = default)
    {
        var consumer = consumerProvider.Consumer;
        consumer.Subscribe(consumeEvent.TopicName);
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = consumer.Consume(cancellationToken);
                await consumeEvent.ConsumeAsync(consumeResult);
                if (!options.EnableAutoCommit)
                {
                    consumer.Commit(consumeResult);
                }
            }
            catch (ConsumeException exception)
            {
                logger.LogError(exception, "Error consuming message");
            }
            catch (KafkaException exception)
            {
                logger.LogError(exception, "Error consuming message");
            }
        }
    }
}
