using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Events.Conferences
{
    public class ConferenceEnded : BaseEvent
    {
        public string ConferenceId { get; set; }
        public ConferenceEnded(string conferenceId, int version) : base(EventType.ConferenceEnded, version)
        {
            ConferenceId = conferenceId;

        }
    }
}
