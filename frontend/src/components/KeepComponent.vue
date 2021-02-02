<template>
  <div class="col-4 keep-component mt-2">
      <div class="p-2 shadow-lg radius">

    <h3>
        {{ keep.CreatorId }}
    </h3>
    <p>
        {{ keep.Name }}
        </p>
        <p>

    {{ keep.Description }}
        </p>
      </div>
    
  </div>
</template>

<script>

import { computed } from 'vue'
export default {
  name: 'KeepComponent',
  props: ['keepProps'],
  setup(props) {
    return {
        keep: computed(() => props.keepProps)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.radius {
    border-radius: 25px;
}
</style>