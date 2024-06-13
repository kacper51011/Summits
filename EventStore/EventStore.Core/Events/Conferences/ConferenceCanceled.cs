using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Events.Conferences
{
    public class ConferenceCanceled : BaseEvent
    {
        public string ConferenceId { get; set; }
        public ConferenceCanceled(string conferenceId, int version) : base(nameof(ConferenceCanceled), version)
        {
            ConferenceId = conferenceId;
        }
    }
}
