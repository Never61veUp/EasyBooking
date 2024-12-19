using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Core.Model;

public class Review : Entity<Guid>
{
    private Review(Guid id, Guid customerId, string text, Rating rating, DateTime createdAt) : base(id)
    {
        CustomerId = customerId;
        Text = text;
        Rating = rating;
        CreatedAt = createdAt;
    }
    
    public Guid CustomerId { get; }
    public string Text { get; }
    public Rating Rating { get; }
    public DateTime CreatedAt { get; }

    public static Result<Review> Create(Guid id, Guid customerId, string text, Rating rating, DateTime createdAt)
    {
        if (string.IsNullOrWhiteSpace(text))
            return Result.Failure<Review>("Review text cannot be empty");
        
        return Result.Success(new Review(id, customerId, text, rating, createdAt));
    }
}