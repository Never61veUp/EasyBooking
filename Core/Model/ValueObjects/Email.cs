using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Core.Model.ValueObjects;

public class Email : ValueObject
{
    private const string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    
    private Email(string email)
    {
        EmailAddress = email;
    }
    
    public string EmailAddress { get; }
    
    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure<Email>("Email address cannot be empty");

        if (!Regex.IsMatch(email, emailRegex))
            return Result.Failure<Email>("Invalid email address format");

        return new Email(email);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return EmailAddress;
    }
}