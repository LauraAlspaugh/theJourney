
namespace theJourney.Services;
public class PostsService
{
    private readonly PostsRepository _postsRepository;

    public PostsService(PostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }

    internal Post CreatePost(Post postData)
    {
        Post post = _postsRepository.CreatePost(postData);
        return post;
    }
}