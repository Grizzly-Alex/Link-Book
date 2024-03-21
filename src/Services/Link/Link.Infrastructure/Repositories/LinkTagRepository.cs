using Link.Core.Entities;
using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Link.Infrastructure.Repositories;

public class LinkTagRepository : IRepository<LinkTag>
{
    private readonly DbSet<LinkTag> _tagTableDb;

    public LinkTagRepository(AppDbContext context)
    {
        _tagTableDb = context.Set<LinkTag>();
    }

    public async Task<LinkTag?> Get(
        Expression<Func<LinkTag, bool>> predicate,
        CancellationToken token = default)
    {
        return await _tagTableDb
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate, token);
    }

    public async Task<IEnumerable<LinkTag>?> GetAll(
        Expression<Func<LinkTag, bool>> predicate,
        Func<IQueryable<LinkTag>, IOrderedQueryable<LinkTag>>? orderBy = null,
        CancellationToken token = default)
    {
        var query = _tagTableDb.AsNoTracking().Where(predicate);
            
        return orderBy is not null
            ? await orderBy(query).ToListAsync(token)
            : await query.ToListAsync(token);
    }

    public async Task<bool> Create(LinkTag entity, CancellationToken token = default)
    {
        var entityFromDb = await _tagTableDb.AddAsync(entity, token);
        
        return entityFromDb.Entity is not null;
    }
    public async Task<bool> Update(LinkTag entity, CancellationToken token = default)
    {
        var rowsUpdated = await _tagTableDb.Where(item => item.Id == entity.Id)
            .ExecuteUpdateAsync(updates =>
                updates.SetProperty(item => item.Name, entity.Name),
                token);

        return rowsUpdated != 0;
    }

    public async Task<bool> Delete(LinkTag entity, CancellationToken token = default)
    {
        var rowsDeleted = await _tagTableDb.Where(item => item.Id == entity.Id)
            .ExecuteDeleteAsync(token);

        return rowsDeleted != 0;
    }
}
