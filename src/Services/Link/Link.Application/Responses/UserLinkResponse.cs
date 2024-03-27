namespace Link.Application.Responses;

public sealed class UserLinkResponse
{
    public Guid Id { get; set; }    
    public string AliasUrl { get; set; }
    public string OriginalUrl { get; set; }
    public bool Favorite { get; set; }
    public string TagName { get; set; }
}
