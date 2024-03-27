namespace Link.Core.Entities;

public sealed class LinkCategory : BaseEntity<Guid>
{
    public string UserId { get; init; }
    public string Name { get; init; }

    public LinkCategory()
    {            
    }

    public LinkCategory(string userId, string name)
    {
        UserId = userId;
        Name = name;
    }
}