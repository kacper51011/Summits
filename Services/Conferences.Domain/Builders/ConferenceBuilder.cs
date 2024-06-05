using Conferences.Domain.Aggregates;
using Conferences.Domain.Entities;
using Conferences.Domain.Errors;
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
            if (ErrorType != ErrorType.None)
            {
                return Result.Failure<Conference>(ErrorType);
            }
            var createdConference = new Conference(Name, Description, TicketPool, Lectures, StartDateTimeUtc, EndDateTimeUtc);

            return Result.Success(createdConference, 201);
        }

        public IBuildStep SetDates(DateTime startDateTimeUtc, DateTime endDateTimeUtc)
        {
            var error = this.ValidateDates(startDateTimeUtc, endDateTimeUtc);
            if (error == ErrorType.None)
            {
                StartDateTimeUtc = startDateTimeUtc;
                EndDateTimeUtc = endDateTimeUtc;
            }
            else
            {
                ErrorType = error;
            }

            return this;

        }

        public ITicketPoolStep SetDescription(string description)
        {
            var error = this.ValidateDescription(description);
            if (error == ErrorType.None)
            {
                Description = description;
            }
            else
            {
                ErrorType = error;
            }

            return this;
        }

        public IDatesStep SetLectures(List<Lecture> lectures)
        {
            var error = this.ValidateLectures(lectures);
            if (ErrorType == ErrorType.None)
            {
                Lectures = lectures;
            }
            else
            {
                ErrorType = error;
            }

            return this;
        }

        public IDescriptionStep SetName(string name)
        {
            var error = this.ValidateName(name);
            if (error == ErrorType.None)
            {
                Name = name;
            }
            else
            {
                ErrorType = error;
            }

            return this;
        }

        public ILecturesStep SetTicketPool(TicketPool ticketPool)
        {
            var error = this.ValidateTicketPool(ticketPool);
            if (error == ErrorType.None)
            {
                TicketPool = ticketPool;
            }
            else
            {
                ErrorType = error;
            }

            return this;

        }
    }
}
