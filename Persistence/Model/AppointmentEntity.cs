using Core.Model;
using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class AppointmentEntity : Entity<Guid>
{
    public SpecialistEntity Specialist { get; set; }
    public CustomerEntity Customer { get; set; }
    public ServiceEntity Service { get; set; }
    public DateRange DateRange { get; set; }
    public Status Status { get; set; }
}