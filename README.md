# Notlar

## RabbitMQ
- RabbitMQ, ilk olarak Gelişmiş Mesaj Kuyruklama Protokolünü uygulayan ve o zamandan beri Akışlı Metin Yönelimli Mesajlaşma Protokolü, MQ Telemetri Aktarımı ve diğer protokolleri desteklemek için bir eklenti mimarisiyle genişletilen açık kaynaklı bir mesaj aracı yazılımıdır

  ## RabbitMQ kurulum
     - RabbitMQ Cloud ile kurulum
       - https://www.cloudamqp.com site üzerinden giriş yaparak cloud tabanlı bir rabbit mq instance oluşturulabilir

     - Docker container ile kurulum
       - ...

  ## Hello World
     - Publisher(Producer) ve Subscriber(Consumer) adlı 2 farklı console uygulaması kurunuz
     - RabbitMQ.Client kütüphanesini nuget üzerinden indiriniz

     - Publisher   
       static void RabbitMQ()
       {
           var factory = new ConnectionFactory
           {
               Uri = new Uri("amqps://rnehppre:qhOPBA8pUBfGI1l9VXug3himt7ApTbu5@toad.rmq.cloudamqp.com/rnehppre")
           };
       
           using var connection = factory.CreateConnection();
           var channel = connection.CreateModel();
       
           // durable false ise memory üzerinde tutulduğu rabbit mq restart atıldıgında kuyruktaki mesajlar silinir, true ise fiziksel olarak kaydedildiği için rabbit mq restart               atılsa da kuyruktaki mesajlar silinmez.
            // exclusive true yaparsak, sadece buradaki kanal üzerinden ulaşılır, false yaparsak farklı kanallardan erişilir
            // autoDelete false yaparsak, subscriber gittiği an kuyruk gitmesin, true yaparsak kuyruk yok olur.
            channel.QueueDeclare(queue:"hello-queue", durable:true, exclusive:false, autoDelete: false);
        
            var message = "hello world";
            var messageBody = Encoding.UTF8.GetBytes(message);
        
            channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);
            
            Console.WriteLine("Mesaj gönderilmiştir.");
        }
        
      - Subscriber
        static void RabbitMQ()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://rnehppre:qhOPBA8pUBfGI1l9VXug3himt7ApTbu5@toad.rmq.cloudamqp.com/rnehppre")
            };
        
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
        
            //channel.QueueDeclare(queue: "hello-queue", durable: true, exclusive: false, autoDelete: false);
        
            var consumer = new EventingBasicConsumer(channel);
        
            /*
             * autoAck 
             * -> true  -> kuyruktan mesajı aldığı an silinsin,
             * -> false -> kuyruktan mesajı aldığı an silinmesin. Mesajı eriştikten sonra manuel olarak silme işlemini yapmak gerekir
             */
        
            channel.BasicConsume(queue: "hello-queue", autoAck: true, consumer: consumer);
        
            consumer.Received += (sender, e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine("Gelen Mesaj: " + message);
            };
        
            //consumer.Received += ConsumerOnReceived;
        }
        
