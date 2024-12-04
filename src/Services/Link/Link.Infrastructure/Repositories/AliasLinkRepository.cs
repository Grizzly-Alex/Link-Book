using Link.Core.Entities.Link;
using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Link.Infrastructure.Repositories;

public class AliasLinkRepository : IAliasLinkRepository
{
    private readonly DbSet<AliasLink> _linkTableDb;
    private readonly Func<CancellationToken, Task<int>> _commit;

    public AliasLinkRepository(AppDbContext context)
    {
        _commit = context.SaveChangesAsync;
        _linkTableDb = context.Set<AliasLink>();
    }

    public async Task<AliasLink?> Get(
        Expression<Func<AliasLink, bool>> predicate,
        CancellationToken token = default)
    {
        return await _linkTableDb
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate, token);
    }
    public async Task<IEnumerable<AliasLink>> GetAll(
        Expression<Func<AliasLink, bool>> predicate,
        Func<IQueryable<AliasLink>, IOrderedQueryable<AliasLink>>? orderBy = null,
        CancellationToken token = default)
    {
        var query = _linkTableDb.AsNoTracking()
            .Include(i => i.Category)
            .Where(predicate);

        return orderBy is not null
            ? await orderBy(query).ToListAsync(token)
            : await query.ToListAsync(token);
    }

    public async Task<AliasLink?> Create(AliasLink entity, CancellationToken token = default)
    {
        var entityFromDb = await _linkTableDb.AddAsync(entity, token);
        var changes = await _commit(token);

        return entityFromDb.Entity != null && changes != default 
            ? entityFromDb.Entity : null;
    }
    public async Task<bool> Update(AliasLink entity, CancellationToken token = default)
    {
        var rowsUpdated = await _linkTableDb.Where(item => item.Id == entity.Id)
            .ExecuteUpdateAsync(updates => 
                updates.SetProperty(item => item.CategoryId, entity.CategoryId)
                .SetProperty(item => item.AliasUrl, entity.AliasUrl)
                .SetProperty(item => item.OriginalUrl, entity.OriginalUrl)
                .SetProperty(item => item.Favorite, entity.Favorite),
                token);

        return rowsUpdated != 0;
    }

    public async Task<bool> Delete<Guid>(Guid id, CancellationToken token = default)
    {
        var rowsDeleted = await _linkTableDb.Where(item => item.Id.Equals(id))
            .ExecuteDeleteAsync(token);

        return rowsDeleted != 0;
    }
}
