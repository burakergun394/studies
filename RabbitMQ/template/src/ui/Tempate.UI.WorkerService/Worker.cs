using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Template.RabbitMq.Subscriber;

namespace Tempate.UI.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRabbitMqSubscriber _rabbitMqSubscriber;
        private IModel _channel;

        public Worker(ILogger<Worker> logger, IRabbitMqSubscriber rabbitMqSubscriber)
        {
            _logger = logger;
            _rabbitMqSubscriber = rabbitMqSubscriber;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _rabbitMqSubscriber.DoConsumerAsync(Consumer_Received);
                await Task.Delay(1000, stoppingToken);
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMqSubscriber.StartConsumer();
            _logger.LogInformation("RabbitMQ ile baðlantý kuruldu: {time}", DateTimeOffset.Now);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _rabbitMqSubscriber.StopConsumer();
            _logger.LogInformation("RabbitMQ ile baðlantý koptu: {time}", DateTimeOffset.Now);
            return base.StopAsync(cancellationToken);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            try
            {
                var bodyMessage = Encoding.UTF8.GetString(@event.Body.ToArray());
                var body = JsonSerializer.Deserialize<string>(bodyMessage);
                _logger.LogInformation($"RabbitMQ'den mesaj alýndý: {body}");
                _channel.BasicAck(@event.DeliveryTag, false);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
            }
        }
    }
}