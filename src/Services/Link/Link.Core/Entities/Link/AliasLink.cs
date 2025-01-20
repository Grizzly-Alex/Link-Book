using Link.Core.Entities.Category;

namespace Link.Core.Entities.Link;

public sealed class AliasLink : BaseEntity<Guid>
{
    public required string UserId { get; init; }
    public required string AliasUrl { get; init; }
    public required string OriginalUrl { get; init; }
    public bool Favorite { get; init; }
    public Guid? CategoryId { get; init; }
    public AliasCategory Category { get; init; }

    public AliasLink()
    {
    }

    public AliasLink(string userId, string aliasUrl, string originalUrl, bool favorite, Guid? categoryId)
    {
        UserId = userId;
        AliasUrl = aliasUrl;
        OriginalUrl = originalUrl;
        Favorite = favorite;
        CategoryId = categoryId;
    }


    public override string ToString() => AliasUrl;

    public override bool Equals(object? obj)
    {
        var link = obj as AliasLink;

        return link is not null
            && link.UserId == UserId
            && link.AliasUrl == AliasUrl;
    }
}