using Link.Core.Entities;
using Link.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Link.Infrastructure.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserLink> Links { get; set; }
    public DbSet<LinkTag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}