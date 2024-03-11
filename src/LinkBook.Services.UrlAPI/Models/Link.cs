namespace LinkBook.Services.UrlAPI.Models;

public sealed class Link
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public string AliasUrl{ get; set; }
    public string OriginalUrl { get; set; }
    public string Tag { get; set; }
    public bool Favorite { get; set; }
}
