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
        public static void ValidateName(this ConferenceBuilder builder, string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < minName)
            {
                builder.ErrorType = ConferenceNameErrors.ConferenceNameTooShort;
                return;
            }
            if (name.Length > maxName)
            {
                builder.ErrorType = ConferenceNameErrors.ConferenceNameTooLong;
                return;
            }

            builder.Name = name;

        }

        public static void ValidateDescription(this ConferenceBuilder builder, string description)
        {
            if (string.IsNullOrEmpty(description) || description.Length < minDesc)
            {
                builder.ErrorType = ConferenceDescriptionErrors.ConferenceDescriptionTooShort;
                return;
            }
            if (description.Length > maxDesc)
            {
                builder.ErrorType = ConferenceDescriptionErrors.ConferenceDescriptionTooLong;
                return;
            }

            builder.Description = description;

        }

        public static void ValidateDates(this ConferenceBuilder builder, DateTime startDate, DateTime endDate)
        {
            if (startDate < DateTime.UtcNow.AddDays(1))
            {
                builder.ErrorType = ConferenceDatesErrors.ConferenceTooEarly;
            }
            if (endDate < startDate)
            {
                builder.ErrorType = ConferenceDatesErrors.ConferenceEndBeforeStarts;
            }
            if (endDate - startDate < TimeSpan.FromHours(1))
            {
                builder.ErrorType = ConferenceDatesErrors.ConferenceTooShort;
            }
        }

        public static void ValidateLectures(this ConferenceBuilder builder, List<Lecture> lectures)
        {
            // expensive validation - early return
            if (builder.ErrorType != ErrorType.None)
            {
                return;
            }

            var startDates = new List<DateTime>() { builder.StartDateTimeUtc };
            var endDates = new List<DateTime>() { builder.EndDateTimeUtc };

            foreach (Lecture lecture in lectures)
            {
                if (startDates.Any(x => x <= lecture.EndTimeUtc && x >= lecture.StartTimeUtc))
                {
                    builder.ErrorType = LecturesErrors.TimeCollapsing;
                    return;
                }

                if (endDates.Any(x => x <= lecture.EndTimeUtc && x >= lecture.StartTimeUtc))
                {
                    builder.ErrorType = LecturesErrors.TimeCollapsing;
                    return;
                }

                startDates.Add(lecture.StartTimeUtc);
                endDates.Add(lecture.EndTimeUtc);
            }
        }

        public static void ValidateTicketPool(this ConferenceBuilder builder, TicketPool ticketPool)
        {

            if (ticketPool.BasicTicketPriceEur < 1 || ticketPool.VipTicketsPool < 1)
            {
                builder.ErrorType = TicketPoolErrors.TicketsNumberLessThanOne;
            }
        }
    }
}
