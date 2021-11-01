<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('Project:page')">
        <a-form layout="inline">
          <a-row :gutter="48">

            <a-col :md="8" :sm="24">
              <a-form-item label="项目名称">
                <a-input v-model="queryParam.name" allow-clear placeholder="请输入项目名称" />
              </a-form-item>
            </a-col>

            <a-col :md="8" :sm="24">
              <a-form-item label="支架型式">
                <a-select :allowClear="true" style="width: 100%" v-model="queryParam.supportType" placeholder="请选择支架型式">
                  <a-select-option v-for="(item,index) in supportTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
                </a-select>
              </a-form-item>
            </a-col>

            <template v-if="advanced">
              <a-col :md="8" :sm="24">
                <a-form-item label="支架型号">
                  <a-input v-model="queryParam.supportModel" allow-clear placeholder="请输入支架型号" />
                </a-form-item>
              </a-col>

              <a-col :md="8" :sm="24">
                <a-form-item label="立项日期">
                  <a-date-picker
                    style="width: 100%"
                    placeholder="请选择立项日期"
                    v-model="queryParam.projectDateDate"
                    @change="onChangeprojectDate" />
                </a-form-item>
              </a-col>

              <a-col :md="8" :sm="24">
                <a-form-item label="项目备注">
                  <a-input v-model="queryParam.remark" allow-clear placeholder="请输入项目备注" />
                </a-form-item>
              </a-col>
            </template>

            <a-col :md="8" :sm="24">
              <span class="table-page-search-submitButtons">
                <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
                <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
                <a @click="toggleAdvanced" style="margin-left: 8px"> {{ advanced ? '收起' : '展开' }}
                  <a-icon :type="advanced ? 'up' : 'down'" />
                </a>
              </span>
            </a-col>

          </a-row>
        </a-form>
      </div>
    </a-card>
    <a-card :bordered="false">
      <s-table
        ref="table"
        :columns="columns"
        :data="loadData"
        :alert="true"
        :rowKey="(record) => record.id"
        :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }">
        <template class="table-operator" slot="operator" v-if="hasPerm('Project:add')">
          <a-button type="primary" v-if="hasPerm('Project:add')" icon="plus" @click="$refs.addForm.add()">新增项目信息</a-button>
        </template>
        <span slot="supportTypescopedSlots" slot-scope="text">
          {{ 'support_type' | dictType(text) }}
        </span>
        <span slot="typesscopedSlots" slot-scope="text">
          <a-tag v-for="textData in JSON.parse(text)" :key="textData.code" color="green">{{ 'project_type' | dictType(textData) }}</a-tag>
        </span>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('Project:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('Project:edit') & hasPerm('Project:delete')" />
          <a-popconfirm v-if="hasPerm('Project:delete')" placement="topRight" title="确认删除？" @confirm="() => ProjectDelete(record)">
            <a>删除</a>
          </a-popconfirm>
        </span>
      </s-table>
      <add-form ref="addForm" @ok="handleOk" />
      <edit-form ref="editForm" @ok="handleOk" />
    </a-card>
  </div>
</template>
<script>
import { STable } from '@/components'
import moment from 'moment'
import { ProjectPage, ProjectDelete } from '@/api/modular/main/ProjectManage'
import addForm from './addForm.vue'
import editForm from './editForm.vue'
export default {
  components: {
    STable,
    addForm,
    editForm
  },
  data () {
    return {
      advanced: false, // 高级搜索 展开/关闭
      queryParam: {},
      columns: [
        {
          title: '项目名称',
          align: 'left',
          sorter: true,
          dataIndex: 'name',
          width: 120
        },
        {
          title: '项目类型',
          align: 'left',
          sorter: true,
          dataIndex: 'types',
          scopedSlots: { customRender: 'typesscopedSlots' },
          width: 160
        },
        {
          title: '负责人',
          align: 'left',
          sorter: true,
          customRender: (vlaue, record) => record.sysUserName,
          dataIndex: 'userIds',
          width: 120
        },
        {
          title: '支架型式',
          align: 'left',
          sorter: true,
          dataIndex: 'supportType',
          scopedSlots: { customRender: 'supportTypescopedSlots' },
          width: 120
        },
        {
          title: '支架型号',
          align: 'left',
          sorter: true,
          dataIndex: 'supportModel',
          width: 120
        },
        {
          title: '立项日期',
          align: 'left',
          sorter: true,
          dataIndex: 'projectDate',
          width: 120
        },
        {
          title: '项目备注',
          align: 'left',
          sorter: true,
          dataIndex: 'remark',
          width: 120
        },
        {
          title: '客户集团',
          align: 'left',
          sorter: true,
          customRender: (vlaue, record) => record.customerName,
          dataIndex: 'customerGroupId',
          width: 120
        },
        {
          title: '客户煤矿',
          align: 'left',
          sorter: true,
          customRender: (vlaue, record) => record.customerName,
          dataIndex: 'customerMineId',
          width: 120
        }
      ],
      tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
      // 加载数据方法 必须为 Promise 对象
      loadData: parameter => {
        return ProjectPage(Object.assign(parameter, this.switchingDate())).then((res) => {
          return res.data
        })
      },
      supportTypeData: [],
      selectedRowKeys: [],
      selectedRows: []
    }
  },
  created () {
    if (this.hasPerm('Project:edit') || this.hasPerm('Project:delete')) {
      this.columns.push({
        title: '操作',
        width: '130px',
        dataIndex: 'action',
        scopedSlots: { customRender: 'action' },
        fixed: 'right'
      })
    }
    // 注释: 在data外面定义的属性和方法通过this.$options可以获取和调用
    const supportTypeOption = this.$options
    this.supportTypeData = supportTypeOption.filters['dictData']('support_type')
  },
  methods: {
    moment,
    /**
     * 查询参数组装
     */
    switchingDate () {
      const queryParamprojectDate = this.queryParam.projectDateDate
      if (queryParamprojectDate != null) {
        this.queryParam.projectDate = moment(queryParamprojectDate).format('YYYY-MM-DD')
        if (queryParamprojectDate.length < 1) {
          delete this.queryParam.projectDate
        }
      }
      const obj = JSON.parse(JSON.stringify(this.queryParam))
      return obj
    },
    ProjectDelete (record) {
      ProjectDelete(record).then((res) => {
        if (res.success) {
          this.$message.success('删除成功')
          this.$refs.table.refresh()
        } else {
          this.$message.error('删除失败') // + res.message
        }
      })
    },
    toggleAdvanced () {
      this.advanced = !this.advanced
    },
    onChangeprojectDate (date, dateString) {
      this.projectDateDateString = dateString
    },
    handleOk () {
      this.$refs.table.refresh()
    },
    onSelectChange (selectedRowKeys, selectedRows) {
      this.selectedRowKeys = selectedRowKeys
      this.selectedRows = selectedRows
    }
  }
}
</script>
<style lang="less">
.table-operator {
  margin-bottom: 18px;
}
button {
  margin-right: 8px;
}
</style>
