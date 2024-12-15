using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class AppointmentEntity : Entity<Guid>
{
    public ServiceEntity Service { get; set; }
    public SpecialistEntity Specialist { get; set; }
    public UserEntity Client { get; }
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; }
}