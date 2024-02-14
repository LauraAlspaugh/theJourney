import { AppState } from "../AppState.js";
import { Favorite } from "../models/Favorite.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class FavoritesService{

    async favoritePost(postId) {
        logger.log(`creating a favorite with ${postId}`)
        const res = await api.post('api/favorites', { postId });
        logger.log('this is what we are getting back from the favorite post', res.data)
        AppState.favorites.push(new Favorite(res.data));
        AppState.myFavoritePosts.push(new Favorite(res.data))
    }
    async unfavoritePost(favoriteId) {
        logger.log('trying to unfavorite this.')
        const res = await api.delete(`api/favorites/${favoriteId}`);
        AppState.myFavoritePosts = AppState.myFavoritePosts.filter(post => post.favoriteId != favoriteId);

        return res.data


    }
}
export const favoritesService = new FavoritesService()