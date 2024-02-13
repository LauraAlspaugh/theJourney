




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

    internal void DestroyPost(int postId, string userId)
    {
        string sql = @"
DELETE FROM posts WHERE id = @postId LIMIT 1;
SELECT pos.*,
    acc.*
    FROM posts pos
    JOIN accounts acc ON pos.creatorId = acc.id
    Where pos.id = @postId;
";
        _db.Execute(sql, new { postId });
    }

    internal Post EditPost(Post post)
    {
        string sql = @"
        UPDATE posts
        SET 
        title = @Title,
        img = @Img,
        body = @Body
        WHERE id = @Id;

        SELECT 
        pos.*,
        acc.*
        FROM posts pos
        JOIN accounts acc ON pos.creatorId = acc.id
        WHERE pos.id = @Id;
        ";

        Post newPost = _db.Query<Post, Account, Post>(sql, (post, account) =>
         {
             post.Creator = account;
             return post;
         }, post).FirstOrDefault();
        return newPost;
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