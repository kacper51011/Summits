using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Events.Conferences
{
    public class TicketPoolClosed : BaseEvent
    {
        public TicketPoolClosed(string conferenceId, int version) : base(nameof(TicketPoolClosed), version)
        {
            ConferenceId = conferenceId;
        }
        public string ConferenceId { get; set; }
    }
}
