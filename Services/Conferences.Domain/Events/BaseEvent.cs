using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Events
{
    public abstract class BaseEvent
    {
        public string Id { get; set; }
        public EventType EventType { get; set; }
        public int Version { get; set; }
        public DateTime TimeStampUtc { get; set; }

        public BaseEvent(EventType type)
        {
            Id = Guid.NewGuid().ToString();
            EventType = type;
            TimeStampUtc = DateTime.UtcNow;
        }

    }
}
