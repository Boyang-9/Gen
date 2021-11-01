<template>
  <a-modal
    title="编辑项目信息"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="负责人" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-select style="width: 100%" placeholder="请选择负责人" v-decorator="['userIds']">
            <a-select-option v-for="(item,index) in SysUserData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="支架型式" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select
            style="width: 100%"
            placeholder="请选择支架型式"
            v-decorator="['supportType', {rules: [{ required: true, message: '请选择支架型式！' }]}]">
            <a-select-option v-for="(item,index) in supportTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="支架型号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入支架型号" v-decorator="['supportModel']" />
        </a-form-item>
        <a-form-item label="立项日期" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-date-picker style="width: 100%" placeholder="请选择立项日期" v-decorator="['projectDate']" @change="onChangeprojectDate" />
        </a-form-item>
        <a-form-item label="项目备注" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入项目备注" v-decorator="['remark']" />
        </a-form-item>
        <a-form-item label="客户集团" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-select style="width: 100%" placeholder="请选择客户集团" v-decorator="['customerGroupId']">
            <a-select-option v-for="(item,index) in CustomerGroupData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="客户煤矿" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-select style="width: 100%" placeholder="请选择客户煤矿" v-decorator="['customerMineId']">
            <a-select-option v-for="(item,index) in CustomerMineData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item v-show="false">
          <a-input v-decorator="['id']" />
        </a-form-item>
        <a-form-item label="项目名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入项目名称" v-decorator="['name', {rules: [{required: true, message: '请输入项目名称！'}]}]" />
        </a-form-item>
        <a-form-item label="项目类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-checkbox-group placeholder="请选择项目类型" v-decorator="['types',{rules: [{ required: true, message: '请选择项目类型！' }]}]">
            <a-checkbox v-for="(item,index) in typesData" :key="index" :value="item.code">{{ item.name }}</a-checkbox>
          </a-checkbox-group>
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
import moment from 'moment'
import {
  ProjectFkSysUserList,
  ProjectFkCustomerGroupList,
  ProjectFkCustomerMineList,
  ProjectEdit
} from '@/api/modular/main/ProjectManage'
export default {
  data () {
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
      supportTypeData: [],
      projectDateDateString: '',
      typesData: [],
      SysUserData: [],
      CustomerGroupData: [],
      CustomerMineData: [],
      visible: false,
      confirmLoading: false,
      form: this.$form.createForm(this)
    }
  },
  methods: {
    ProjectFkSysUserList () {
      ProjectFkSysUserList().then(res => {
        this.SysUserData = res.data
      })
    },
    ProjectFkCustomerGroupList () {
      ProjectFkCustomerGroupList().then(res => {
        this.CustomerGroupData = res.data
      })
    },
    ProjectFkCustomerMineList () {
      ProjectFkCustomerMineList().then(res => {
        this.CustomerMineData = res.data
      })
    },
    moment,
    // 初始化方法
    edit (record) {
      this.visible = true
      this.record = record
      const supportTypeOption = this.$options
      this.supportTypeData = supportTypeOption.filters['dictData']('support_type')
      const typesOption = this.$options
      this.typesData = typesOption.filters['dictData']('project_type')
      setTimeout(() => {
        this.form.setFieldsValue({
          id: record.id,
          userIds: record.userIds,
          supportType: record.supportType,
          supportModel: record.supportModel,
          remark: record.remark,
          customerGroupId: record.customerGroupId,
          customerMineId: record.customerMineId,
          name: record.name,
          types: JSON.parse(record.types)
        })
      }, 100)

      if (record.projectDate) {
        this.form.getFieldDecorator('projectDate', { initialValue: moment(record.projectDate, 'YYYY-MM-DD') })
        this.projectDateDateString = moment(record.projectDate).format('YYYY-MM-DD')
      }
      this.ProjectFkSysUserList()
      this.ProjectFkCustomerGroupList()
      this.ProjectFkCustomerMineList()
    },
    handleSubmit () {
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
          values.projectDate = this.projectDateDateString
          this.record.projectDate = this.projectDateDateString
          ProjectEdit(this.record)
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
    onChangeprojectDate (date, dateString) {
      this.projectDateDateString = dateString
    },
    handleCancel () {
      this.form.resetFields()
      this.visible = false
    }
  }
}
</script>
