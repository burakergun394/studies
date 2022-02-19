using Excel.FileCreateWorkerService;
using Excel.FileCreateWorkerService.Models;
using Excel.FileCreateWorkerService.Services;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        var configuration = hostContext.Configuration;

        services.AddDbContext<AdventureWorks2019Context>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddSingleton(serviceProvider => new ConnectionFactory
        {
            Uri = new Uri(configuration.GetConnectionString("RabbitMQ")),
            DispatchConsumersAsync = true
        });

        services.AddSingleton<RabbitMqClientService>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
