﻿using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Events.Conferences
{
    public class TicketPoolOpened : BaseEvent
    {
        public string ConferenceId { get; set; }
        public TicketPoolOpened(string conferenceId, int version) : base(nameof(TicketPoolOpened), version)
        {
            ConferenceId = conferenceId;
        }
    }
}