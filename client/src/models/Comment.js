export class Comment{
    constructor(data){
        this.id = data.id
        this.body = data.body
        this.postId = data.postId
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt).toLocaleTimeString()
        this.updatedAt = new Date(data.updatedAt).toLocaleDateString()
    }
}