using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Model;

namespace Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>

{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.ToTable("Review");
        
        builder.ComplexProperty(s => s.Rating, b =>
        {
            b.IsRequired();
            b.Property(x => x.Value).HasColumnName("Rating");
        });
        
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Customer);
        builder.Property(x => x.Text).HasMaxLength(255);
        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("NOW()")
            .IsRequired();;
    }
}