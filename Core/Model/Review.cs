using CSharpFunctionalExtensions;

namespace Core.Model;

public class Review : Entity<Guid>
{
    public User User { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public Specialist Specialist { get; set; }
    
}