using Conferences.Domain.Entities;
using Conferences.Domain.Events;
using Conferences.Domain.Events.Conferences;
using Conferences.Domain.Events.Tickets;
using Conferences.Domain.Exceptions;
using Conferences.Domain.Utilities;
using Conferences.Domain.Validations;
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

        public Conference(string name, string description, TicketPool ticketPool, List<Lecture> lectures, DateTime startDateUtc, DateTime endDateUtc)
        {
            var conferenceCreated = new ConferenceCreated(Guid.NewGuid().ToString(), name, description, lectures, ticketPool, true, startDateUtc, endDateUtc, DateTime.UtcNow, Version + 1);
            ApplyNewChange(conferenceCreated);
        }
        public void Apply(ConferenceCreated @event)
        {
            Name = @event.Name;
            Description = @event.Description;
            TicketPool = @event.TicketPool;
            Created = @event.Created;
            HasEnded = false;
            HasBeenCanceled = false;
            Lectures = @event.Lectures;
            StartDateUtc = @event.StartDateUtc;
            EndDateUtc = @event.EndDateUtc;

        }
        public Result<Conference> OpenTicketPool(bool isFromEventStore)
        {
            if (IsTicketPoolOpen is true)
            {
                return Result.Failure();
            }
            ApplyChangeToAggregate(new TicketPoolClosed(ConferenceId, Version + 1), isFromEventStore);
            return Result.Success(this);
        }

        public void Apply(TicketPoolOpened @event)
        {
            IsTicketPoolOpen = true;
            Version = @event.Version;
        }

        public Result<Conference> CloseTicketPool(bool isFromEventStore)
        {
            if (IsTicketPoolOpen is not true)
            {
                return Result.Failure();
            }

            ApplyChangeToAggregate(new TicketPoolClosed(ConferenceId, Version + 1), isFromEventStore);
            return Result.Success(this);


        }

        public void Apply(TicketPoolClosed @event)
        {
            IsTicketPoolOpen = false;
            Version = @event.Version;
        }



        public Result<Conference> ExtendTicketPool(int vipTicketsExtendedBy, int basicTicketsExtendedBy, bool isFromEventStore)
        {
            this.DefaultValidation();
            ApplyChangeToAggregate(new TicketPoolExtended(ConferenceId, vipTicketsExtendedBy, basicTicketsExtendedBy, Version + 1), isFromEventStore);
            return Result.Success(this);
        }
        public void Apply(TicketPoolExtended @event)
        {
            TicketPool.BasicTicketsPool += @event.BasicTicketsExtendedBy;
            TicketPool.VipTicketPriceEur += @event.VipTicketsExtendedBy;
            Version = @event.Version;
        }

        public Result<Conference> ChangeTicketPoolPrices(decimal vipTicketPriceEur, decimal basicTicketPriceEur, bool isFromEventStore)
        {
            this.DefaultValidation();
            ApplyChangeToAggregate(new TicketPoolPricesChanged(ConferenceId, vipTicketPriceEur, basicTicketPriceEur, Version + 1), isFromEventStore);
            return Result.Success(this);

        }

        public void Apply(TicketPoolPricesChanged @event)
        {
            TicketPool.BasicTicketPriceEur = @event.BasicTicketPriceEur;
            TicketPool.VipTicketPriceEur = @event.VipTicketPriceEur;
            Version = @event.Version;
        }

        public Result<Conference> EndConference(bool isFromEventStore)
        {
            this.DefaultValidation();
            ApplyChangeToAggregate(new ConferenceEnded(ConferenceId,Version + 1), isFromEventStore);
            return Result.Success(this);
        }

        public void Apply(ConferenceEnded @event)
        {
            HasEnded = true;
            Version = @event.Version;
        }

        public Result<Conference> CancelConference(bool isFromEventStore)
        {
            ApplyChangeToAggregate(new ConferenceCanceled(ConferenceId, Version + 1), isFromEventStore);
            return Result.Success(this);
        }

        public void Apply(ConferenceCanceled @event)
        {
            IsTicketPoolOpen = false;
            HasBeenCanceled = true;
            Version = @event.Version;
        }
    }
}
