using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace Core.Model.ValueObjects;

public class PhoneNumber : ValueObject
{
    private const string phoneRegex = @"^\+?[1-9]\d{1,14}$";
    
    private PhoneNumber(string number)
    {
        Number = number;
    }
    
    public string Number { get; }
    
    public static Result<PhoneNumber> Create(string number)
    {
        if(String.IsNullOrWhiteSpace(number))
            return Result.Failure<PhoneNumber>("Phone number cannot be empty");
        if(!Regex.IsMatch(number, phoneRegex))
            return Result.Failure<PhoneNumber>("Invalid phone number");
        
        return new PhoneNumber(number);

    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
}