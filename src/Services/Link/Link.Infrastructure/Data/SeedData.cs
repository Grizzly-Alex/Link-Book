using Link.Core.Entities;
using Link.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Link.Infrastructure.Data;

public class SeedData(AppDbContext dbContext) : IDbInitializer
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task Initialize()
    {
        if (_dbContext.Database.IsSqlServer() && _dbContext.Database.GetPendingMigrations().Any())
        {
            await _dbContext.Database.MigrateAsync();
        }

        if (!await _dbContext.Tags.AnyAsync())
        {
            await _dbContext.Tags.AddRangeAsync(GetTags());
            await _dbContext.SaveChangesAsync();
        }
    }

    private IEnumerable<LinkTag> GetTags()
    {
        return new List<LinkTag>
        {
            new (string.Empty, "Social Networks"),
            new (string.Empty, "Forums"),
            new (string.Empty, "Mails"),
        };
    }
}
