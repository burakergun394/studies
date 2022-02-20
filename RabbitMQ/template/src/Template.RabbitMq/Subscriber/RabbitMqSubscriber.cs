using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Template.RabbitMq.Client;
using Template.RabbitMq.Models;

namespace Template.RabbitMq.Subscriber;

public class RabbitMqSubscriber : IRabbitMqSubscriber
{
    private readonly IRabbitMqClientService _rabbitMqClientService;
    private readonly RabbitMqSettings _rabbitMqSettings;
    private IModel _channel;

    public RabbitMqSubscriber(IRabbitMqClientService rabbitMqClientService, RabbitMqSettings rabbitMqSettings)
    {
        _rabbitMqClientService = rabbitMqClientService;
        _rabbitMqSettings = rabbitMqSettings;
    }

    public IModel StartConsumer()
    {
        _channel = _rabbitMqClientService.CreateChannel();
        _channel.BasicQos(0, 1, false);

        return _channel;
    }

    public void StopConsumer()
    {
        _rabbitMqClientService.Stop();
    }

    public void DoConsumerAsync(AsyncEventHandler<BasicDeliverEventArgs> receivedAsyncEventHandler)
    {
        if (_channel is {IsOpen: false})
            return;

        var consumer = new AsyncEventingBasicConsumer(_channel);
        var consumerTag = _channel.BasicConsume(
            queue: _rabbitMqSettings.QueueName,
            autoAck: _rabbitMqSettings.AutoAck,
            consumer: consumer);

        consumer.Received += receivedAsyncEventHandler;
        _channel.BasicCancel(consumerTag);   
    }
    public void DoConsumer(EventHandler<BasicDeliverEventArgs> receivedEventHandler)
    {
        if (_channel is { IsOpen: false })
            return;

        var consumer = new EventingBasicConsumer(_channel);
        var consumerTag = _channel.BasicConsume(
            queue: _rabbitMqSettings.QueueName,
            autoAck: _rabbitMqSettings.AutoAck,
            consumer: consumer);
        consumer.Received += receivedEventHandler;
        _channel.BasicCancel(consumerTag);
    }
}