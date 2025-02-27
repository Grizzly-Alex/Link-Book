﻿using Link.Core.Entities.Link;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Link.Infrastructure.Data.Configurations;

public class AliasLinkConfig : IEntityTypeConfiguration<AliasLink>
{
    public void Configure(EntityTypeBuilder<AliasLink> builder)
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
        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);
    }
}