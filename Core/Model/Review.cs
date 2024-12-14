namespace Core.Model;

public class Review
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public Specialist Specialist { get; set; }
}