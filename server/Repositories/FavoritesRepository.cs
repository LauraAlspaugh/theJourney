

namespace theJourney.Repositories;
public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
    INSERT INTO 
    favorites(postId, accountId)
    VALUES(@PostId, @AccountId);

    SELECT
    fav.*,
    pos.*,
    acc.*
    FROM favorites fav
    JOIN posts pos ON fav.postId = pos.id
    JOIN accounts acc ON acc.id = pos.creatorId
    WHERE fav.id = LAST_INSERT_ID();
    ";
        Favorite postsFavorites = _db.Query<Favorite, Favorite, Account, Favorite>(sql, (favorite, postFavorite, account) =>
        {
            postFavorite.FavoriteId = favorite.Id;
            postFavorite.AccountId = favorite.AccountId;
            postFavorite.Creator = account;

            return postFavorite;

        }, favoriteData).FirstOrDefault();
        return postsFavorites;
    }

    internal void DestroyFavorite(int favoriteId)
    {
        string sql = "DELETE FROM favorites WHERE id = @favoriteId LIMIT 1;";
        _db.Execute(sql, new { favoriteId });
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        string sql = "SELECT * FROM favorites WHERE id = @favoriteId;";
        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }

    internal List<Favorite> GetFavoritesByAccountId(string userId)
    {
        string sql = @"
    SELECT 
    fav.*,
    pos.*,
    acc.*
    FROM favorites fav
    JOIN posts pos ON fav.postId = pos.id
    JOIN accounts acc ON acc.id = pos.creatorId
    WHERE fav.accountId = @userId;
    ";
        List<Favorite> postFavorites = _db.Query<Favorite, Favorite, Account, Favorite>(sql, (favorite, photoFavorite, account) =>
        {
            photoFavorite.FavoriteId = favorite.Id;
            photoFavorite.AccountId = favorite.AccountId;
            photoFavorite.Creator = account;

            return photoFavorite;

        }, new { userId }).ToList();
        return postFavorites;
    }
}