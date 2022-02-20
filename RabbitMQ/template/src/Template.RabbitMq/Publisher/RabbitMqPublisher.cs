using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using Template.RabbitMq.Client;
using Template.RabbitMq.Models;

namespace Template.RabbitMq.Publisher;

public class RabbitMqPublisher : IRabbitMqPublisher
{
    private readonly IRabbitMqClientService _rabbitMqClientService;
    private readonly RabbitMqSettings _rabbitMqSettings;


    public RabbitMqPublisher(IRabbitMqClientService rabbitMqClientService, RabbitMqSettings rabbitMqSettings)
    {
        _rabbitMqClientService = rabbitMqClientService;
        _rabbitMqSettings = rabbitMqSettings;
    }

    public void Publish(object value)
    {
        var channel = _rabbitMqClientService.CreateChannel();

        var bodyMessage = JsonSerializer.Serialize(value);
        var body = Encoding.UTF8.GetBytes(bodyMessage);

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(
            exchange: _rabbitMqSettings.ExchangeName,
            routingKey: _rabbitMqSettings.RoutingKey,
            basicProperties: properties,
            body: body);
    }
}