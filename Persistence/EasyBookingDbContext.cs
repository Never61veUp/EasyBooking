using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Persistence.Configurations;
using Persistence.Model;

namespace Persistence;

public class EasyBookingDbContext : DbContext
{
    public EasyBookingDbContext(DbContextOptions<EasyBookingDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<AppointmentEntity> Tasks { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<SpecialistEntity> Specialists { get; set; }
    public DbSet<SpecialtyEntity> Specialties { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SpecialistConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceConfiguration());
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
    
    private ILoggerFactory CreateLoggerFactory() => LoggerFactory.Create(builder => {
        builder.AddConsole();
        builder.AddDebug();
    });
}