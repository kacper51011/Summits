using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Events.Conferences
{
    public class TicketPoolExtended : BaseEvent
    {
        public string ConferenceId { get; set; }
        public int VipTicketsExtendedBy { get; set; }
        public int BasicTicketsExtendedBy { get; set; }
        public TicketPoolExtended(string conferenceId, int vipTicketsExtendedBy, int basicTicketsExtendedBy, int version) : base(nameof(TicketPoolExtended), version)
        {

            ConferenceId = conferenceId;
            VipTicketsExtendedBy = vipTicketsExtendedBy;
            BasicTicketsExtendedBy = basicTicketsExtendedBy;
        }
    }
}
