using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Models
{
    public class EventModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string AggregateId { get; set; }
        public int Version { get; set; }
        public string EventType { get; set; }
        public DateTime TimeStampUtc { get; set; }
        public BaseEvent EventData { get; set; }
    }
}
