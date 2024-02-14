namespace theJourney.Models;
public class Favorite : Post
{
    public int FavoriteId { get; set; }
    public string AccountId { get; set; }
    public int PostId { get; set; }
}