

using EventStore.Application.Configs;
using EventStore.Application.Consumers;
using EventStore.Core.Interfaces;
using EventStore.Core.Utils;
using EventStore.Infrastructure.Db;
using EventStore.Infrastructure.EventModelRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IEventTypeFinder, EventTypeFinder>();

builder.Services.AddControllers();
builder.Services.Configure<MongoOptions>(builder.Configuration.GetSection("Mongo"));
builder.Services.Configure<RabbitMQOptions>(builder.Configuration.GetSection("RabbitMQ"));

builder.Services.AddHostedService<RabbitMQEventConsumer>();

builder.Services.AddSingleton<IEventModelRepository, EventModelRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
