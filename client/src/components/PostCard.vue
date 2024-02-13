<template>
    <div class="post-card">
        <div class="col-12">

            <img class="img-fluid" :src="postProp.img" alt="post image">


        </div>
        <div class="col-12 mb-5">
            <p class="fs-2 p-4 post-name  text-dark">{{ postProp.title }}</p>
            <p class="mb-4 p-4">{{ postProp.shortBody }}...</p>
        </div>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Post } from '../models/Post.js';
export default {
    props: { postProp: { type: Post, required: true } },
    setup() {
        return {
            posts: computed(() => AppState.posts),
            description: computed(() => AppState.posts.shortDescription)
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
</style>