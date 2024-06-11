using EventStore.Api.Models;
using EventStore.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        [Route("{aggregateId}")]
        public async Task<ActionResult<List<EventModel>>> GetEventsForAggregate(string aggregateId)
        {
            return Ok(new List<EventModel>());
        }

        [HttpGet]
        [Route("{aggregateId}/{version}")]
        public async Task<ActionResult<List<EventModel>>> GetEventsForAggregateFromVersion(string aggregateId, int version)
        {
            return Ok(new List<EventModel>());
        }

        public async Task<ActionResult> SaveEventForAggregate(EventModel eventModel)
        {
            return Ok();
        }
    }
}
