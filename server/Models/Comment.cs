namespace theJourney.Models;
public class Comment
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Body { get; set; }
    public int PostId { get; set; }
    public Account Creator { get; set; }
    public string CreatorId { get; set; }
}