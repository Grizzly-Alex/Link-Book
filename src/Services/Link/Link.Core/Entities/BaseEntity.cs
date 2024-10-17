using Link.Core.Interfaces;


namespace Link.Core.Entities;

public abstract class BaseEntity<T> : IAggregateRoot
    where T : struct
{
    public T Id { get; init; }
}
