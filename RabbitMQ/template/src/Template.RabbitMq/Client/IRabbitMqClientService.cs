using RabbitMQ.Client;

namespace Template.RabbitMq.Client
{
    public interface IRabbitMqClientService
    {
        public IModel CreateChannel();
        public void Stop();
    }
}
