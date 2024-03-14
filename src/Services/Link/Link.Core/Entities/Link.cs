namespace Link.Core.Entities;

public sealed class Link : BaseEntity
{
    public string UserId { get; set; }
    public string AliasUrl{ get; set; }
    public string OriginalUrl { get; set; }
    public string Tag { get; set; }
    public bool Favorite { get; set; }
}
