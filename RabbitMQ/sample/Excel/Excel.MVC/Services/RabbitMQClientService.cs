using RabbitMQ.Client;

namespace Excel.MVC.Services
{
    public class RabbitMqClientService: IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;

        public static string ExchangeName = "ExcelDirectExchange";
        public static string RoutingExcel = "route-excel-file";
        public static string QueueName = "queue-excel-file";

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
            _channel.QueueBind(queue:QueueName, exchange:ExchangeName, routingKey:RoutingExcel);

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
