﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Events.Tickets
{
    public class TicketPoolOpened : BaseEvent
    {
        public string ConferenceId { get; set; }
        public TicketPoolOpened(string conferenceId, int version) : base(EventType.TicketPoolOpened, version)
        {
            ConferenceId = conferenceId;
        }
    }
}
