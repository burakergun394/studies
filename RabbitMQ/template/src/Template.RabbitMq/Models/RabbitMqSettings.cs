using RabbitMQ.Client;

namespace Template.RabbitMq.Models
{
    public class RabbitMqSettings
    {
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
        public string QueueName { get; set; }
        public string AmqpUrl { get; set; }
        public bool Durable { get; set; }
        public bool AutoDelete { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoAck { get; set; }
        public RabbitMqExchangeType ExchangeType { get; set; }
    }
}
