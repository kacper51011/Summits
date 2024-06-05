namespace Conferences.Domain.Errors.TicketPools
{
    public static class TicketPoolErrors
    {
        public static readonly ErrorType TicketPoolAlreadyClosed = new("Ticket pool has already been closed");
        public static readonly ErrorType TicketPoolAlreadyOpened = new("Ticket pool has already been opened");
        public static readonly ErrorType TicketsNumberLessThanOne = new("Ticket pool number can`t be less than one");
    }
}
