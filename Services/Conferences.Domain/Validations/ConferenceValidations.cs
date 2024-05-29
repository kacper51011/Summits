using Conferences.Domain.Aggregates;
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
        internal static void DefaultValidation(this Conference conference)
        {
            if (conference.HasBeenCanceled)
            {
                throw new DomainException("Can not modify canceled conference");
            }
            if (conference.HasEnded)
            {
                throw new DomainException("Can not modify already ended conference");
            }

        }

        internal static void StartAndEndDatesValidation(this Conference conference, DateTime startUtc, DateTime endUtc)
        {
            if (startUtc < DateTime.UtcNow.AddDays(1))
            {
                throw new DomainException("Conference need to be planned at least one day earlier");
            }
            if (endUtc < startUtc)
            {
                throw new DomainException("Conference can not end before it starts!");
            }
            if (endUtc - startUtc < TimeSpan.FromHours(1))
            {
                throw new DomainException("Conference must take at least one hour");
            }

        }


    }
}
