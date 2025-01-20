using Link.Core.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Link.Infrastructure.Data.Configurations;

public class AliasCategoryConfig : IEntityTypeConfiguration<AliasCategory>
{
    public void Configure(EntityTypeBuilder<AliasCategory> builder)
    {
        builder.ToTable("Categories").HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnType("UNIQUEIDENTIFIER");
        builder.Property(t => t.UserId)
            .IsRequired(true)
            .HasColumnType("NVARCHAR(max)");
        builder.Property(t => t.Name)
            .IsRequired(true)
            .HasColumnType("NVARCHAR(50)");
    }
}