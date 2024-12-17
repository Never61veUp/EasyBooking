using Persistence.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SpecialistConfiguration : IEntityTypeConfiguration<SpecialistEntity>
{
    public void Configure(EntityTypeBuilder<SpecialistEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Bio).HasMaxLength(255);

        builder.ComplexProperty(s => s.FullName, b =>
        {
            b.IsRequired();
            b.Property(x => x.FirstName).HasColumnName("FirstName");
            b.Property(x => x.LastName).HasColumnName("LastName");
            b.Property(x => x.MiddleName).HasColumnName("MiddleName");
        });
        
        builder.ComplexProperty(e => e.Number, b =>
        {
            b.IsRequired();
            b.Property(x => x.Number).HasColumnName("PhoneNumber").IsRequired();
        });
        
        builder.ComplexProperty(e => e.Email, b =>
        {
            b.IsRequired();
            b.Property(x => x.Email).HasColumnName("Email").IsRequired();
        });
        
        builder.HasMany(s => s.Services).WithOne(c => c.SpecialistEntity);
        builder.HasMany(s => s.Reviews).WithOne(c => c.Specialist);
        builder.HasMany(s => s.Specialties);

    }
}