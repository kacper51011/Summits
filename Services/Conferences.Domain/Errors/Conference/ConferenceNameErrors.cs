namespace Conferences.Domain.Errors.Conference
{
    public static class ConferenceNameErrors
    {
        public static readonly ErrorType ConferenceNameTooShort = new("Name of Conference is too short");
        public static readonly ErrorType ConferenceNameTooLong = new("Name of Conference is too long");
    }
}
