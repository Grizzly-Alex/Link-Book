using Link.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Link.Infrastructure.Data.Configurations;

public class UserLinkConfig : IEntityTypeConfiguration<UserLink>
{
    public void Configure(EntityTypeBuilder<UserLink> builder)
    {
        builder.ToTable("Links").HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnType("UNIQUEIDENTIFIER");
        builder.Property(t => t.UserId)
            .IsRequired(true)
            .HasColumnType("NVARCHAR(max)");

        builder.Property(t => t.AliasUrl)
            .IsRequired(true)
            .HasColumnType("NVARCHAR(max)");
        builder.Property(t => t.OriginalUrl)
            .IsRequired(true)
            .HasColumnType("NVARCHAR(max)");
        builder.Property(t => t.Favorite)
            .HasColumnType("TINYINT")
            .IsRequired(true)
            .HasMaxLength(1)
            .HasDefaultValue(0);
        builder.HasOne(p => p.Tag)
            .WithMany()
            .HasForeignKey(p => p.TagId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}