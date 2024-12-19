using Core.Model;
using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class ServiceEntity : Entity<Guid>
{
    public string Title { get; }
    public decimal Price { get; }
    public TimeSpan Duration { get; }
}