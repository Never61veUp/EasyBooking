using CSharpFunctionalExtensions;

namespace Core.Model.ValueObjects;

public class ContactInfo : ValueObject
{
    private ContactInfo(PhoneNumber phone, Email email)
    {
        Phone = phone;
        Email = email;
    }
    
    public PhoneNumber Phone { get; }
    public Email Email { get; }

    public static Result<ContactInfo> Create(PhoneNumber phone, Email email)
    {
        return new ContactInfo(phone, email);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Phone;
        yield return Email;
    }
}