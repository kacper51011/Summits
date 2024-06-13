using EventStore.Core.Events.Conferences;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EventStore.Core.Attributes
{
    public class ConferenceEventsJsonParent: Attribute
    {
        public BsonKnownTypesAttribute ConferenceCreatedMongoMap {  get; set; }
        public JsonDerivedTypeAttribute ConferenceCreatedJsonMap { get; set; }

        public BsonKnownTypesAttribute ConferenceCanceledMongoMap { get; set; }
        public JsonDerivedTypeAttribute ConferenceCanceledJsonMap { get; set; }

        public BsonKnownTypesAttribute ConferenceEndedMongoMap { get; set; }
        public JsonDerivedTypeAttribute ConferenceEndedJsonMap { get; set; }

        public BsonKnownTypesAttribute TicketPoolClosedMongoMap { get; set; }
        public JsonDerivedTypeAttribute TicketPoolClosedJsonMap { get; set; }

        public BsonKnownTypesAttribute TicketPoolExtendedMongoMap { get; set; }
        public JsonDerivedTypeAttribute TicketPoolExtendedJsonMap { get; set; }

        public BsonKnownTypesAttribute TicketPoolOpenedMongoMap { get; set; }
        public JsonDerivedTypeAttribute TicketPoolOpenedJsonMap { get; set; }

        public BsonKnownTypesAttribute TicketPoolPricesChangedMongoMap { get; set; }
        public JsonDerivedTypeAttribute TicketPoolPricesChangedJsonMap { get; set; }





        public ConferenceEventsJsonParent()
        {
            ConferenceCreatedMongoMap = new BsonKnownTypesAttribute(typeof(ConferenceCreated));
            ConferenceCreatedJsonMap = new JsonDerivedTypeAttribute(typeof(ConferenceCreated));

            ConferenceEndedMongoMap = new BsonKnownTypesAttribute(typeof(ConferenceEnded));
            ConferenceEndedJsonMap = new JsonDerivedTypeAttribute(typeof (ConferenceEnded));

            ConferenceCanceledMongoMap = new BsonKnownTypesAttribute(typeof(ConferenceCanceled));
            ConferenceCanceledJsonMap = new JsonDerivedTypeAttribute (typeof (ConferenceCanceled));

            TicketPoolClosedMongoMap = new BsonKnownTypesAttribute(typeof (TicketPoolClosed));
            TicketPoolClosedJsonMap = new JsonDerivedTypeAttribute(typeof (TicketPoolClosed));


            TicketPoolExtendedMongoMap = new BsonKnownTypesAttribute(typeof(TicketPoolExtended));
            TicketPoolExtendedJsonMap = new JsonDerivedTypeAttribute(typeof(TicketPoolExtended));


            TicketPoolOpenedMongoMap = new BsonKnownTypesAttribute(typeof(TicketPoolOpened));
            TicketPoolOpenedJsonMap = new JsonDerivedTypeAttribute(typeof(TicketPoolOpened));

            TicketPoolPricesChangedMongoMap = new BsonKnownTypesAttribute(typeof(TicketPoolPricesChanged));
            TicketPoolPricesChangedJsonMap = new JsonDerivedTypeAttribute(typeof(TicketPoolPricesChanged));

        }
    }
}
