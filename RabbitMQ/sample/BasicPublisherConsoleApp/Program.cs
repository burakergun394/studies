// Publisher = Producer

// See https://aka.ms/new-console-template for more information


using System.Text;
using RabbitMQ.Client;

RabbitMQ();

static void RabbitMQ()
{
    var factory = new ConnectionFactory
    {
        Uri = new Uri("amqps://rnehppre:qhOPBA8pUBfGI1l9VXug3himt7ApTbu5@toad.rmq.cloudamqp.com/rnehppre")
    };

    using var connection = factory.CreateConnection();
    var channel = connection.CreateModel();

    // durable false ise memory üzerinde tutulduğu rabbit mq restart atıldıgında kuyruktaki mesajlar silinir, true ise fiziksel olarak kaydedildiği için rabbit mq restart atılsa da kuyruktaki mesajlar silinmez.
    // exclusive true yaparsak, sadece buradaki kanal üzerinden ulaşılır, false yaparsak farklı kanallardan erişilir
    // autoDelete false yaparsak, subscriber gittiği an kuyruk gitmesin, true yaparsak kuyruk yok olur.
    channel.QueueDeclare(queue:"hello-queue", durable:true, exclusive:false, autoDelete: false);

    var message = "hello world";
    var messageBody = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);
    
    Console.WriteLine("Mesaj gönderilmiştir.");
}
