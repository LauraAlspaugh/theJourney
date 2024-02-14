<template>
    <div class="container">
        <section class="row mt-5">
            <div class="col-5 the-journey">
                <p class="the-journey">The Journey.</p>
            </div>
            <div class="col-5  m-5 d-flex justify-content-evenly nav-bar">
                <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
                    <p>Home</p>
                </router-link>
                <router-link class="navbar-brand d-flex" :to="{ name: 'Contact' }">
                    <p>Contact</p>
                </router-link>
                <router-link class="navbar-brand d-flex" :to="{ name: 'The Blog' }">
                    <p>The Blog</p>
                </router-link>
                <router-link class="navbar-brand d-flex" :to="{ name: 'About' }">
                    <p>About</p>
                </router-link>
            </div>
        </section>
        <section class="row mb-5 justify-content-center">
            <div class="col-12 text-center mt-3">
                <p class="fs-1">The Feed</p>
            </div>
            <div v-for="post in posts" :key="post.id" class="col-4 mt-5">
                <post-card :postProp="post" />
            </div>
        </section>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import PostCard from '../components/PostCard.vue';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { postsService } from '../services/PostsService.js';
export default {
    setup() {
        onMounted(() => {
            getPosts()
        })
        async function getPosts() {
            try {
                await postsService.getPosts()
            } catch (error) {
                logger.error(error)
                Pop.error(error)
            }
        }
        return {
            posts: computed(() => AppState.posts)
        };
    },
    components: { PostCard }
};
</script>


<style lang="scss" scoped>
.the-journey {
    font-size: 50px;
    font-family: cursive;
    padding-left: 80px;
}

.nav-bar {
    font-family: Courier New;
    font-size: 18px;
}

.active,
.navbar-brand:hover {
    border-top: black 1px solid;
    border-bottom: 1px solid black;
}

.masonry {
    columns: 400px;
    column-gap: 1rem;
}
</style>