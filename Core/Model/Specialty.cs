using CSharpFunctionalExtensions;

namespace Core.Model;

public class Specialty : Entity<Guid>
{
    public static readonly Specialty Hairdresser = new (nameof(Hairdresser));
    public static readonly Specialty Cosmetologist = new (nameof(Cosmetologist));
    public static readonly Specialty ManicuristPedicurist = new (nameof(ManicuristPedicurist));

    private static readonly Specialty[] _all = [Hairdresser, Cosmetologist, ManicuristPedicurist];

    public string Value { get; }
    private Specialty(string value)
    {
        Value = value;
    }

    public static Result<Specialty> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            return Result.Failure<Specialty>($"{nameof(value)} cannot be null or empty.");
        
        var specialty = value.Trim().ToLower();
        
        if(_all.Any(s => s.Value.ToLower() == specialty) == false)
            return Result.Failure<Specialty>($"{nameof(value)} is not a valid specialty.");

        return new Specialty(value);
    }
}