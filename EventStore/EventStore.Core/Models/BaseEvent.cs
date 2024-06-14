using EventStore.Core.Attributes;
using EventStore.Core.Events.Conferences;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EventStore.Core.Models
{
    //[ConferenceEventsJsonParent]
    [BsonKnownTypes(typeof(ConferenceEnded))]
    [JsonDerivedType(typeof(ConferenceEnded))]
    [BsonDiscriminator(RootClass = true)]
    public class BaseEvent
    {
    }

}
