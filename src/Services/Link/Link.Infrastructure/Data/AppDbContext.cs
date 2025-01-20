using Link.Core.Entities.Category;
using Link.Core.Entities.Link;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Link.Infrastructure.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<AliasLink> Links { get; set; }
    public DbSet<AliasCategory> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}