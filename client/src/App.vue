<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="text-white">
    <p class="m-5 fs-5 footer-style"><i class="mdi mdi-copyright"></i> 2024 by Laura Alspaugh.</p>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 40px;
  background-color: black;
  box-shadow: 0px 3px 10px gray;
}

.footer-style {
  font-family: cursive;

}
</style>
