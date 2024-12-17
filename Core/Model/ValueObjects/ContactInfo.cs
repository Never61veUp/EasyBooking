using CSharpFunctionalExtensions;

namespace Core.Model.ValueObjects;

public class ContactInfo : ValueObject
{
    private ContactInfo(PhoneNumber phone, EmailAddress emailAddress)
    {
        Phone = phone;
        EmailAddress = emailAddress;
    }
    
    public PhoneNumber Phone { get; }
    public EmailAddress EmailAddress { get; }

    public static Result<ContactInfo> Create(PhoneNumber phone, EmailAddress emailAddress)
    {
        return new ContactInfo(phone, emailAddress);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Phone;
        yield return EmailAddress;
    }
}