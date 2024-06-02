using Conferences.Domain.Aggregates;
using Conferences.Domain.Entities;
using Conferences.Domain.Interfaces;
using Conferences.Domain.Utilities;
using Conferences.Domain.Validations;
using Conferences.Domain.ValueObjects;

namespace Conferences.Domain.Builders
{
    public class ConferenceBuilder : IConferenceBuilder
    {
        public ErrorType ErrorType { get; set; } = ErrorType.None;

        public string Name { get; set; }

        public string Description { get; set; }
        public TicketPool TicketPool { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();
        public DateTime StartDateTimeUtc { get; set; }
        public DateTime EndDateTimeUtc { get; set; }

        public static INameStep Create()
        {
            return new ConferenceBuilder();
        }

        public Result<Conference> Build()
        {
            if(ErrorType != ErrorType.None)
            {
                return Result.Failure<Conference>(ErrorType);
            }
            var createdConference =  new Conference(Name, Description, TicketPool, Lectures, StartDateTimeUtc, EndDateTimeUtc);

            return Result.Success(createdConference, 201);
        }

        public IBuildStep SetDates(DateTime startDateTimeUtc, DateTime endDateTimeUtc)
        {
            this.ValidateDates(startDateTimeUtc, endDateTimeUtc);
            if(ErrorType == ErrorType.None)
            {
                StartDateTimeUtc = startDateTimeUtc;
                EndDateTimeUtc = endDateTimeUtc;
            }

            return this;

        }

        public ITicketPoolStep SetDescription(string description)
        {
            this.ValidateDescription(description);
            if (ErrorType != ErrorType.None)
            {
                Description = description;
            }

            return this;
        }

        public IDatesStep SetLectures(List<Lecture> lectures)
        {
            this.ValidateLectures(lectures);
            if (ErrorType == ErrorType.None)
            {
                Lectures = lectures;
            }

            return this;
        }

        public IDescriptionStep SetName(string name)
        {
            this.ValidateName(name);
            if (ErrorType == ErrorType.None)
            {
                Name = name;
            }
            return this;
        }

        public ILecturesStep SetTicketPool(TicketPool ticketPool)
        {
            this.ValidateTicketPool(ticketPool);
            if (ErrorType == ErrorType.None)
            {
                TicketPool = ticketPool;
            }
            return this;

        }
    }
}
