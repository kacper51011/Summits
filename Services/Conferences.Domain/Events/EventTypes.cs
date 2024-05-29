using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Events
{
    public enum EventType
    {
        ConferenceCreated,
        ConferenceUpdated,
        ConferenceCanceled,
        ConferenceEnded,
        TicketPoolOpened,
        TicketPoolClosed,
        TicketPoolExtended,
        TicketPoolPricesChanged
    }
}
