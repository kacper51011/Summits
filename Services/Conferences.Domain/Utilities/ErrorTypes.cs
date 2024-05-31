using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Utilities
{
    public sealed record ErrorType(string message)
    {
        public static readonly ErrorType None = new(string.Empty);
    }

    public static class TicketPoolErrors
    {
        public static readonly ErrorType TicketPoolAlreadyClosed = new("Ticket pool has already been closed");
        public static readonly ErrorType TicketPoolAlreadyOpened = new("Ticket pool has already been opened");
    }

    public static class ConferenceErrors
    {
        public static readonly ErrorType ConferenceCanceled = new("Can not modify canceled conference");
        public static readonly ErrorType ConferenceEnded = new("Can not modify ended conference");
        public static readonly ErrorType ConferenceTooEarly = new("Conference need to be planned at least one day earlier");
        public static readonly ErrorType ConferenceEndBeforeStarts = new("Conference can not end before it starts!");
        public static readonly ErrorType ConferenceTooShort = new("Conference must take at least one hour");
    }
}
