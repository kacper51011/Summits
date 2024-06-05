using Conferences.Domain.Builders;
using Conferences.Domain.Entities;
using Conferences.Domain.Errors;
using Conferences.Domain.Errors.Conference;
using Conferences.Domain.Errors.Lectures;
using Conferences.Domain.Errors.TicketPools;
using Conferences.Domain.ValueObjects;

namespace Conferences.Domain.Validations
{
    public static class ConferenceBuilderValidations
    {
        private const int minName = 5;
        private const int maxName = 50;

        private const int minDesc = 20;
        private const int maxDesc = 1500;
        public static ErrorType ValidateName(this ConferenceBuilder builder, string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < minName)
            {
                return ConferenceNameErrors.ConferenceNameTooShort;
            }
            if (name.Length > maxName)
            {
                return ConferenceNameErrors.ConferenceNameTooLong;
            }

            return ErrorType.None;

        }

        public static ErrorType ValidateDescription(this ConferenceBuilder builder, string description)
        {
            if (string.IsNullOrEmpty(description) || description.Length < minDesc)
            {
                return ConferenceDescriptionErrors.ConferenceDescriptionTooShort;
            }
            if (description.Length > maxDesc)
            {
                return ConferenceDescriptionErrors.ConferenceDescriptionTooLong;
            }

            return ErrorType.None;

        }

        public static ErrorType ValidateDates(this ConferenceBuilder builder, DateTime startDate, DateTime endDate)
        {
            if (startDate < DateTime.UtcNow.AddDays(1))
            {
                return ConferenceDatesErrors.ConferenceTooEarly;
            }
            if (endDate < startDate)
            {
                return ConferenceDatesErrors.ConferenceEndBeforeStarts;
            }
            if (endDate - startDate < TimeSpan.FromHours(1))
            {
                return ConferenceDatesErrors.ConferenceTooShort;
            }

            return ErrorType.None;
        }

        public static ErrorType ValidateLectures(this ConferenceBuilder builder, List<Lecture> lectures)
        {

            var startDates = new List<DateTime>() { builder.StartDateTimeUtc };
            var endDates = new List<DateTime>() { builder.EndDateTimeUtc };

            foreach (Lecture lecture in lectures)
            {
                if (startDates.Any(x => x <= lecture.EndTimeUtc && x >= lecture.StartTimeUtc))
                {
                    return LecturesErrors.TimeCollapsing;
                }

                if (endDates.Any(x => x <= lecture.EndTimeUtc && x >= lecture.StartTimeUtc))
                {
                    return LecturesErrors.TimeCollapsing;
                }

                startDates.Add(lecture.StartTimeUtc);
                endDates.Add(lecture.EndTimeUtc);
            }
            
            return ErrorType.None;
        }

        public static ErrorType ValidateTicketPool(this ConferenceBuilder builder, TicketPool ticketPool)
        {

            if (ticketPool.BasicTicketPriceEur < 1 || ticketPool.VipTicketsPool < 1)
            {
                return TicketPoolErrors.TicketsNumberLessThanOne;
            }
            return ErrorType.None;
        }
    }
}
