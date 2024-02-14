<template>
  <div class="container-fluid">
    <section class="row mt-5 header-section">
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
      <div class="col-12 gray-space">

      </div>
    </section>
    <section class="row justify-content-center mb-5">
      <div class="col-4 gray-box">
        <p class="fs-2 hey-text p-3">Hey There.</p>
        <p class="p-3 about-text">I'm Laura. I'm so glad your here. Here's where I share what's been inspiring me and what
          I'm
          learning on this
          journey called LIFE. Never meant to be traveled alone, let's go together.

          I believe with all my heart that so much good can come from hard things.

          I love good chats. Exercise. Traveling. And a whole lot of other things.

          Jesus needs to be first in my life.

          And oh, I like to think I'm a minimalist.

          The west is beautiful. If you have doubts, come see for yourself. Thank me later. ​​</p>
      </div>
      <div class="col-4">
        <img src="../assets/img/lauradowntown.png" alt="">
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

// .header-section {
//   box-shadow: 0px 3px 10px gray;
// }

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
  top: 50%;
  border: 3px solid black;
  width: 30%;
  height: 550px;
  object-fit: cover;
  position: center;
  margin-bottom: 5px;
}

.hey-text {
  font-family: lucinda handwriting, cursive;
}

.about-text {
  font-family: 'Courier New', Courier, monospace;
}

.gray-space {
  background-color: #E5E4E2;
  width: 100%;
  height: 200px;
  box-shadow: 0px 3px 10px gray;
}
</style>
