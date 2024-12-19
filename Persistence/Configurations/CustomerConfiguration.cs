using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Model;

namespace Persistence.Configurations;

public class CustomerConfiguration: IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("Customers");
        
        builder.HasKey(x => x.Id);
        
        builder.ComplexProperty(s => s.FullName, b =>
        {
            b.IsRequired();
            b.Property(x => x.FirstName).HasColumnName("FirstName");
            b.Property(x => x.LastName).HasColumnName("LastName");
            b.Property(x => x.MiddleName).HasColumnName("MiddleName");
        });
        
        builder.ComplexProperty(e => e.PhoneNumber, b =>
        {
            b.IsRequired();
            b.Property(x => x.Number).HasColumnName("PhoneNumber").IsRequired();
        });
        
        builder.ComplexProperty(e => e.Email, b =>
        {
            b.IsRequired();
            b.Property(x => x.Email).HasColumnName("Email").IsRequired();
        });
    }
}