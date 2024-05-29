using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Events.Conferences
{
    public class ConferenceCanceled : BaseEvent
    {
        public string ConferenceId { get; set; }
        public ConferenceCanceled(string conferenceId, int version) : base(EventType.ConferenceCanceled, version)
        {
            ConferenceId = conferenceId;
        }
    }
}
