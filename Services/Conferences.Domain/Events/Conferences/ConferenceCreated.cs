using Conferences.Domain.Entities;
using Conferences.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Events.Conferences
{
    public class ConferenceCreated : BaseEvent
    {
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

        public ConferenceCreated(
            string conferenceId,
            string name,
            string description,
            List<Lecture> lectures,
            TicketPool ticketPool,
            bool isTicketPoolOpened,
            DateTime startDateUtc,
            DateTime endDateUtc,
            DateTime created,
            int version) : base(EventType.ConferenceCreated, version)
        {
            ConferenceId = conferenceId;
            Name = name;
            Description = description;
            Lectures = lectures;
            TicketPool = ticketPool;
            IsTicketPoolOpened = isTicketPoolOpened;
            StartDateUtc = startDateUtc;
            EndDateUtc = endDateUtc;
            Created = created;
            Version = version;
        }
    }
}
