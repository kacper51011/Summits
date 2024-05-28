using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Events.Tickets
{
    public class TicketPoolPricesChanged : BaseEvent
    {
        public string ConferenceId { get; set; }
        public decimal VipTicketPriceEur {  get; set; }
        public decimal BasicTicketPriceEur {  get; set; }
        public TicketPoolPricesChanged(string conferenceId, decimal vipTicketPriceEur, decimal basicTicketPriceEur, int version) : base(EventType.TicketPoolPricesChanged, version)
        {
            ConferenceId = conferenceId;
            VipTicketPriceEur = vipTicketPriceEur;
            BasicTicketPriceEur = basicTicketPriceEur;
        }
    }
}
