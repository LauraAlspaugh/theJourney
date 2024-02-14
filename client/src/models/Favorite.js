export class Favorite{
    constructor(data){
        this.id = data.id || __id
        this.accountId = data.accountId
        this.postId = data.postId
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.post = data.post
        this.isFavorite = data.isFavorite
        this.favoriteId = data.favoriteId
    }
}