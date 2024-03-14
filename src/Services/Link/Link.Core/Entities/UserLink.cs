namespace Link.Core.Entities;

public sealed class UserLink : BaseEntity
{
    public required string UserId { get; init; }
    public required string AliasUrl { get; init; }
    public required string OriginalUrl { get; init; }
    public string? Tag { get; init; }
    public bool Favorite { get; init; }
}
