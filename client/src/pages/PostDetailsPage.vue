<template>
    <div class="container-fluid">
        <section v-if="post" class="row justify-content-center mt-5">
            <div class="col-5 mb-5">
                <p class="fs-1 post-title">{{ post.title }}.</p>
                <p class="post-body">{{ post.body }}</p>
                <img class="img-fluid" :src="post.img" alt="post image">
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
            post: computed(() => AppState.activePost)
        }
    }
};
</script>


<style lang="scss" scoped>
.post-title {
    font-family: cursive;
}

img {
    height: 600px;
    position: center;
    object-fit: cover;
    border: 1px solid lightgray;
}

.post-body {
    font-family: 'Times New Roman', Times, serif;
    font-size: 17px;
}
</style>