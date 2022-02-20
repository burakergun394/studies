namespace Template.RabbitMq.Publisher
{
    public interface IRabbitMqPublisher
    {
        void Publish(object value);
    }
}
