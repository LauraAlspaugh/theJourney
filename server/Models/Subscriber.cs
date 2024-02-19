namespace theJourney.Models;
public class Subscriber
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Email { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}