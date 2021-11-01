<template>
  <a-modal
    title="编辑客户组织机构表"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input
            placeholder="请输入名称"
            v-decorator="['name', { rules: [{ required: true, message: '请输入名称！' }] }]"
          />
        </a-form-item>
        <a-form-item label="客户组织类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-radio-group
            placeholder="请选择客户组织类型}"
            v-decorator="['customerType', { rules: [{ required: true, message: '请选择客户组织类型！' }] }]"
          >
            <a-radio
              v-for="(item, index) in customerTypeData"
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
        <a-form-item v-show="false">
          <a-input v-decorator="['id']" />
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
import { CustomerEdit } from '@/api/modular/main/CustomerManage'
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
      record: {},
      customerTypeData: [],
      visible: false,
      confirmLoading: false,
      form: this.$form.createForm(this)
    }
  },
  methods: {
    // 初始化方法
    edit(record) {
      this.visible = true
      this.record = record
      const customerTypeOption = this.$options
      this.customerTypeData = customerTypeOption.filters['dictData']('customer_type')

      this.$nextTick(() => {
        this.form.setFieldsValue({
          id: record.id,
          mineGroupId: record.mineGroupId,
          name: record.name,
          customerType: record.customerType,
          sort: record.sort,
          remark: record.remark || ''
        })
      })
    },
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
              this.record[key] = values[key]
            } else {
              this.record[key] = values[key]
            }
          }

          CustomerEdit(this.record)
            .then(res => {
              if (res.success) {
                this.$message.success('编辑成功')
                this.confirmLoading = false
                this.$emit('ok', this.record)
                this.handleCancel()
              } else {
                this.$message.error('编辑失败：' + JSON.stringify(res.message))
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
