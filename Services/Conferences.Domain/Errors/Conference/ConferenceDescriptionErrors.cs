namespace Conferences.Domain.Errors.Conference
{
    public static class ConferenceDescriptionErrors
    {


        public static readonly ErrorType ConferenceDescriptionTooShort = new("Description of Conference is too short");
        public static readonly ErrorType ConferenceDescriptionTooLong = new("Description of Conference is too long");
    }
}
