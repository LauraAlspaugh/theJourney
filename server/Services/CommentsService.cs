


namespace theJourney.Services;
public class CommentsService
{
    private readonly CommentsRepository _commentsRepository;

    public CommentsService(CommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }

    internal Comment CreateComment(Comment commentData)
    {
        Comment comment = _commentsRepository.CreateComment(commentData);
        return comment;
    }

    internal string DestroyComment(int commentId, string userId)
    {
        Comment comment = GetCommentById(commentId);
        if (comment.CreatorId != userId)
        {
            throw new Exception("not yours to destroy!");
        }
        _commentsRepository.DestroyComment(commentId, userId);
        return "it really is gone!";
    }

    internal Comment GetCommentById(int commentId)
    {
        Comment comment = _commentsRepository.GetCommentById(commentId);
        return comment;
    }

    internal List<Comment> GetCommentsByPostId(int postId)
    {
        List<Comment> comments = _commentsRepository.GetCommentsByPostId(postId);
        return comments;
    }
}