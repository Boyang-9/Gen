<template>
  <a-modal
    title="新增客户组织"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="上级组织" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-tree-select
            v-decorator="['pid', { rules: [{ required: true, message: '请选择上级组织！' }] }]"
            style="width: 100%"
            :dropdownStyle="{ maxHeight: '300px', overflow: 'auto' }"
            :treeData="orgTree"
            placeholder="请选择上级组织"
            treeDefaultExpandAll
          >
            <span slot="title" slot-scope="{ id }">{{ id }}</span>
          </a-tree-select>
        </a-form-item>

        <a-form-item label="客户名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input
            placeholder="请输入名称"
            v-decorator="['name', { rules: [{ required: true, message: '请输入客户名称！' }] }]"
          />
        </a-form-item>
        <a-form-item label="客户类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-radio-group
            placeholder="请选择客户类型"
            v-decorator="['customerType', { rules: [{ required: true, message: '请选择客户类型！' }] }]"
          >
            <a-radio
              v-for="(item, index) in customerEnumDataDropDown"
              :key="index"
              :value="parseInt(item.code)"
            >{{ item.name }}</a-radio>
          </a-radio-group>
        </a-form-item>

        <a-form-item label="排序" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input-number placeholder="请输入排序" style="width: 100%" v-decorator="['sort']" />
        </a-form-item>
        <a-form-item label="备注" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入备注" v-decorator="['remark']" />
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
import { CustomerAdd, CustomerTree } from '@/api/modular/main/CustomerManage'
export default {
  data() {
    return {
      labelCol: {
        xs: { span: 24 },
        sm: { span: 5 }
      },
      wrapperCol: {
        xs: { span: 24 },
        sm: { span: 15 }
      },
      customerEnumDataDropDown: [],
      orgTree: [],
      visible: false,
      confirmLoading: false,
      form: this.$form.createForm(this)
    }
  },
  created() {},
  methods: {
    // 初始化方法
    add(record) {
      this.visible = true

      const customerTypeOption = this.$options
      this.customerEnumDataDropDown = customerTypeOption.filters['dictData']('customer_type')
      this.CustomerTree()
    },
    /**
     * 获取机构树，并加载于表单中
     */
    CustomerTree() {
      CustomerTree().then(res => {
        this.formLoading = false
        if (!res.success) {
          this.orgTree = []
          return
        }
        this.orgTree = [
          {
            id: '-1',
            parentId: '0',
            title: '顶级',
            value: '0',
            pid: '0',
            children: res.data
          }
        ]
      })
    },

    /**
     * 提交表单
     */
    handleSubmit() {
      const {
        form: { validateFields }
      } = this
      this.confirmLoading = true
      validateFields((errors, values) => {
        if (!errors) {
          for (const key in values) {
            if (typeof values[key] === 'object') {
              values[key] = JSON.stringify(values[key])
            }
          }
          CustomerAdd(values)
            .then(res => {
              if (res.success) {
                this.$message.success('新增成功')
                this.confirmLoading = false
                this.$emit('ok', values)
                this.handleCancel()
              } else {
                this.$message.error('新增失败：' + JSON.stringify(res.message))
              }
            })
            .finally(res => {
              this.confirmLoading = false
            })
        } else {
          this.confirmLoading = false
        }
      })
    },
    handleCancel() {
      this.form.resetFields()
      this.visible = false
    }
  }
}
</script>
