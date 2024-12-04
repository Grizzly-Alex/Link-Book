namespace Link.Core.Entities.Category;

public sealed class AliasCategory : BaseEntity<Guid>
{
    public string UserId { get; init; }
    public string Name { get; init; }

    public AliasCategory()
    {
    }

    public AliasCategory(string userId, string name)
    {
        UserId = userId;
        Name = name;
    }


    public override string ToString() => Name;

    public override bool Equals(object? obj)
    {
        var category = obj as AliasCategory;

        return category is not null
            && category.UserId == UserId
            && category.Name == Name;
    }
}