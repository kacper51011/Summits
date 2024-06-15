using EventStore.Application.Configs;
using EventStore.Core.Interfaces;
using EventStore.Core.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace EventStore.Application.Consumers
{
    public class RabbitMQEventConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IEventModelRepository _eventRepository;
        private readonly IEventTypeFinder _eventTypeFinder;
        public RabbitMQEventConsumer(IOptions<RabbitMQOptions> options, IEventModelRepository eventRepository, IEventTypeFinder eventTypeFinder)
        {
            _eventRepository = eventRepository;
            _eventTypeFinder = eventTypeFinder;

            var factory = new ConnectionFactory()
            {
                HostName = options.Value.HostName,
                Password = options.Value.Password,
                UserName = options.Value.UserName,
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "event_store_processing",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());


                var parsedContent = JsonObject.Parse(content);
                var eventTypeStr = parsedContent["EventType"].ToString();

                var foundType = _eventTypeFinder.GetTypeOfEvent(eventTypeStr);

                var deserializedEvent = JsonSerializer.Deserialize(content, foundType);

                await _eventRepository.SaveEventForAggregate(deserializedEvent as EventModel);
            };
        }
    }
}
