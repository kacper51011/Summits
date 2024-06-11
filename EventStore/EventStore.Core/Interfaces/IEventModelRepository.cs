using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Interfaces
{
    public interface IEventModelRepository
    {
        public Task<List<EventModel>> GetEventsForAggregate(string aggregateId);
        public Task<List<EventModel>> GetEventsForAggregateFromVersion(string aggregateId, int version);
        public Task SaveEventForAggregate(EventModel eventModel);

    }
}
