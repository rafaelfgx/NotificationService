namespace NotificationService;

public sealed class SmtpValidator : AbstractValidator<Smtp>
{
    public SmtpValidator()
    {
        RuleFor(smtp => smtp.Host).NotEmpty();
        RuleFor(smtp => smtp.Port).NotEmpty();
        RuleFor(smtp => smtp.Timeout).NotEmpty();
        RuleFor(smtp => smtp.User).NotEmpty().EmailAddress();
        RuleFor(smtp => smtp.Password).NotEmpty();
        RuleFor(smtp => smtp.Display).NotEmpty();
    }
}
