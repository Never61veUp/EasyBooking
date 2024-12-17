using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Model;

namespace Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        
        builder.ComplexProperty(e => e.PhoneNumber, c =>
        {
            // c.IsRequired();
            c.Property(e => e.Number).HasColumnName("PhoneNumber");
        });
        builder.ComplexProperty(e => e.Email, c =>
        {
            // c.IsRequired();
            c.Property(e => e.Email).HasColumnName("PhoneNumber");
        });
        
        builder.ComplexProperty(s => s.FullName, b =>
        {
            // b.IsRequired();
            b.Property(x => x.FirstName).HasColumnName("FirstName");
            b.Property(x => x.LastName).HasColumnName("LastName");
            b.Property(x => x.MiddleName).HasColumnName("MiddleName");
        });
        
        builder.HasMany<AppointmentEntity>(x => x.Appointments).WithOne(x => x.Client);
    }
}