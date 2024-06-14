namespace Link.Core.Entities;

public sealed class CategoryLink : BaseEntity<Guid>
{
    public string UserId { get; init; }
    public string Name { get; init; }

    public CategoryLink()
    {            
    }

    public CategoryLink(string userId, string name)
    {
        UserId = userId;
        Name = name;
    }
}