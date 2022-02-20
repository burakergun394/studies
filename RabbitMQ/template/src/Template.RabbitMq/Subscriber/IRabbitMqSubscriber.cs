using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Template.RabbitMq.Subscriber
{
    public interface IRabbitMqSubscriber
    {
        IModel StartConsumer();
        void StopConsumer();
        void DoConsumer(EventHandler<BasicDeliverEventArgs> receivedEventHandler);
        void DoConsumerAsync(AsyncEventHandler<BasicDeliverEventArgs> receivedAsyncEventHandler);
    }
}
