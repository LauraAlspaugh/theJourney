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
                    <div class="d-flex justify-content-around mt-5 email-space">
                        <p>Email *</p>
                        <p class="subscribe">Subscribe</p>
                    </div>
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
    display: flex;
    justify-content: space-evenly;
    margin: 5px;
}

.container {
    margin-right: 0;
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
}

@media screen and (max-width: 900px) {
    .the-journey {
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