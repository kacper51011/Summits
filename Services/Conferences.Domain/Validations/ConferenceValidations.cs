using Conferences.Domain.Aggregates;
using Conferences.Domain.Errors;
using Conferences.Domain.Errors.Conference;
using Conferences.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Validations
{
    internal static class ConferenceValidations
    {
        internal static ErrorType DefaultValidation(this Conference conference)
        {
            if (conference.HasBeenCanceled)
            {
                return ConferenceTerminationsExceptions.ConferenceAlreadyCanceled;
            }
            if (conference.HasEnded)
            {
                return ConferenceTerminationsExceptions.ConferenceAlreadyEnded;
            }
            return ErrorType.None;

        }

        internal static ErrorType StartAndEndDatesValidation(this Conference conference, DateTime startUtc, DateTime endUtc)
        {
            if (startUtc < DateTime.UtcNow.AddDays(1))
            {
                return ConferenceDatesErrors.ConferenceTooEarly;
            }
            if (endUtc < startUtc)
            {
                return ConferenceDatesErrors.ConferenceEndBeforeStarts;

            }
            if (endUtc - startUtc < TimeSpan.FromHours(1))
            {
                return ConferenceDatesErrors.ConferenceTooShort;

            }

            return ErrorType.None;

        }


    }
}
