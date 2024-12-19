using CSharpFunctionalExtensions;

namespace Core.Model;

public sealed class Service : Entity<Guid>
{
    private Service(Guid id, string title, decimal price, TimeSpan duration) : base(id)
    {
        Title = title;
        Price = price;
        Duration = duration;
    }
    
    public string Title { get; }
    public decimal Price { get; }
    public TimeSpan Duration { get; }

    public static Result<Service> Create(Guid id, string title, decimal price, TimeSpan duration)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<Service>("Service title cannot be empty");
        if (price <= 0)
            return Result.Failure<Service>("Price must be greater than zero");
        if (duration <= TimeSpan.Zero)
            return Result.Failure<Service>("Duration must be greater than zero");

        return Result.Success(new Service(id, title, price, duration));
    }
}