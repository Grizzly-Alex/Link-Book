using Link.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Link.Infrastructure.Data.Configurations;

public class LinkTagConfig : IEntityTypeConfiguration<LinkTag>
{
    public void Configure(EntityTypeBuilder<LinkTag> builder)
    {
        throw new NotImplementedException();
    }
}
