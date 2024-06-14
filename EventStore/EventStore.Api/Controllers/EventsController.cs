using EventStore.Application.Dtos;
using EventStore.Core.Events.Conferences;
using EventStore.Core.Interfaces;
using EventStore.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace EventStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventModelRepository _eventModelRepository;
        private readonly IEventTypeFinder _eventTypeFinder;
        public EventsController(IEventModelRepository eventModelRepository, IEventTypeFinder eventTypeFinder)
        {
            _eventModelRepository = eventModelRepository;
            _eventTypeFinder = eventTypeFinder;
        }

        [HttpGet]
        [Route("{aggregateId}")]
        public async Task<ActionResult<List<EventModel>>> GetEventsForAggregate(string aggregateId)
        {
            var returnList = await _eventModelRepository.GetEventsForAggregate(aggregateId);
            return returnList;
        }

        [HttpGet]
        [Route("{aggregateId}/{version}")]
        public async Task<ActionResult<List<EventModel>>> GetEventsForAggregateFromVersion(string aggregateId, int version)
        {
            var returnList = await _eventModelRepository.GetEventsForAggregateFromVersion(aggregateId, version);
            return returnList;
        }

        [HttpPost]
        public async Task<ActionResult> SaveEventForAggregate(EventModel eventModel)
        {
            var modelito = new ConferenceEnded()
            {
                AggregateId = "123",
                EventType = "ConferenceEnded",
                ConferenceId = "123",
                TimeStampUtc = DateTime.UtcNow,
                Version = 0,


            };

            var jsoned = JsonSerializer.Serialize(modelito);

            var parsed = JsonObject.Parse(jsoned);

            var eventTypeStr = parsed["EventType"].ToString();

            var typeToDeserialize = _eventTypeFinder.GetTypeOfEvent(eventTypeStr);
            //var serialized = JsonSerializer.Serialize<ConferenceEnded>(modelito);
            var deserialized = JsonSerializer.Deserialize(jsoned, typeToDeserialize!);
            

            await _eventModelRepository.SaveEventForAggregate(deserialized as EventModel);
            


            return Ok(eventModel.AggregateId);
        }
    }
}
