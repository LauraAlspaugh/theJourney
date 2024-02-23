namespace theJourney.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MailController : ControllerBase
{
    private readonly MailService _mailService;
    private readonly Auth0Provider _auth0Provider;

    public MailController(MailService mailService, Auth0Provider auth0Provider)
    {
        _mailService = mailService;
        _auth0Provider = auth0Provider;
    }
}