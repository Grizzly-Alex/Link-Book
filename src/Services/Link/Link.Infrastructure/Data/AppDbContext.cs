using Link.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LinkBook.Services.UrlAPI.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserLink> Links { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}