using Core.Model.ValueObjects;
using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class ReviewEntity : Entity<Guid>
{
    public CustomerEntity Customer { get; set; }
    public string Text { get; set; }
    public Rating Rating { get; set; }
    public DateTime CreatedAt { get; set; }
}