namespace NotificationService;

public sealed record Email
{
    public string Subject { get; set; }

    public string Body { get; set; }

    public IList<To> To { get; set; } = new List<To>();

    public IList<To> CopyTo { get; set; } = new List<To>();

    public IList<To> BlindCopyTo { get; set; } = new List<To>();

    public IList<File> Files { get; set; } = new List<File>();
}
