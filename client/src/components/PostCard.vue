<template>
    <div class="post-card">
        <div class="col-12">
            <router-link :to="{ name: 'Post', params: { postId: postProp.id } }">
                <img class="img-fluid" :src="postProp.img" alt="post image">
            </router-link>

        </div>
        <div class="col-12 mb-5">
            <div class="d-flex mt-5 justify-content-between p-4">
                <p class="fs-2 post-name  text-dark">{{ postProp.title }}.</p>
                <span v-if="isFavPost" @click.stop="unfavoritePost(isFavPost.favoriteId)" role="button"><i
                        class="fs-2 mdi mdi-heart text-center" title="unfavorite this post"></i></span>
                <span v-else @click.stop="favoritePost(postProp.id)" role="button"><i class="fs-2 mdi mdi-heart-outline"
                        title="favorite this post"></i></span>
            </div>
            <p class="mb-4 p-4 post-body">{{ postProp.shortBody }}...</p>
        </div>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Post } from '../models/Post.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { favoritesService } from '../services/FavoritesService.js';
export default {
    props: { postProp: { type: Post, required: true } },
    setup(props) {
        return {
            myFavoritePosts: computed(() => AppState.myFavoritePosts),
            posts: computed(() => AppState.posts),
            description: computed(() => AppState.posts.shortDescription),
            isFavPost: computed(() => AppState.myFavoritePosts.find((post) => post.id == props.postProp.id || post.postId == props.postProp.id)),
            async favoritePost() {
                try {
                    const postId = props.postProp.id;
                    logger.log('favorite post with post id', postId)
                    await favoritesService.favoritePost(postId);
                }
                catch (error) { Pop.error(error) }
            },
            async unfavoritePost(favoriteId) {
                try {

                    const postId = props.postProp.id;
                    logger.log('we are trying to unfavorite this post', postId)
                    await favoritesService.unfavoritePost(favoriteId);
                }
                catch (error) { Pop.error(error) }
            },
        }
    }
};
</script>


<style lang="scss" scoped>
.post-card {
    background-color: white;
    border: 1px solid lightgray;
    // border-radius: 7px;
    box-shadow: 3px 2px 3px gray;
}

img {
    width: 100%;
    // border-radius: 7px 7px 0px 0px;
    height: 300px;
    object-fit: cover;
    position: center;
}

.post-name {

    font-family: cursive;
}

.post-body {
    font-family: 'Times New Roman', Times, serif;
    font-size: 17px;
}
</style>