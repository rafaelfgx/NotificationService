namespace NotificationService;

public sealed class EmailService : IEmailService
{
    private readonly Smtp _smtp;

    public EmailService(AppSettings appSettings) => _smtp = appSettings.Smtp;

    public async Task<Result> SendAsync(Email email)
    {
        var validation = await ValidateAsync(_smtp);

        if (validation.IsError) return validation;

        validation = await ValidateAsync(email);

        if (validation.IsError) return validation;

        using var mailMessage = CreateMailMessage(email);

        using var smtpClient = CreateSmtpClient();

        smtpClient.Send(mailMessage);

        return Result.Success();
    }

    private static Result GetResult(ValidationResult result)
    {
        return result.IsValid ? Result.Success() : Result.Error(result.ToString());
    }

    private static Attachment ToAttachment(File file)
    {
        return new Attachment(new MemoryStream(file.Bytes), file.Name, file.ContentType);
    }

    private static MailAddress ToMailAddress(To to)
    {
        return new MailAddress(to.Address, to.Display, Encoding.UTF8);
    }

    private static async Task<Result> ValidateAsync(Smtp smtp)
    {
        return GetResult(await new SmtpValidator().ValidateAsync(smtp));
    }

    private static async Task<Result> ValidateAsync(Email email)
    {
        return GetResult(await new EmailValidator().ValidateAsync(email));
    }

    private MailMessage CreateMailMessage(Email email)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_smtp.User, _smtp.Display, Encoding.UTF8),
            Subject = email.Subject,
            Body = email.Body,
            IsBodyHtml = true
        };

        email.To.ToList().ForEach(to => mailMessage.To.Add(ToMailAddress(to)));

        email.CopyTo?.ToList().ForEach(to => mailMessage.CC.Add(ToMailAddress(to)));

        email.BlindCopyTo?.ToList().ForEach(to => mailMessage.Bcc.Add(ToMailAddress(to)));

        email.Files?.ToList().ForEach(file => mailMessage.Attachments.Add(ToAttachment(file)));

        return mailMessage;
    }

    private SmtpClient CreateSmtpClient()
    {
        return new SmtpClient(_smtp.Host, _smtp.Port)
        {
            Credentials = new NetworkCredential(_smtp.User, _smtp.Password),
            EnableSsl = _smtp.Ssl,
            Timeout = _smtp.Timeout * 1000
        };
    }
}
