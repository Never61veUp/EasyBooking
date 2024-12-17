using Core.Model;
using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class UserEntity : Entity<Guid>
{
    public FullName FullName { get; set; }
    public EmailAddress Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public List<AppointmentEntity> Appointments { get; set; }
}