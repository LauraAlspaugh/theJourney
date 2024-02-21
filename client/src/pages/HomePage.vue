<template>
  <div class="container-fluid">
    <section class="row mt-5">
      <div class="col-12 col-md-5 the-journey">
        <p class="the-journey">The Journey.</p>
      </div>
      <div class="col-12 col-md-5   nav-bar">
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
    <section class="row">
      <div class="col-12 p-0">
        <img class="img-fluid"
          src="https://static.wixstatic.com/media/nsplsh_616637633047774c734755~mv2_d_3648_5472_s_4_2.jpg/v1/fill/w_1960,h_3272,al_c,q_90,usm_0.66_1.00_0.01,enc_auto/nsplsh_616637633047774c734755~mv2_d_3648_5472_s_4_2.jpg"
          alt="">
      </div>
    </section>
    <section class="row">
      <div class="col-12 text-center mt-5">
        <p class="fs-1 blog-title ">My Life . My Blog</p>
        <p class="fs-4 post-inspo">Sharing inspiration one post at a time.</p>
      </div>
    </section>
    <section class="row flex-column align-items-center mt-5">
      <div v-for="post in posts" :key="post.id" class="col-12 col-md-5 mb-5">
        <post-card :postProp="post" />
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { postsService } from '../services/PostsService.js';
import PostCard from '../components/PostCard.vue';


export default {
  setup() {
    onMounted(() => {
      getPosts();
    });
    async function getPosts() {
      try {
        await postsService.getPosts();
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    return {
      posts: computed(() => AppState.posts)
    };
  },
  components: { PostCard, PostCard }
}
</script>

<style scoped lang="scss">
.the-journey {
  font-size: 50px;
  font-family: cursive;
  padding-left: 80px;

}

.nav-bar a {
  font-family: Courier New;
  font-size: 18px;
  display: flex;
  justify-content: space-evenly;

}

.nav-bar {
  display: flex;
  justify-content: space-evenly;
  margin: 5px;
}

img {
  object-fit: cover;
  position: center;
  width: 100%;
  height: 800px;
  border-bottom: 5px solid black;
}

.blog-title {
  font-family: Snell Roundhand, cursive;
}

.post-inspo {
  font-family: 'Courier New', Courier, monospace;
}


.active,
.navbar-brand:hover {
  border-top: 1px solid black;
  border-bottom: 1px solid black;
}

@media screen and (max-width: 900px) {
  .the-journey {
    padding-left: 17%;
    justify-content: center;
    font-size: 25px;
  }

  .nav-bar {
    justify-content: center;
    margin: 0;
    display: block;
  }


}
</style>
