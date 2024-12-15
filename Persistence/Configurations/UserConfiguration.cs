using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Model;

namespace Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ComplexProperty(e => e.ContactInfo, contactInfo =>
        {
            contactInfo.Property(c => c.Phone).HasColumnName("Phone").HasMaxLength(15).IsRequired();
            contactInfo.Property(c => c.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
        });
        
        builder.ComplexProperty(s => s.FullName, b =>
        {
            b.IsRequired();
            b.Property(x => x.FirstName).HasColumnName("FirstName");
            b.Property(x => x.LastName).HasColumnName("LastName");
            b.Property(x => x.MiddleName).HasColumnName("MiddleName");
        });
        
        builder.HasMany<AppointmentEntity>(x => x.Appointments).WithOne(x => x.Client);
    }
}