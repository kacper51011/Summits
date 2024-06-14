using EventStore.Core.Attributes;
using EventStore.Core.Events.Conferences;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace EventStore.Core.Models
{

    [BsonDiscriminator(RootClass = true, Required = true)]
    [BsonKnownTypes(typeof(ConferenceEnded))]
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization)]
    [JsonDerivedType(typeof(ConferenceEnded))]
    //[ConferenceEventsJsonParent]
    public class EventModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string? Id { get; set; }
        public string AggregateId { get; set; }
        public int Version { get; set; }
        public string EventType { get; set; }
        public DateTime TimeStampUtc { get; set; }
    }
}
