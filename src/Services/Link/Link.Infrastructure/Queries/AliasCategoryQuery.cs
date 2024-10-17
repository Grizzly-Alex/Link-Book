using Link.Core.Entities;
using Link.Core.Interfaces;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Link.Infrastructure.Queries
{
    public class AliasCategoryQuery(AppDbContext context) : IAliasCategoryQuery<Guid?>
    {
        private readonly DbSet<AliasCategory> _categoriesTableDb = context.Set<AliasCategory>();

        public async Task<bool> Contains(AliasCategory entity, CancellationToken token = default)
        {
            return await _categoriesTableDb.AnyAsync(item =>
                    item.UserId == entity.UserId
                    && item.Name == entity.Name,
                    token);
        }

        public async Task<bool> Contains(Guid? id, CancellationToken token = default)
        {
            return await _categoriesTableDb.AnyAsync(item => item.Id == id,
                token);
        }
    }
}
