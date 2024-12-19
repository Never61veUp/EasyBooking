using CSharpFunctionalExtensions;

namespace Core.Model.ValueObjects;

public class Rating : ValueObject
{
    private Rating(int value)
    {
        Value = value;
    }
    
    public int Value { get; }

    public static Result<Rating> Create(int value)
    {
        if (value < 1 || value > 5)
            return Result.Failure<Rating>("Rating must be between 1 and 5");
        return Result.Success(new Rating(value));
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}