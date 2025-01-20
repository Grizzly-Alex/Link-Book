using Link.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Link.Infrastructure.Data;

public sealed class Initializer(AppDbContext dbContext) : IDbInitializer
{
    private readonly AppDbContext _dbContext = dbContext;


    public void Initialize()
    {
        if (_dbContext.Database.IsSqlServer() && _dbContext.Database.GetPendingMigrations().Any())
        {
            _dbContext.Database.Migrate();
        }
    }
}