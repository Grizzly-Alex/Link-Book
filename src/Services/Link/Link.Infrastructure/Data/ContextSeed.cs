using Link.Core.Entities;
using Link.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Link.Infrastructure.Data;

public sealed class ContextSeed(AppDbContext dbContext) : IDbInitializer
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
            await _dbContext.Tags.AddRangeAsync(GetTags()!);
            await _dbContext.SaveChangesAsync();
        }
    }

    private IEnumerable<LinkCategory> GetTags()
    {
        string path = Path.Combine("Data", "SeedData", "categories.json");
        string categoriesData = File.ReadAllText(path);

        return string.IsNullOrEmpty(categoriesData) ? [] : JsonSerializer.Deserialize<List<LinkCategory>>(categoriesData);
    }
}
