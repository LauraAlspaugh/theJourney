import { AppState } from "../AppState.js"
import { Post } from "../models/Post.js"
import { Subscriber } from "../models/Subscriber.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class PostsService{

async getPosts(){
    const res = await api.get('api/posts')
    logger.log('getting posts', res.data)
    AppState.posts =  res.data.map(pojo => new Post(pojo))
}
async getPostById(postId){
    AppState.activePost = null
    const res = await api.get(`api/posts/${postId}`)
    logger.log('getting post by id', res.data)
AppState.activePost = new Post(res.data)
}
async createSubscriber(subscriberData){
    const res = await api.post('api/subscribers', subscriberData)
    logger.log('creating a subscriber!', res.data)
    AppState.subscribers.push(new Subscriber(res.data))
}
}
export const postsService = new PostsService()