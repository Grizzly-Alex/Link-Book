using Link.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Link.Infrastructure.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserLink> Links { get; set; }
    public DbSet<LinkCategory> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}