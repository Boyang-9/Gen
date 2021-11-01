<template>
  <a-row :gutter="24">
    <a-col :span="5">
      <a-tree
        v-model="checkedKeys"
        checkable
        style="scroll:true"
        :treeData="viewTress"
        :defaultExpandAll="true"
        :defaultExpandedKeys="defaultExpandedKeys"
        :replaceFields="replaceFields"
        :checkStrictly="true"
        @select="handleClick"
      />
    </a-col>
    <a-col>参数</a-col>
  </a-row>
</template>
<script>
import view from './views.json'
export default {
  data() {
    return {
      checkedKeys: [],
      defaultExpandedKeys: [],
      replaceFields: {
        key: 'id'
      },
      viewTress: view
    }
  },
  watch: {
    checkedKeys({ checked }) {}
  },
  methods: {
    handleClick(id, info) {
      console.log(this.defaultExpandedKeys)
    }
  }
}
</script>
