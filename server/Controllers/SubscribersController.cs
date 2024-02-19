namespace theJourney.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SubscribersController : ControllerBase
{
    private readonly SubscribersService _subscribersService;
    private readonly Auth0Provider _auth0Provider;

    public SubscribersController(SubscribersService subscribersService, Auth0Provider auth0Provider)
    {
        _subscribersService = subscribersService;
        _auth0Provider = auth0Provider;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Subscriber>> CreateSubscriber([FromBody] Subscriber subscriberData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            subscriberData.CreatorId = userInfo.Id;
            Subscriber subscriber = _subscribersService.CreateSubscriber(subscriberData);
            return Ok(subscriber);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}