namespace Link.Core.Entities;

public sealed class LinkTag : BaseEntity<Guid>
{
    public string UserId { get; init; }
    public string Name { get; init; }
}