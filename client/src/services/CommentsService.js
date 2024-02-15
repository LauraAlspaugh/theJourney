import { AppState } from "../AppState.js"
import { Comment } from "../models/Comment.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class CommentsService{
async createComment(commentData){
    const res = await api.post('api/comments', commentData)
    logger.log('creating a comment', res.data)
    AppState.comments.push(new Comment(res.data))
}

async getCommentsByPostId(postId){
    const res = await api.get(`api/posts/${postId}/comments`)
   logger.log('getting comments', res.data)
   AppState.comments = res.data.map(pojo => new Comment(pojo))
}
}

export const commentsService = new CommentsService()