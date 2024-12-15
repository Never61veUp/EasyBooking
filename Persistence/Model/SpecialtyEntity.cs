using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class SpecialtyEntity : Entity<Guid>
{
    public string SpecialtyName { get; set; }
}