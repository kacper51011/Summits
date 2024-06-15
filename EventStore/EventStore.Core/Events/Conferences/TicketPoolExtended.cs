using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Events.Conferences
{
    public class TicketPoolExtended : EventModel
    {
        public string ConferenceId { get; set; }
        public int VipTicketsExtendedBy { get; set; }
        public int BasicTicketsExtendedBy { get; set; }
    }
}
