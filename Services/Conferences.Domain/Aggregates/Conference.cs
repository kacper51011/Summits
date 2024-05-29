using Conferences.Domain.Entities;
using Conferences.Domain.Events;
using Conferences.Domain.Events.Conferences;
using Conferences.Domain.Events.Tickets;
using Conferences.Domain.Exceptions;
using Conferences.Domain.ValueObjects;

namespace Conferences.Domain.Aggregates
{
    public class Conference : AggregateRoot
    {
        public string ConferenceId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Lecture> Lectures { get; private set; } = new List<Lecture>();
        public DateTime StartDateUtc { get; private set; }
        public DateTime EndDateUtc { get; private set; }
        public bool IsTicketPoolOpen { get; private set; }
        public TicketPool TicketPool { get; private set; }
        public DateTime Created { get; private set; }

        public bool HasEnded {  get; private set; }
        public bool HasBeenCanceled {  get; private set; }

        public Conference(string conferenceId)
        {
            ConferenceId = conferenceId;
        }

        public Conference(string name, string description, TicketPool ticketPool, List<Lecture> lectures, DateTime startDateUtc, DateTime endDateUtc, bool hasEnded, bool hasBeenCanceled)
        {
            var conferenceCreated = new ConferenceCreated(Guid.NewGuid().ToString(), name, description, lectures, ticketPool, true, startDateUtc, endDateUtc, DateTime.UtcNow, Version + 1);
            ApplyNewChange(conferenceCreated);
        }

        public void CloseTicketPool()
        {
            if (IsTicketPoolOpen is not true)
            {
                throw new DomainException("Ticket pool is already closed");
            }

            ApplyNewChange(new TicketPoolClosed(ConferenceId, Version + 1));


        }

        public void Apply(TicketPoolClosed @event)
        {
            IsTicketPoolOpen = false;
            Version = @event.Version;
        }

        public void OpenTicketPool()
        {
            if (IsTicketPoolOpen is true)
            {
                throw new DomainException("Ticket pool is already opened");
            }

            ApplyNewChange(new TicketPoolClosed(ConferenceId, Version + 1));
        }

        public void Apply(TicketPoolOpened @event)
        {
            IsTicketPoolOpen = true;
            Version = @event.Version;
        }

        public void ExtendTicketPool(int vipTicketsExtendedBy, int basicTicketsExtendedBy)
        {
            ApplyNewChange(new TicketPoolExtended(ConferenceId, vipTicketsExtendedBy, basicTicketsExtendedBy, Version + 1));
        }
        public void Apply(TicketPoolExtended @event)
        {
            TicketPool.BasicTicketsPool += @event.BasicTicketsExtendedBy;
            TicketPool.VipTicketPriceEur += @event.VipTicketsExtendedBy;
            Version = @event.Version;
        }

        public void ChangeTicketPoolPrices(decimal vipTicketPriceEur, decimal basicTicketPriceEur)
        {
            ApplyNewChange(new TicketPoolPricesChanged(ConferenceId, vipTicketPriceEur, basicTicketPriceEur, Version + 1));

        }

        public void Apply(TicketPoolPricesChanged @event)
        {
            TicketPool.BasicTicketPriceEur = @event.BasicTicketPriceEur;
            TicketPool.VipTicketPriceEur = @event.VipTicketPriceEur;
            Version = @event.Version;
        }

        public void EndConference()
        {
            ApplyNewChange(new ConferenceEnded(ConferenceId,Version + 1));
        }

        public void Apply(ConferenceEnded @event)
        {
            HasEnded = true;
            Version = @event.Version;
        }

        public void CancelConference()
        {
            ApplyNewChange(new ConferenceCanceled(ConferenceId, Version + 1));
        }

        public void Apply(ConferenceCanceled @event)
        {
            HasBeenCanceled = true;
            Version = @event.Version;
        }
    }
}
