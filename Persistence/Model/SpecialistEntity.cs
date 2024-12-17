using Core.Model;
using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class SpecialistEntity : Entity<Guid>
{
    public FullName FullName { get; set; }
    public List<SpecialtyEntity> Specialties { get; set; }
    public string Bio { get; set; }
    public List<ServiceEntity> Services { get; set; }
    public List<ReviewEntity> Reviews { get; set; }
    public EmailAddress Email { get; set; }
    public PhoneNumber Number { get; set; }
}