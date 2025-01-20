using Link.Core.Entities.Category;
using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Link.Infrastructure.Repositories;

public class AliasCategoryRepository : IAliasCategoryRepository
{
    private readonly DbSet<AliasCategory> _categoriesTableDb;
    private readonly Func<CancellationToken, Task<int>> _commit;

    public AliasCategoryRepository(AppDbContext context) 
    {
        _commit = context.SaveChangesAsync;
        _categoriesTableDb = context.Set<AliasCategory>();
    }

    public async Task<AliasCategory?> Get(
        Expression<Func<AliasCategory, bool>> predicate,
        CancellationToken token = default)
    {
        return await _categoriesTableDb
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate, token);
    }

    public async Task<IEnumerable<AliasCategory>> GetAll(
        Expression<Func<AliasCategory, bool>> predicate,
        Func<IQueryable<AliasCategory>, IOrderedQueryable<AliasCategory>>? orderBy = null,
        CancellationToken token = default)
    {
        var query = _categoriesTableDb.AsNoTracking().Where(predicate);
            
        return orderBy is not null
            ? await orderBy(query).ToListAsync(token)
            : await query.ToListAsync(token);
    }

    public async Task<AliasCategory?> Create(AliasCategory entity, CancellationToken token = default)
    {
        var entityFromDb = await _categoriesTableDb.AddAsync(entity, token);
        var changes = await _commit(token);


        return entityFromDb.Entity != null && changes != default 
            ? entityFromDb.Entity : null;
    }

    public async Task<bool> Update(AliasCategory entity, CancellationToken token = default)
    {
        var rowsUpdated = await _categoriesTableDb.Where(item => item.Id == entity.Id)
            .ExecuteUpdateAsync(updates =>
                updates.SetProperty(item => item.Name, entity.Name),
                token);

        return rowsUpdated != 0;
    }

    public async Task<bool> Delete<Guid>(Guid id, CancellationToken token = default)
    {
        var rowsDeleted = await _categoriesTableDb.Where(item => item.Id.Equals(id))
            .ExecuteDeleteAsync(token);

        return rowsDeleted != 0;
    }
}
