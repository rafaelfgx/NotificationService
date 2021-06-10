using System.Threading.Tasks;

namespace NotificationService
{
    public interface IEmailService
    {
        Task<IResult> SendAsync(Email email);
    }
}
