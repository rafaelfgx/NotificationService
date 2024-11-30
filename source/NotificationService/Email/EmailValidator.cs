namespace NotificationService;

public sealed class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(email => email.Subject).NotEmpty();
        RuleFor(email => email.Body).NotEmpty();
        RuleFor(email => email.To).NotEmpty();
        RuleForEach(email => email.To).SetValidator(new ToValidator());
        RuleForEach(email => email.CopyTo).SetValidator(new ToValidator());
        RuleForEach(email => email.BlindCopyTo).SetValidator(new ToValidator());
        RuleForEach(email => email.Files).SetValidator(new FileValidator());
    }
}
