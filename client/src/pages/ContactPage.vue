<template>
    <div class="container-fluid m-0 p-0">
        <section class="row m-0 p-0 mt-5">
            <div class="col-12 col-md-5 the-journey">
                <p class="the-journey">The Journey.</p>
            </div>
            <div class="col-12 col-md-5  nav-bar">
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
        <section class="row justify-content-evenly contact-info">
            <div class="col-12 col-md-7 p-0 gray-box d-flex flex-column align-items-center">
                <div class="w-100">
                    <p class="text-center fs-5 mt-5 news-intro">Read Our Newsletter.</p>
                    <form action="https://formspree.io/f/mleqbkye" method="POST"
                        class="d-flex flex-column align-items-center">
                        <div class="d-flex justify-content-around align-items-center mt-5 w-100 email-space">
                            <p class="mb-0">Email *</p>
                            <button type="submit" role="button" @click="createSubscriber()"
                                class="subscribe btn">Subscribe</button>
                        </div>
                        <label for="body" class="form-label"></label>
                        <input v-model="editable.email" type="text" required rows="1" class="form-control w-75" id="body"
                            name="email" placeholder="email...">
                    </form>
                    <!-- <form action="https://formspree.io/f/mleqbkye" method="POST">
                        <label>
                            Your email:
                            <input type="email" name="email">
                        </label>
                         <label>
                            Your message:
                            <textarea name="message"></textarea>
                        </label> 
                     
                        <button type="submit">Subscribe</button>
                    </form> -->
                </div>
                <div class="w-75">
                    <hr>
                </div>
            </div>
            <div class="col-12 text-center">
                <p class="fs-4 connected">Get in Touch.</p>
                <p class="email-info">lauraalspaugh2002@icloud.com</p>
            </div>
        </section>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import { postsService } from '../services/PostsService.js';
import { useRoute } from 'vue-router';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
export default {
    setup() {
        const editable = ref({})
        const route = useRoute()
        return {
            editable,
            route,
            async createSubscriber() {
                try {
                    const subscribeData = editable.value
                    subscribeData.postId = route.params.postId
                    await postsService.createSubscriber(subscribeData)
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            },
        }
    }
};
</script>


<style lang="scss" scoped>
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
    align-items: center;

}

.nav-bar {
    display: flex;
    justify-content: space-evenly;
    margin: 5px;
}

.container {
    margin-right: 0;
}

textarea {
    border: none;
    background-color: white;
    width: 75%;
    justify-content: center;
    display: flex;

}

input {
    border: none;
}

::placeholder {
    color: white;
}

.active,
.navbar-brand:hover {
    border-top: black 1px solid;
    border-bottom: 1px solid black;
}

.contact-info {
    margin-right: 0;
    align-items: center;
    background-position: center;
    background-size: cover;
    background-repeat: no-repeat;
    height: 500px;
    background-image: url("https://images.unsplash.com/photo-1540544321-a0e92b02d975?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTk3fHxpbnRlcmlvciUyMGFlc3R8ZW58MHx8MHx8fDA%3D");
    border-bottom: 3px solid gray;
}

.gray-box {
    background-color: white;
    height: 300px;
    width: 600px;
}

.news-intro {
    font-family: 'Courier New', Courier, monospace;
}

.email-info {
    font-family: cursive;
    font-size: 20px;
}

.connected {
    font-family: Courier New;
}

.subscribe {
    font-weight: bold;
    border: none;
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

// .email-space {
//     border-bottom: 2px solid black;

// }
</style>