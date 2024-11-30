namespace NotificationService;

public sealed record File
{
    public string Name { get; set; }

    public byte[] Bytes { get; set; }

    public string ContentType
    {
        get
        {
            new FileExtensionContentTypeProvider().TryGetContentType(Name, out var contentType);

            return contentType;
        }
    }
}
