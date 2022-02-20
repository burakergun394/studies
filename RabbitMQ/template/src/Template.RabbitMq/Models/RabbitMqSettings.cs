namespace Template.RabbitMq.Models
{
    public class RabbitMqSettings
    {
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
        public string QueueName { get; set; }
        public string AmqpUrl { get; set; }
    }
}
