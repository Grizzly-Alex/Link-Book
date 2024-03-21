using Link.Core.Interfaces;


namespace Link.Core.Entities;

public abstract class BaseEntity<T> : IAggregateRoot
{
    public required T Id { get; init; }
}
