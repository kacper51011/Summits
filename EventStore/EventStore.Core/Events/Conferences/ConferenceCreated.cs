using EventStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Events.Conferences
{
    public class ConferenceCreated : BaseEvent
    {
        public ConferenceCreated() : base(nameof(ConferenceCreated), 0)
        {
        }

        public string ConferenceId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Lecture> Lectures { get; private set; } = new List<Lecture>();
        public bool IsTicketPoolOpened { get; private set; }

        public TicketPool TicketPool { get; private set; }
        public DateTime StartDateUtc { get; private set; }
        public DateTime EndDateUtc { get; private set; }
        public DateTime Created { get; private set; }
        public int Version { get; set; }
    }
}
