using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Core.Model;

public sealed class Specialist : Entity<Guid>
{
    private readonly List<Service> _services;
    private readonly List<Review> _reviews;
    
    private Specialist(Guid id, FullName fullName, EmailAddress emailAddress, PhoneNumber phoneNumber, List<Service> services, List<Review> reviews) : base(id)
    {
        FullName = fullName;
        EmailAddress = emailAddress;
        PhoneNumber = phoneNumber;
        _services = services;
        _reviews = reviews;
    }
    
    public FullName FullName { get; init; }
    public EmailAddress EmailAddress { get;}
    public PhoneNumber PhoneNumber { get;}
    public IReadOnlyCollection<Service> Services => _services.AsReadOnly();
    public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();
    

    public static Result<Specialist> Create(Guid id, FullName fullName, EmailAddress emailAddress, PhoneNumber phoneNumber, List<Service> services, List<Review> reviews)
    {
        return Result.Success(new Specialist(id, fullName, emailAddress, phoneNumber, services, reviews));
    }
    public Result AddService(Service service)
    {
        if (_services.Any(s => s.Id == service.Id))
            return Result.Failure("Service already exists");

        _services.Add(service);
        return Result.Success();
    }
}