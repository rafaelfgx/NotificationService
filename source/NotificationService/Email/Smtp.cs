namespace NotificationService;

public sealed record Smtp
{
    public string Host { get; set; }

    public int Port { get; set; }

    public int Timeout { get; set; }

    public bool Ssl { get; set; }

    public string User { get; set; }

    public string Password { get; set; }

    public string Display { get; set; }
}
