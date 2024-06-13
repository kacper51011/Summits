using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Events.Conferences
{
    public class ConferenceEnded : BaseEvent
    {
        public string ConferenceId { get; set; }
        public ConferenceEnded(string conferenceId, int version) : base(nameof(ConferenceEnded), version)
        {
            ConferenceId = conferenceId;

        }
    }
}
