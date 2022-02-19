using System.Drawing;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Watermark.MVC.Services;

namespace Watermark.MVC.BackgroundServices
{
    public class ImageWatermarkProcessBackgroundService : BackgroundService
    {
        private readonly RabbitMqClientService _rabbitMqClientService;
        private readonly ILogger<ImageWatermarkProcessBackgroundService> _logger;
        private IModel _channel;

        public ImageWatermarkProcessBackgroundService(RabbitMqClientService rabbitMqClientService, ILogger<ImageWatermarkProcessBackgroundService> logger)
        {
            _rabbitMqClientService = rabbitMqClientService;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume(RabbitMqClientService.QueueName, false, consumer);
            consumer.Received += Consumer_Received;

            return Task.CompletedTask;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMqClientService.Connect();
            _channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _rabbitMqClientService.Dispose(); // gerek yok ama buradaki kod boş kalmasın diye yazdık.
                                              // bu kodu yazmamıza da gerek yoktu.
            return base.StopAsync(cancellationToken);
        }

        private Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            Task.Delay(5000).Wait();

            try
            {
                var productImageCreatedEvent =
                    JsonSerializer.Deserialize<ProductImageCreatedEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images",
                    productImageCreatedEvent.ImageName);

                using var image = Image.FromFile(path);
                using var graphic = Graphics.FromImage(image);

                var myUrl = "www.mydomain.com";

                var font = new Font(FontFamily.GenericMonospace, 32, FontStyle.Bold, GraphicsUnit.Pixel);
                var textSize = graphic.MeasureString(myUrl, font);
                var color = Color.FromArgb(128, 255, 255, 255);
                var brush = new SolidBrush(color);

                var position = new Point(image.Width - ((int)textSize.Width + 30), image.Height - ((int)textSize.Height));

                graphic.DrawString(myUrl, font, brush, position);

                image.Save("wwwroot/images/watermarks/" + productImageCreatedEvent.ImageName);

                image.Dispose();
                graphic.Dispose();

                _channel.BasicAck(@event.DeliveryTag, false);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            
            return Task.CompletedTask;
        }
    }
}
