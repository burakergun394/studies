
using Infrastructure.Kafka.Consumer;

namespace Presentation.API.HostedServices;

public class KafkaConsumerHostedService(IServiceProvider serviceProvider, ILogger<KafkaConsumerHostedService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {

        using var scope = serviceProvider.CreateScope();
        var messageConsumer = scope.ServiceProvider.GetRequiredService<IMessageConsumer>();
        _ = Task.Run(async () =>
        {
            await messageConsumer.ConsumeAsync(new ConsumeEvent
            {
                TopicName = "test",
                ConsumeAsync = async (message) =>
                {
                    logger.LogInformation($"Received message: {message.Value}");
                }
            }, stoppingToken);
        });
    }
}
