using Link.Core.Entities;

namespace Link.Core.Interfaces
{
    public interface IAliasCategoryQuery<T>
    {
        Task<bool> Contains(AliasCategory entity, CancellationToken token = default);
        Task<bool> Contains(T id, CancellationToken token = default);
    }
}
