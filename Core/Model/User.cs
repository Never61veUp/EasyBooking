using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Core.Model;

public sealed class User : Entity<Guid>
{
    private readonly List<Appointment> _appointments;

    private User(Guid id, FullName fullName, ContactInfo contactInfo, List<Appointment> appointments)
    {
        Id = id;
        FullName = fullName;
        ContactInfo = contactInfo;
        _appointments = appointments;
    }
    
    public FullName FullName { get; }
    public ContactInfo ContactInfo { get; }
    public IReadOnlyList<Appointment> Appointments => _appointments;
    
    public static Result<User> Create(Guid id, FullName fullName, ContactInfo contactInfo, List<Appointment> appointments)
    {
        if (id == Guid.Empty)
            return Result.Failure<User>("ID cannot be empty.");
        
        return new User(id, fullName, contactInfo, appointments);
    }
}