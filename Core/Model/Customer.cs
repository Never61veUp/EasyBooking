using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Core.Model;

public class Customer : Entity<Guid>
{
    private Customer(Guid id, FullName name, EmailAddress email, PhoneNumber phoneNumber) : base(id)
    {
        FullName = name;
        EmailAddress = email;
        PhoneNumber = phoneNumber;
    }
    
    public FullName FullName { get; }
    public EmailAddress EmailAddress { get; }
    public PhoneNumber PhoneNumber { get; }

    public static Result<Customer> Create(Guid id, FullName name, EmailAddress email, PhoneNumber phoneNumber)
    { 
        return Result.Success(new Customer(id, name, email, phoneNumber));
    }
}