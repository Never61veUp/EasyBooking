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

        builder.ComplexProperty(s => s.DateRange, b =>
        {
            b.IsRequired();
            b.Property(x => x.Start).HasColumnName("Start");
            b.Property(x => x.End).HasColumnName("End");
        });
        
        builder.HasOne<SpecialistEntity>(x => x.Specialist);
        builder.HasOne<CustomerEntity>(x => x.Customer);
        builder.HasOne<ServiceEntity>(x => x.Service);
        
        builder.Property(e => e.Status)
            .IsRequired();
    }
}