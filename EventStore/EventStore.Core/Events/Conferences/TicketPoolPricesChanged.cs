using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Events.Conferences
{
    public class TicketPoolPricesChanged : BaseEvent
    {
        public string ConferenceId { get; set; }
        public decimal VipTicketPriceEur { get; set; }
        public decimal BasicTicketPriceEur { get; set; }
        public TicketPoolPricesChanged(string conferenceId, decimal vipTicketPriceEur, decimal basicTicketPriceEur, int version) : base(nameof(TicketPoolPricesChanged), version)
        {
            ConferenceId = conferenceId;
            VipTicketPriceEur = vipTicketPriceEur;
            BasicTicketPriceEur = basicTicketPriceEur;
        }
    }
}
