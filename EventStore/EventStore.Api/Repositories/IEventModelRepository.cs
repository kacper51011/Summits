using EventStore.Api.Models;
using MongoDB.Driver;

namespace EventStore.Api.Repositories
{
    public interface IEventModelRepository
    {
        public Task<List<EventModel>> GetEventsForAggregate(string aggregateId);
        public Task<List<EventModel>> GetEventsForAggregateFromVersion(string aggregateId, int version);
        public Task SaveEventForAggregate(EventModel eventModel);

    }
}
