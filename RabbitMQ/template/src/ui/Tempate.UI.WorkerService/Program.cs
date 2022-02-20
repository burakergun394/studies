using Tempate.UI.WorkerService;
using Template.RabbitMq.DependencyResolvers.Microsoft;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        services.Resolve(configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
