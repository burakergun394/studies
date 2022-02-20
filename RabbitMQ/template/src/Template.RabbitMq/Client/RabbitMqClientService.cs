using RabbitMQ.Client;
using Template.RabbitMq.Models;

namespace Template.RabbitMq.Client;

public class RabbitMqClientService : IRabbitMqClientService, IDisposable
{
    private readonly IConnectionFactory _connectionFactory;
    private IConnection _connection;
    private IModel _channel;

    private readonly RabbitMqSettings _rabbitMqSettings;

    public RabbitMqClientService(IConnectionFactory connectionFactory, RabbitMqSettings rabbitMqSettings)
    {
        _connectionFactory = connectionFactory;
        _rabbitMqSettings = rabbitMqSettings;
    }

    public IModel CreateChannel()
    {
        CreateModel();

        _channel.ExchangeDeclare(
            exchange: _rabbitMqSettings.ExchangeName,
            type: ExchangeType.Direct,
            durable: true,
            autoDelete: false);

        _channel.QueueDeclare(
            _rabbitMqSettings.QueueName,
            durable: true,
            autoDelete: false,
            exclusive: false);

        _channel.QueueBind(
            queue: _rabbitMqSettings.QueueName,
            exchange: _rabbitMqSettings.ExchangeName,
            routingKey: _rabbitMqSettings.RoutingKey);

        return _channel;
    }

    public void Stop()
    {
        _channel?.Close();
        _channel?.Dispose();

        _connection?.Close();
        _connection?.Dispose();
    }

    private void CreateModel()
    {
        CreateConnection();

        if (_channel is { IsOpen: true })
            return;

        _channel = _connection.CreateModel();
    }

    private void CreateConnection()
    {
        if (_connection is { IsOpen: true })
            return;

        _connection = _connectionFactory.CreateConnection();
    }

    public void Dispose()
    {
        Stop();
    }

}