// Subscriber = Consumer

// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

//RabbitMQ();
//FanoutExchange();
DirectExchange();


static IConnection CreateConnection()
{
    var factory = new ConnectionFactory
    {
        Uri = new Uri("amqps://rnehppre:qhOPBA8pUBfGI1l9VXug3himt7ApTbu5@toad.rmq.cloudamqp.com/rnehppre")
    };

    return factory.CreateConnection();
}

static void RabbitMQ()
{
    using var connection = CreateConnection();
    using var channel = connection.CreateModel();

    //channel.QueueDeclare(queue: "hello-queue", durable: true, exclusive: false, autoDelete: false);

    channel.BasicQos(0, 1, false);

    Console.WriteLine("Mesaj Bekleniyor...");

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
        Thread.Sleep(1500);
        Console.WriteLine("Gelen Mesaj:" + message);

        channel.BasicAck(e.DeliveryTag, false);
    };

    //consumer.Received += ConsumerOnReceived;
    Console.ReadLine();
}

static void FanoutExchange()
{
    var connection = CreateConnection();
    var channel = connection.CreateModel();

    var randomQueueName = channel.QueueDeclare().QueueName;
    //var randomQueueName = "log-database-save-queue";

    //channel.QueueDeclare(randomQueueName, true, false, false);
    channel.QueueBind(randomQueueName, "logs-fanout", string.Empty, null);

    channel.BasicQos(0, 1, false);
    var consumer = new EventingBasicConsumer(channel);

    channel.BasicConsume(queue: randomQueueName, autoAck: false, consumer: consumer);
    Console.WriteLine("Loglar dinleniyor...");

    consumer.Received += (sender, e) =>
    {
        var message = Encoding.UTF8.GetString(e.Body.ToArray());
        Thread.Sleep(1500);
        Console.WriteLine("Gelen Mesaj:" + message);
        channel.BasicAck(e.DeliveryTag, false);
    };

    Console.ReadLine();
}

static void DirectExchange()
{

}