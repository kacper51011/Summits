using Conferences.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Interfaces
{
    public interface IEventStore
    {
        public Task SaveToEventStore(BaseEvent baseEvent);
    }
}
