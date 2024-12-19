using CSharpFunctionalExtensions;

namespace Core.Model.ValueObjects;

public class DateRange : ValueObject
{
    private DateRange(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }
    
    public DateTime Start { get; }
    public DateTime End { get; }

    public static Result<DateRange> Create(DateTime start, DateTime end)
    {
        if (start >= end)
            return Result.Failure<DateRange>("Start date must be earlier than end date");

        return Result.Success(new DateRange(start, end));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}