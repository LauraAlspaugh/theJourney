
namespace theJourney.Services;
public class SubscribersService
{
    private readonly SubscribersRepository _subscribersRepository;

    public SubscribersService(SubscribersRepository subscribersRepository)
    {
        _subscribersRepository = subscribersRepository;
    }

    internal Subscriber CreateSubscriber(Subscriber subscriberData)
    {
        Subscriber subscriber = _subscribersRepository.CreateSubscriber(subscriberData);
        return subscriber;
    }
}