
namespace theJourney.Repositories;
public class SubscribersRepository
{
    private readonly IDbConnection _db;

    public SubscribersRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Subscriber CreateSubscriber(Subscriber subscriberData)
    {
        string sql = @"
    INSERT INTO 
    subscribers(email, creatorId)
    VALUES(@Email, @CreatorId);
    SELECT 
    sub.*,
    acc.*
    FROM subscribers sub
    JOIN accounts acc ON sub.creatorId = acc.id
    WHERE sub.id = LAST_INSERT_ID();
";
        Subscriber subscriber = _db.Query<Subscriber, Account, Subscriber>(sql, (subscriber, account) =>
          {
              subscriber.Creator = account;
              return subscriber;
          }, subscriberData).FirstOrDefault();
        return subscriber;
    }
}