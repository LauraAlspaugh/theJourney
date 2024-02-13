


namespace theJourney.Repositories;
public class PostsRepository
{
    private readonly IDbConnection _db;

    public PostsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Post CreatePost(Post postData)
    {
        string sql = @"
    INSERT INTO 
    posts(title, img, body, creatorId)
    VALUES(@Title, @Img, @Body, @CreatorId);
    SELECT 
    pos.*,
    acc.*
    FROM posts pos
    JOIN accounts acc ON pos.creatorId = acc.id
    WHERE pos.id = LAST_INSERT_ID();
";
        Post post = _db.Query<Post, Account, Post>(sql, (post, account) =>
         {
             post.Creator = account;
             return post;
         }, postData).FirstOrDefault();
        return post;
    }

    internal Post GetPostById(int postId)
    {
        string sql = @"
       SELECT 
       pos.*,
       acc.*
       FROM posts pos
       JOIN accounts acc ON pos.creatorId = acc.id
       WHERE pos.id = @postId;
       ";
        Post post = _db.Query<Post, Account, Post>(sql, (post, account) =>
        {
            post.Creator = account;
            return post;
        }, new { postId }).FirstOrDefault();
        return post;
    }

    internal List<Post> GetPosts()
    {
        string sql = @"
    SELECT 
    pos.*,
    acc.*
    FROM posts pos
    JOIN accounts acc ON pos.creatorId = acc.id
    ";
        List<Post> posts = _db.Query<Post, Account, Post>(sql, (post, account) =>
        {
            post.Creator = account;
            return post;
        }).ToList();
        return posts;
    }
}