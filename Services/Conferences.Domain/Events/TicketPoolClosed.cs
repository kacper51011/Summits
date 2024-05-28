using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Events
{
    public class TicketPoolClosed: BaseEvent
    {
        public TicketPoolClosed(string conferenceId, int version): base(EventType.TicketPoolClosed, version)
        {
            ConferenceId = conferenceId;
        }
        public string ConferenceId { get; set; }
    }
}
