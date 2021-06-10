namespace NotificationService
{
    public interface IResult
    {
        string Message { get; }

        bool Succeeded { get; }
    }
}
