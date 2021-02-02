<template>
  <div class="container-fluid keep-list">
    <div class="row">

    <keep-component v-for="keep in keeps" :key="keep.Id" :keepProps="keep"/>
    </div>
  </div>
</template>

<script>
import KeepComponent from './KeepComponent.vue';
import { AppState } from '../AppState';
import { computed, onMounted } from "vue";
import { keepsService } from '../../Services/KeepsService';

export default {
  components: { KeepComponent },
  name: "KeepList",
  props: {
    msg: String
  },
  setup () {
    onMounted(() => { 
      keepsService.getKeeps();
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
