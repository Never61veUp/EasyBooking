using System.Collections;
using Core.Model;
using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class SpecialistEntity : Entity<Guid>
{
    public FullName FullName { get; set; }
    public EmailAddress Email { get; set; }
    public PhoneNumber Number { get; set; }
    public List<ServiceEntity> Services { get; set; }
    public List<ReviewEntity> Reviews { get; set; }
}