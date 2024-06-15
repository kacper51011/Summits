using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Application.Dtos
{
    public class EventModelDto
    {
        public string AggregateId { get; set; }
        public int Version { get; set; }
        public string EventType { get; set; }
        public DateTime TimeStampUtc { get; set; }
    }
}
