using Core.Model;
using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class UserEntity : Entity<Guid>
{
    public FullName FullName { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public List<AppointmentEntity> Appointments { get; set; }
}