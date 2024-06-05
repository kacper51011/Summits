using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Errors.Conference
{
    public static class ConferenceTerminationsExceptions
    {
        public static ErrorType ConferenceAlreadyEnded => new("Can not modify ended conference");
        public static ErrorType ConferenceAlreadyCanceled => new("Can not modify canceled conference");
    }
}
