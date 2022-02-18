// Publisher = Producer

// See https://aka.ms/new-console-template for more information


using System.Text;
using RabbitMQ.Client;

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
    var channel = connection.CreateModel();

    // durable false ise memory üzerinde tutulduğu rabbit mq restart atıldıgında kuyruktaki mesajlar silinir, true ise fiziksel olarak kaydedildiği için rabbit mq restart atılsa da kuyruktaki mesajlar silinmez.
    // exclusive true yaparsak, sadece buradaki kanal üzerinden ulaşılır, false yaparsak farklı kanallardan erişilir
    // autoDelete false yaparsak, subscriber gittiği an kuyruk gitmesin, true yaparsak kuyruk yok olur.
    channel.QueueDeclare(queue: "hello-queue", durable: true, exclusive: false, autoDelete: false);

    Enumerable.Range(1, 50).ToList().ForEach(x =>
     {
         var message = $"Message {x}";
         var messageBody = Encoding.UTF8.GetBytes(message);

         channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);

         Console.WriteLine($"Mesaj gönderilmiştir : {message}");
     });
}

static void FanoutExchange()
{
    using var connection = CreateConnection();
    using var channel = connection.CreateModel();

    channel.ExchangeDeclare(exchange:"logs-fanout",durable:true, type: ExchangeType.Fanout);

    Enumerable.Range(1, 50).ToList().ForEach(x =>
    {
        var message = $"log  {x}";
        var messageBody = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("logs-fanout", string.Empty, null, messageBody);

        Console.WriteLine($"Mesaj gönderilmiştir : {message}");
    });
}

static void DirectExchange()
{

}