namespace NotificationService;

public interface IEmailService
{
    Task<Result> SendAsync(Email email);
}
