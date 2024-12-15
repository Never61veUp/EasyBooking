using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Persistence.Configurations;
using Persistence.Model;

namespace Persistence;

public class EasyBookingDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public EasyBookingDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<AppointmentEntity> Tasks { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
    public DbSet<ServiceConfiguration> Services { get; set; }
    public DbSet<SpecialistEntity> Specialists { get; set; }
    public DbSet<SpecialtyEntity> Specialties { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
            .UseLoggerFactory(CreateLoggerFactory())
            .EnableSensitiveDataLogging();
    }

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