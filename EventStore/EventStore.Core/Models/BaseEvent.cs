using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Models
{
    public class BaseEvent
    {
        public string Id { get; set; }
        public string AggregateId { get; set; }
        public string EventType { get; set; }
        public int Version { get; set; }
        public DateTime TimeStampUtc { get; set; }
    }
}
