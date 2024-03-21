using System.Linq.Expressions;

namespace Link.Core.Interfaces;

public interface IRepository<T> 
    where T : IAggregateRoot
{
    Task<IEnumerable<T>?> GetAll(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        CancellationToken token = default);
    Task<T?> Get(Expression<Func<T, bool>> predicate, 
        CancellationToken token = default);
    Task<bool> Create(T entity, CancellationToken token = default);
    Task<bool> Update(T entity, CancellationToken token = default);
    Task<bool> Delete(T entity, CancellationToken token = default);
}
