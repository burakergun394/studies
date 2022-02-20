using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Template.RabbitMq.Client;
using Template.RabbitMq.Models;
using Template.RabbitMq.Publisher;
using Template.RabbitMq.Subscriber;

namespace Template.RabbitMq.DependencyResolvers.Microsoft
{
    public static class Resolver
    {
        public static void Resolve(this IServiceCollection serviceProvider, IConfiguration configuration)
        {
            var rabbitMqSettings = configuration.GetSection("RabbitMqSettings").Get<RabbitMqSettings>();

            serviceProvider.AddSingleton(sp => rabbitMqSettings);
            serviceProvider.AddSingleton<IConnectionFactory>(sp => new ConnectionFactory
            {
                Uri = new Uri(rabbitMqSettings.AmqpUrl),
                DispatchConsumersAsync = true
            });

            serviceProvider.AddSingleton<IRabbitMqClientService, RabbitMqClientService>();
            serviceProvider.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();
            serviceProvider.AddSingleton<IRabbitMqSubscriber, RabbitMqSubscriber>();
        }
    }
}
