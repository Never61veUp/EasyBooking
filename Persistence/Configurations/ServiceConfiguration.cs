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
        
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Price).HasMaxLength(20).IsRequired();
        builder.Property(x => x.Duration).HasMaxLength(50).IsRequired();
        builder.HasOne<SpecialistEntity>(x => x.SpecialistEntity).WithMany(x => x.Services);
    }
}