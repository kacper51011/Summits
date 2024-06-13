using EventStore.Application.Dtos;
using EventStore.Core.Interfaces;
using EventStore.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventModelRepository _eventModelRepository;
        public EventsController(IEventModelRepository eventModelRepository)
        {
            _eventModelRepository = eventModelRepository;
            
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
        public async Task<ActionResult> SaveEventForAggregate(EventModelDto eventModel)
        {
            var event1 = new EventModel()
            {
                EventData = eventModel.EventData,
                EventType = eventModel.EventType,
                AggregateId = eventModel.AggregateId,
                TimeStampUtc = eventModel.TimeStampUtc,
                Version = eventModel.Version,
            };
            await _eventModelRepository.SaveEventForAggregate(event1);

            return Ok(eventModel.AggregateId);
        }
    }
}
