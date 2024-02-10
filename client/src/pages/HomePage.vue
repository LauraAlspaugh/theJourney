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
    <section class="row">
      <div class="col-12 p-0">
        <img class="img-fluid"
          src="https://images.unsplash.com/photo-1625585598750-3535fe40efb3?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjd8fHBvdHRlZCUyMHNuYWtlJTIwcGxhbnR8ZW58MHx8MHx8fDA%3D"
          alt="">
      </div>
    </section>
  </div>
</template>

<script>
export default {
  setup() {
    return {

    }
  }
}
</script>

<style scoped lang="scss">
.the-journey {
  font-size: 50px;
  font-family: cursive;
  padding-left: 80px;
}

.nav-bar {
  font-family: Courier New;
  font-size: 18px;
}

img {
  object-fit: cover;
  position: center;
  width: 100%;
  height: 525px;
  border-bottom: 5px solid black;
}
</style>
