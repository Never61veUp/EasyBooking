using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Core.Model.ValueObjects;

public class EmailAddress : ValueObject
{
    private const string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    
    private EmailAddress(string email)
    {
        Email = email;
    }
    
    public string Email { get; }
    
    public static Result<EmailAddress> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure<EmailAddress>("Email address cannot be empty");

        if (!Regex.IsMatch(email, emailRegex))
            return Result.Failure<EmailAddress>("Invalid email address format");

        return new EmailAddress(email);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Email;
    }
}