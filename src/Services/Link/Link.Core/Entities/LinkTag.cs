namespace Link.Core.Entities;

public sealed class LinkTag : BaseEntity<Guid>
{
    public string UserId { get; init; }
    public string Name { get; init; }

    public LinkTag()
    {            
    }

    public LinkTag(string userId, string name)
    {
        UserId = userId;
        Name = name;
    }
}