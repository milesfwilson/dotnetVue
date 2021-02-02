<template>
  <div class="home">
    <KeepList />
  </div>
</template>

<script>
// @ is an alias to /src
import KeepList from "@/components/KeepList.vue";

export default {
  name: "Home",
  components: {
    KeepList
  }
};
</script>
