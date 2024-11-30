namespace NotificationService;

public sealed class ToValidator : AbstractValidator<To>
{
    public ToValidator()
    {
        RuleFor(to => to.Address).NotEmpty().EmailAddress();
        RuleFor(to => to.Display).NotEmpty();
    }
}
