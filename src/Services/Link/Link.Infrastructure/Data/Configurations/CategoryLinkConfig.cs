using Link.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Link.Infrastructure.Data.Configurations;

public class CategoryLinkConfig : IEntityTypeConfiguration<CategoryLink>
{
    public void Configure(EntityTypeBuilder<CategoryLink> builder)
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