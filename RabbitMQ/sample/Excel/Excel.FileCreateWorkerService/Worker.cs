using System.Data;
using System.Text;
using System.Text.Json;
using ClosedXML.Excel;
using Excel.FileCreateWorkerService.Models;
using Excel.FileCreateWorkerService.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared;

namespace Excel.FileCreateWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly RabbitMqClientService _rabbitMqClientService;
        private readonly IServiceProvider _serviceProvider;
        private IModel _channel;
        public Worker(ILogger<Worker> logger, RabbitMqClientService rabbitMqClientService, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _rabbitMqClientService = rabbitMqClientService;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumer = new AsyncEventingBasicConsumer(_channel);
                    var consumerTag = _channel.BasicConsume(RabbitMqClientService.QueueName, false, consumer);
                    consumer.Received += Consumer_Received;
                    _channel.BasicCancel(consumerTag);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return Task.CompletedTask;
        }

        private Task Consumer_ConsumerCancelled(object sender, ConsumerEventArgs @event)
        {
            throw new NotImplementedException();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMqClientService.Connect();
            _channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            try
            {
                await Task.Delay(5000);

                var bodyMessage = Encoding.UTF8.GetString(@event.Body.ToArray());
                var excel = JsonSerializer.Deserialize<CreateExcelMessage>(bodyMessage);

                await using var memoryStream = new MemoryStream();
                var workBook = new XLWorkbook();
                var dataSet = new DataSet();
                dataSet.Tables.Add(GetTable("products"));
                workBook.Worksheets.Add(dataSet);
                workBook.SaveAs(memoryStream);

                MultipartFormDataContent multipartFormDataContent = new();
                multipartFormDataContent.Add(new ByteArrayContent(memoryStream.ToArray()), "file",
                    Guid.NewGuid().ToString() + ".xlsx");

                var baseUrl = "https://localhost:7276/api/files";
                using var httpClient = new HttpClient();
                var response = await httpClient.PostAsync($"{baseUrl}?fileId={excel.FileId}", multipartFormDataContent);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"File ( Id: {excel.FileId}) was created by successful");
                    _channel.BasicAck(@event.DeliveryTag, false);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private DataTable GetTable(string tableName)
        {
            List<Product> products = new List<Product>();
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AdventureWorks2019Context>();
            products = context.Products.ToList();

            DataTable table = new DataTable { TableName = tableName };
            table.Columns.Add("ProductId", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("ProductNumber", typeof(string));
            table.Columns.Add("Color", typeof(string));

            products.ForEach(x =>
            {
                table.Rows.Add(x.ProductId, x.Name, x.ProductNumber, x.Color);
            });

            return table;
        }
    }
}