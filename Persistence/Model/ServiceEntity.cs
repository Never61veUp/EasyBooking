using Core.Model;
using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class ServiceEntity : Entity<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }
    public SpecialistEntity SpecialistEntity { get; set; }
}