using Sample.Application.Common.Interfaces.Initializer;
using Sample.Infrastructure.DependencyResolvers.Microsoft;
using Sample.Persistence.DependencyResolvers.Microsoft;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.DependencyResolveForPersistenceLayer();
builder.Services.DependencyResolveForInfrastructureLayer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seedInitializer = scope.ServiceProvider.GetRequiredService<ISeedInitializer>();
    await seedInitializer.SeedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
