

using EventStore.Core.Interfaces;
using EventStore.Core.Models;
using EventStore.Infrastructure.Db;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EventStore.Infrastructure.EventModelRepository
{
    public class EventModelRepository: IEventModelRepository
    {
        private IMongoCollection<EventModel> _collection;
        public EventModelRepository(IOptions<MongoOptions> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            var database = mongoClient.GetDatabase(options.Value.DatabaseName);

            _collection = database.GetCollection<EventModel>(options.Value.CollectionName);
        }

        public async Task<List<EventModel>> GetEventsForAggregate(string aggregateId)
        {
            var events = await _collection.Find(x => x.AggregateId == aggregateId).SortBy(x => x.Version).ToListAsync();
            return events;
        }

        public async Task<List<EventModel>> GetEventsForAggregateFromVersion(string aggregateId, int version)
        {
            var events = await _collection.Find(x => x.AggregateId == aggregateId && x.Version >= version).ToListAsync();
            return events;
        }

        public async Task SaveEventForAggregate(EventModel eventModel)
        {
            await _collection.InsertOneAsync(eventModel);
        }
    }
}
