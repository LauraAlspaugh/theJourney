export class Post{
    constructor(data){
        this.id = data.id
        this.title = data.title
        this.body = data.body
        this.shortBody = data.body.slice(0, 200)
        this.img = data.img
        this.secondImage = data.secondImage || data.img
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt).toLocaleDateString('en-us', {  year:"numeric", month:"long", day:"numeric"}) 
        this.updatedAt = new Date(data.updatedAt).toLocaleDateString()
        this.favorites = data.favorites
        this.isFavorite = data.isFavorite
    }
}
