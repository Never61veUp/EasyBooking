using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Model;

namespace Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>

{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.ToTable("Review");
        
        builder.HasKey(x => x.Id);

        builder.HasOne<UserEntity>(x => x.User);
        builder.Property(x => x.Content).HasMaxLength(255);
        builder.Property(x => x.Date);
    }
}