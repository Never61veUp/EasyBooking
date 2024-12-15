using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Model;

namespace Persistence.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentEntity>
{
    public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
    {
        builder.ToTable("Appointment");
        builder.HasKey(x => x.Id);

        builder.HasOne<ServiceEntity>(x => x.Service);
        builder.HasOne<SpecialistEntity>(x => x.Specialist);
        builder.HasOne<UserEntity>(x => x.Client);
        builder.Property(x => x.AppointmentDate);
        
        builder.Property(x => x.Status).IsRequired().HasDefaultValue("pending");
    }
}