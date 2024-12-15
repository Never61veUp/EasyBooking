using CSharpFunctionalExtensions;

namespace Core.Model;

public sealed class Service : Entity<Guid>
{
    private Service(Guid id, string name, decimal price, TimeSpan duration)
    {
        Id = id;
        Name = name;
        Price = price;
        Duration = duration;
    }
    
    public string Name { get; }
    public decimal Price { get; }
    public TimeSpan Duration { get; }

    public static Result<Service> Create(Guid id, string name, decimal price, TimeSpan duration)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Service>("Service name cannot be empty.");
        if (price <= 0)
            return Result.Failure<Service>("Price must be greater than zero.");
        if (duration.TotalMinutes <= 0)
            return Result.Failure<Service>("Duration must be greater than zero.");
        
        return new Service(id, name, price, duration);
    }
}