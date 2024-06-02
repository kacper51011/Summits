namespace Conferences.Domain.Errors
{
    public sealed record ErrorType(string message)
    {
        public static readonly ErrorType None = new(string.Empty);
    }
}
