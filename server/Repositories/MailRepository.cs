using System.Net.NetworkInformation;

namespace theJourney.Repositories;
public class MailRepository
{
    private readonly IDbConnection _db;

    public MailRepository(IDbConnection db)
    {
        _db = db;
    }
}