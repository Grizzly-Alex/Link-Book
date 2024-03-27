using Link.Core.Entities;
using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Link.Infrastructure.Repositories;

public class LinkCategoryRepository : IRepository<LinkCategory>
{
    private readonly DbSet<LinkCategory> _categoriesTableDb;

    public LinkCategoryRepository(AppDbContext context)
    {
        _categoriesTableDb = context.Set<LinkCategory>();
    }

    public async Task<LinkCategory?> Get(
        Expression<Func<LinkCategory, bool>> predicate,
        CancellationToken token = default)
    {
        return await _categoriesTableDb
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate, token);
    }

    public async Task<IEnumerable<LinkCategory>?> GetAll(
        Expression<Func<LinkCategory, bool>> predicate,
        Func<IQueryable<LinkCategory>, IOrderedQueryable<LinkCategory>>? orderBy = null,
        CancellationToken token = default)
    {
        var query = _categoriesTableDb.AsNoTracking().Where(predicate);
            
        return orderBy is not null
            ? await orderBy(query).ToListAsync(token)
            : await query.ToListAsync(token);
    }

    public async Task<bool> Create(LinkCategory entity, CancellationToken token = default)
    {
        var entityFromDb = await _categoriesTableDb.AddAsync(entity, token);
        
        return entityFromDb.Entity is not null;
    }
    public async Task<bool> Update(LinkCategory entity, CancellationToken token = default)
    {
        var rowsUpdated = await _categoriesTableDb.Where(item => item.Id == entity.Id)
            .ExecuteUpdateAsync(updates =>
                updates.SetProperty(item => item.Name, entity.Name),
                token);

        return rowsUpdated != 0;
    }

    public async Task<bool> Delete(LinkCategory entity, CancellationToken token = default)
    {
        var rowsDeleted = await _categoriesTableDb.Where(item => item.Id == entity.Id)
            .ExecuteDeleteAsync(token);

        return rowsDeleted != 0;
    }
}
