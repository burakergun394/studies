// Publisher = Producer

// See https://aka.ms/new-console-template for more information


using System.Text;
using RabbitMQ.Client;

//RabbitMQ();
//FanoutExchange();
//DirectExchange();
//TopicExchange();
HeaderExchange();

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
    using var connection = CreateConnection();
    using var channel = connection.CreateModel();

    channel.ExchangeDeclare(exchange: "logs-direct", durable: true, type: ExchangeType.Direct);

    Enum.GetNames(typeof(LogName)).ToList().ForEach(x =>
    {
        var routeKey = $"route-{x}";
        var queueName = $"direct-queue-{x}";
        channel.QueueDeclare(queueName, true, false, false);
        channel.QueueBind(queueName, "logs-direct", routeKey, null);
    });

    Enumerable.Range(1, 50).ToList().ForEach(x =>
    {
        LogName log = (LogName)new Random().Next(1, 5);
        var message = $"log type: {log}-{x}";
        var messageBody = Encoding.UTF8.GetBytes(message);
        var routeKey = $"route-{log}";

        channel.BasicPublish("logs-direct", routeKey, null, messageBody);

        Console.WriteLine($"Log gönderilmiştir : {message}");
    });
}

static void TopicExchange()
{
    using var connection = CreateConnection();
    using var channel = connection.CreateModel();

    channel.ExchangeDeclare(exchange: "logs-topic", durable: true, type: ExchangeType.Topic);

    Enumerable.Range(1, 50).ToList().ForEach(x =>
    {
        LogName log1 = (LogName)new Random().Next(1, 5);
        LogName log2 = (LogName)new Random().Next(1, 5);
        LogName log3 = (LogName)new Random().Next(1, 5);

        var routeKey = $"{log1}.{log2}.{log3}";

        var message = $"log type: {log1}-{log2}-{log3}-{x}";
        var messageBody = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("logs-topic", routeKey, null, messageBody);

        Console.WriteLine($"Log gönderilmiştir : {message}");
    });
}

static void HeaderExchange()
{
    using var connection = CreateConnection();
    using var channel = connection.CreateModel();

    channel.ExchangeDeclare(exchange: "header-exchange", durable: true, type: ExchangeType.Headers);

    Dictionary<string, object> headers = new Dictionary<string, object>();
    headers.Add("format", "pdf");
    headers.Add("shape2", "a4");

    var properties = channel.CreateBasicProperties();
    properties.Headers = headers;
    properties.Persistent = true; // Mesajlar kalıcı hale geldi.

    var messageBody = Encoding.UTF8.GetBytes("header mesajım");

    channel.BasicPublish("header-exchange", string.Empty, properties, messageBody);

    Console.WriteLine("Mesaj gönderilmiştir.");
}

public enum LogName
{
    Critical = 1,
    Error = 2,
    Warning = 3,
    Info = 4
}