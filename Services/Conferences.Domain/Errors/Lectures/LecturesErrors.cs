namespace Conferences.Domain.Errors.Lectures
{
    public static class LecturesErrors
    {
        public static readonly ErrorType TimeCollapsing = new("The time of one of the lectures collapse with others or with time boundaries of conference");

    }
}
