using Link.Core.Entities;
using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Link.Infrastructure.Repositories;

public class CategoryLinkRepository : IRepository<CategoryLink>
{
    private readonly DbSet<CategoryLink> _categoriesTableDb;
    private readonly AppDbContext _appDbContext;

    public CategoryLinkRepository(AppDbContext context)
    {
        _appDbContext = context;
        _categoriesTableDb = context.Set<CategoryLink>();
    }

    public async Task<CategoryLink?> Get(
        Expression<Func<CategoryLink, bool>> predicate,
        CancellationToken token = default)
    {
        return await _categoriesTableDb
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate, token);
    }

    public async Task<IEnumerable<CategoryLink>?> GetAll(
        Expression<Func<CategoryLink, bool>> predicate,
        Func<IQueryable<CategoryLink>, IOrderedQueryable<CategoryLink>>? orderBy = null,
        CancellationToken token = default)
    {
        var query = _categoriesTableDb.AsNoTracking().Where(predicate);
            
        return orderBy is not null
            ? await orderBy(query).ToListAsync(token)
            : await query.ToListAsync(token);
    }

    public async Task<bool> Create(CategoryLink entity, CancellationToken token = default)
    {
        var entityFromDb = await _categoriesTableDb.AddAsync(entity, token);
        var changes = await _appDbContext.SaveChangesAsync(token);

        bool result = entityFromDb.Entity != null && changes != default;

        return result;
    }

    public async Task<bool> Update(CategoryLink entity, CancellationToken token = default)
    {
        var rowsUpdated = await _categoriesTableDb.Where(item => item.Id == entity.Id)
            .ExecuteUpdateAsync(updates =>
                updates.SetProperty(item => item.Name, entity.Name),
                token);

        return rowsUpdated != 0;
    }

    public async Task<bool> Delete(CategoryLink entity, CancellationToken token = default)
    {
        var rowsDeleted = await _categoriesTableDb.Where(item => item.Id == entity.Id)
            .ExecuteDeleteAsync(token);

        return rowsDeleted != 0;
    }
}
