



namespace theJourney.Repositories;
public class CommentsRepository
{
    private readonly IDbConnection _db;

    public CommentsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Comment CreateComment(Comment commentData)
    {
        string sql = @"
    INSERT INTO 
    comments(body, postId, creatorId)
    VALUES(@Body, @PostId, @CreatorId);
    SELECT 
    com.*,
    acc.*
    FROM comments com
    JOIN accounts acc ON com.creatorId = acc.id
    WHERE com.id = LAST_INSERT_ID();
";
        Comment comment = _db.Query<Comment, Account, Comment>(sql, (comment, account) =>
         {
             comment.Creator = account;
             return comment;
         }, commentData).FirstOrDefault();
        return comment;
    }

    internal void DestroyComment(int commentId, string userId)
    {
        string sql = @"
DELETE FROM comments WHERE id = @commentId LIMIT 1;
SELECT com.*,
    acc.*
    FROM comments com
    JOIN accounts acc ON com.creatorId = acc.id
    Where com.id = @commentId;
";
        _db.Execute(sql, new { commentId });
    }

    internal Comment GetCommentById(int commentId)
    {
        string sql = @"
       SELECT 
       com.*,
       acc.*
       FROM comments com
       JOIN accounts acc ON com.creatorId = acc.id
       WHERE com.id = @commentId;
       ";
        Comment comment = _db.Query<Comment, Account, Comment>(sql, (comment, account) =>
        {
            comment.Creator = account;
            return comment;
        }, new { commentId }).FirstOrDefault();
        return comment;
    }

    internal List<Comment> GetCommentsByPostId(int postId)
    {
        string sql = @"
    SELECT 
    com.*, 
    acc.*
    FROM comments com
    JOIN accounts acc ON acc.id = com.creatorId
    WHERE com.postId = @postId;
    ";
        List<Comment> comments = _db.Query<Comment, Account, Comment>(sql, (comment, account) =>
        {
            comment.Creator = account;
            return comment;
        }, new { postId }).ToList();
        return comments;
    }
}