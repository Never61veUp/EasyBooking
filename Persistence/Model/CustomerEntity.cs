using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class CustomerEntity : Entity<Guid>
{
    public FullName FullName { get; set; }
    public EmailAddress Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
}