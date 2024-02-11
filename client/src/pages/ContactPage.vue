<template>
    <div class="container-fluid">
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
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup() {
        return {}
    }
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
</style>