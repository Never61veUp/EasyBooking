using CSharpFunctionalExtensions;

namespace Persistence.Model;

public class ReviewEntity : Entity<Guid>
{
    public UserEntity User { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public SpecialistEntity Specialist { get; set; }
}