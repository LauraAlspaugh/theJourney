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
    <section class="row justify-content-center mb-5">
      <div class="col-4 gray-box">

      </div>
      <div class="col-4">
        <img
          src="https://images.unsplash.com/photo-1505033575518-a36ea2ef75ae?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fHByb2ZpbGUlMjBpbWFnZXxlbnwwfHwwfHx8MA%3D%3D"
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

.gray-box {
  position: relative;
  background-color: gray;
  width: 30%;
  height: 490px;
  box-shadow: 0px 5px 10px #888888;
  box-shadow: 0px 15px 9px #888888;
  bottom: 20%;
}

img {
  position: absolute;
  left: 48%;
  bottom: 7%;
  border: 3px solid black;
  width: 30%;
  height: 550px;
  object-fit: cover;
  position: center;
  margin-bottom: 5px;
}
</style>
