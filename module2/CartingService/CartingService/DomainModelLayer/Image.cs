namespace CartingService.DomainModelLayer;

public record Image
{
    public Uri Url { get; set; }

    public string AltText { get; set; } = string.Empty;

    public Image(Uri url)
    {
        Url = url;
    }

    public Image(Uri url, string altText)
    {
        Url = url;
        AltText = altText;
    }
}