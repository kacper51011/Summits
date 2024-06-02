using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Errors
{

    public static class ConferenceErrors
    {
        public static readonly ErrorType ConferenceCanceled = new("Can not modify canceled conference");
        public static readonly ErrorType ConferenceEnded = new("Can not modify ended conference");
        public static readonly ErrorType ConferenceTooEarly = new("Conference need to be planned at least one day earlier");
        public static readonly ErrorType ConferenceEndBeforeStarts = new("Conference can not end before it starts!");
        public static readonly ErrorType ConferenceTooShort = new("Conference must take at least one hour");

        public static readonly ErrorType ConferenceNameTooShort = new("Name of Conference is too short");
        public static readonly ErrorType ConferenceNameTooLong = new("Name of Conference is too long");
        public static readonly ErrorType ConferenceDescriptionTooShort = new("Description of Conference is too short");
        public static readonly ErrorType ConferenceDescriptionTooLong = new("Description of Conference is too long");
    }
}
