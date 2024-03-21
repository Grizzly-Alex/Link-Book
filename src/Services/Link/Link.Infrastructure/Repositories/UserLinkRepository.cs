using Link.Core.Entities;
using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Link.Infrastructure.Repositories;

public class UserLinkRepository : IRepository<UserLink>
{
    private readonly DbSet<UserLink> _linkTableDb;

    public UserLinkRepository(AppDbContext context)
    {
        _linkTableDb = context.Set<UserLink>();
    }

    public async Task<UserLink?> Get(
        Expression<Func<UserLink, bool>> predicate,
        CancellationToken token = default)
    {
        return await _linkTableDb
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate, token);
    }
    public async Task<IEnumerable<UserLink>?> GetAll(
        Expression<Func<UserLink, bool>> predicate,
        Func<IQueryable<UserLink>, IOrderedQueryable<UserLink>>? orderBy = null,
        CancellationToken token = default)
    {
        var query = _linkTableDb.AsNoTracking()
            .Include(i => i.Tag)
            .Where(predicate);

        return orderBy is not null
            ? await orderBy(query).ToListAsync(token)
            : await query.ToListAsync(token);
    }

    public async Task<bool> Create(UserLink entity, CancellationToken token = default)
    {
        var entityFromDb = await _linkTableDb.AddAsync(entity, token);

        return entityFromDb.Entity is not null;
    }
    public async Task<bool> Update(UserLink entity, CancellationToken token = default)
    {
        var rowsUpdated = await _linkTableDb.Where(item => item.Id == entity.Id)
            .ExecuteUpdateAsync(updates => 
                updates.SetProperty(item => item.TagId, entity.TagId)
                .SetProperty(item => item.AliasUrl, entity.AliasUrl)
                .SetProperty(item => item.OriginalUrl, entity.OriginalUrl)
                .SetProperty(item => item.Favorite, entity.Favorite),
                token);

        return rowsUpdated != 0;
    }

    public async Task<bool> Delete(UserLink entity, CancellationToken token = default)
    {
        var rowsDeleted = await _linkTableDb.Where(item => item.Id == entity.Id)
            .ExecuteDeleteAsync(token);

        return rowsDeleted != 0;
    }
}
