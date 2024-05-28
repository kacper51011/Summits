using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Events.Tickets
{

    public class TicketPoolExtended : BaseEvent
    {
        public string ConferenceId { get; set; }
        public int VipTicketsExtendedBy { get; set; }
        public int BasicTicketsExtendedBy { get; set; }
        public TicketPoolExtended(string conferenceId, int vipTicketsExtendedBy, int basicTicketsExtendedBy, int version) : base(EventType.TicketPoolExtended, version)
        {

            ConferenceId = conferenceId;
            VipTicketsExtendedBy = vipTicketsExtendedBy;
            BasicTicketsExtendedBy = basicTicketsExtendedBy;
        }
    }
}
