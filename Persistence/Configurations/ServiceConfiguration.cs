using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Model;

namespace Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.ToTable("Services");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Price).HasMaxLength(10).IsRequired();
        builder.Property(x => x.Duration).HasMaxLength(50).IsRequired();
    }
}