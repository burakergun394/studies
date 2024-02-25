using Infrastructure.Kafka.Consumer;
using Infrastructure.Kafka.Producer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Kafka.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKafka(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<KafkaProducerConfig>(configuration.GetSection("Kafka:Producer"));
        services.AddSingleton<IProducerProvider, ProducerProvider>();
        services.AddTransient<IMessagePublisher, MessagePublisher>();

        services.Configure<KafkaConsumerConfig>(configuration.GetSection("Kafka:Consumer"));
        services.AddScoped<IConsumerProvider, ConsumerProvider>();
        services.AddScoped<IMessageConsumer, MessageConsumer>();

        return services;
    }
}
