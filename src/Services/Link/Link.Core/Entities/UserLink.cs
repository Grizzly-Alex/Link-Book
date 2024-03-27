namespace Link.Core.Entities;

public sealed class UserLink : BaseEntity<Guid>
{
    public required string UserId { get; init; }
    public required string AliasUrl { get; init; }
    public required string OriginalUrl { get; init; }
    public bool Favorite { get; init; }
    public Guid CategoryId { get; init; }
    public LinkCategory Category { get; init; }

    public UserLink()
    {          
    }

    public UserLink(string userId, string aliasUrl, string originalUrl,bool favorite, Guid categoryId)
    {
        UserId = userId;
        AliasUrl = aliasUrl;
        OriginalUrl = originalUrl;
        Favorite = favorite;
        CategoryId = categoryId;           
    }
}
