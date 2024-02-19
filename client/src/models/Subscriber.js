export class Subscriber{
    constructor(data){
        this.id = data.id
        this.email = data.email
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.createdAt = new Date(data.createdAt).toLocaleTimeString()
        this.updatedAt = new Date(data.updatedAt).toLocaleTimeString()
    }
}