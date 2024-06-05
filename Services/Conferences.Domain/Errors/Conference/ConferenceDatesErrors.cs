namespace Conferences.Domain.Errors.Conference
{
    public static class ConferenceDatesErrors
    {
        public static readonly ErrorType ConferenceTooEarly = new("Conference need to be planned at least one day earlier");
        public static readonly ErrorType ConferenceEndBeforeStarts = new("Conference can not end before it starts!");
        public static readonly ErrorType ConferenceTooShort = new("Conference must take at least one hour");
    }
}
