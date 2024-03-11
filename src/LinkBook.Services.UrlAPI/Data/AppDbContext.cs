using LinkBook.Services.UrlAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkBook.Services.UrlAPI.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Link> Links { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var linkModel = modelBuilder.Entity<Link>();

        linkModel.ToTable("Links").HasKey(t => t.Id);
        linkModel.Property(t => t.Id).HasColumnType("UNIQUEIDENTIFIER");
        linkModel.Property(t => t.UserId)
            .IsRequired(true)
            .HasColumnType("NVARCHAR");
        linkModel.Property(t => t.AliasUrl)
            .IsRequired(true)
            .HasColumnType("NVARCHAR");
        linkModel.Property(t => t.OriginalUrl)
            .IsRequired(true)
            .HasColumnType("NVARCHAR");
        linkModel.Property(t => t.Tag)
            .IsRequired(false)
            .HasColumnType("NVARCHAR");
    }
}
