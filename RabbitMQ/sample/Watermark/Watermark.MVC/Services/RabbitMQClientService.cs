using RabbitMQ.Client;

namespace Watermark.MVC.Services
{
    public class RabbitMqClientService: IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public static string ExchangeName = "ImageDirectExchange";
        public static string RoutingWatermark = "watermark-route-image";
        public static string QueueName = "queue-watermark-image";

        private readonly ILogger<RabbitMqClientService> _logger;


        public RabbitMqClientService(ConnectionFactory connectionFactory, ILogger<RabbitMqClientService> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
        }

        public IModel Connect()
        {
            _connection = _connectionFactory.CreateConnection();

            if (_channel is { IsOpen: true })
                return _channel;

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Direct, durable:true, autoDelete:false);
            _channel.QueueDeclare(QueueName, durable: true, autoDelete: false, exclusive: false);
            _channel.QueueBind(queue:QueueName, exchange:ExchangeName, routingKey:RoutingWatermark);

            _logger.LogInformation("RabbitMQ ile baglanti kuruldu...");

            return _channel;
        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();
            
            _connection?.Close();
            _connection?.Dispose();

            _logger.LogInformation("RabbitMQ ile bağlantı koptu...");
        }
    }
}
