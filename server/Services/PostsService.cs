


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

    internal Post GetPostById(int postId)
    {
        Post post = _postsRepository.GetPostById(postId);
        if (post == null)
        {
            throw new Exception("not a valid post Id!");

        }
        return post;
    }

    internal List<Post> GetPosts()
    {
        List<Post> posts = _postsRepository.GetPosts();
        return posts;
    }
}