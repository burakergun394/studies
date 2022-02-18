// Subscriber = Consumer

// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

RabbitMQ();

static void RabbitMQ()
{
    var factory = new ConnectionFactory
    {
        Uri = new Uri("amqps://rnehppre:qhOPBA8pUBfGI1l9VXug3himt7ApTbu5@toad.rmq.cloudamqp.com/rnehppre")
    };

    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();
    channel.BasicQos(0, 1, false);
    //channel.QueueDeclare(queue: "hello-queue", durable: true, exclusive: false, autoDelete: false);
    var consumer = new EventingBasicConsumer(channel);

    /*
             * autoAck 
             * -> true  -> kuyruktan mesajı aldığı an silinsin,
             * -> false -> kuyruktan mesajı aldığı an silinmesin. Mesajı eriştikten sonra manuel olarak silme işlemini yapmak gerekir
             */

    channel.BasicConsume(queue: "hello-queue", autoAck: false, consumer: consumer);

    consumer.Received += (sender, e) =>
    {
        var message = Encoding.UTF8.GetString(e.Body.ToArray());
        Console.WriteLine("Gelen Mesaj:" + message);
        channel.BasicAck(e.DeliveryTag, false);
    };
    //consumer.Received += ConsumerOnReceived;
}

static void ConsumerOnReceived(object? sender, BasicDeliverEventArgs e)
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine("Gelen Mesaj: " + message);
}