

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

    internal List<Comment> GetCommentsByPostId(int postId)
    {
        List<Comment> comments = _commentsRepository.GetCommentsByPostId(postId);
        return comments;
    }
}