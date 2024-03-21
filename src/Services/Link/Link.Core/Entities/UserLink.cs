namespace Link.Core.Entities;

public sealed class UserLink : BaseEntity<Guid>
{
    public required string UserId { get; init; }
    public required string AliasUrl { get; init; }
    public required string OriginalUrl { get; init; }
    public bool Favorite { get; init; }
    public Guid TagId { get; init; }
    public LinkTag Tag { get; init; }
}
