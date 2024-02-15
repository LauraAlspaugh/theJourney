<template>
    <div class="container-fluid">
        <section v-if="post" class="row justify-content-center p-4 mt-5">
            <div class="col-12 col-md-5 mb-5 post-section">
                <p class="fs-1 post-title">{{ post.title }}.</p>
                <p class="post-body">{{ post.body }}</p>
                <img class="img-fluid " :src="post.img" alt="post image">
                <span v-if="isFavPost" @click.stop="unfavoritePost(isFavPost.favoriteId)" role="button"><i
                        class="fs-2 mdi mdi-heart text-center" title="unfavorite this post"></i></span>
                <span v-else @click.stop="favoritePost(post.id)" role="button"><i
                        class="fs-2 mdi mdi-heart-outline text-center" title="favorite this post"></i></span>
            </div>
            <div class="col-12 col-md-3 gray-box mt-5 ms-4 text-center">
                <img class="img-fluid personal-image mt-5" src="../assets/img/pictureday.png" alt="">
                <p class="hi-text fs-3 mt-2 p-5">Hi, thanks for stopping by!</p>
                <router-link class="" :to="{ name: 'About' }">
                    <button class="btn btn-outline-dark text-white read-button">Read More</button>
                </router-link>
            </div>
        </section>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { useRoute } from 'vue-router';
import { postsService } from '../services/PostsService.js';
import { favoritesService } from '../services/FavoritesService.js';
export default {
    setup() {
        const route = useRoute()
        onMounted(() => {
            getPostById()
        })
        async function getPostById() {
            try {
                const postId = route.params.postId
                await postsService.getPostById(postId)
            } catch (error) {
                logger.error(error)
                Pop.error(error)

            }
        }
        return {
            post: computed(() => AppState.activePost),
            isFavPost: computed(() => AppState.myFavoritePosts.find((post) => post.id == post.id || post.postId == post.id)),
            async favoritePost() {
                try {
                    const postId = route.params.postId;
                    logger.log('favorite post with post id', postId)
                    await favoritesService.favoritePost(postId);
                }
                catch (error) { Pop.error(error) }
            },
            async unfavoritePost(favoriteId) {
                try {

                    const postId = route.params.postId;
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
.post-title {
    font-family: cursive;
}

img {
    height: 500px;
    width: 100%;
    position: center;
    object-fit: cover;
    border: 1px solid lightgray;
}

.post-body {
    font-family: 'Times New Roman', Times, serif;
    font-size: 17px;
}

.gray-box {
    background-color: gray;
    height: 800px;
    box-shadow: 3px 7px 8px gray;
    margin-left: 5px;
}

.personal-image {
    width: 70%;
    height: 400px;
    border: 1px solid gray;
}

.hi-text {
    font-family: 'Times New Roman', Times, serif;
}

.read-button {
    background-color: black;
    font-family: 'Times New Roman', Times, serif;
    border-radius: 0px;
}

.post-section {
    border-bottom: 2px solid lightgray;
}
</style>