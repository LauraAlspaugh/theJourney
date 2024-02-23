namespace theJourney.Services;
public class MailService
{
    private readonly MailRepository _mailRepository;

    public MailService(MailRepository mailRepository)
    {
        _mailRepository = mailRepository;
    }
}