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
              <a-form-item label="项目类型">
                <a-select
                  :allowClear="true"
                  style="width: 100%"
                  v-model="queryParam.supportType"
                  placeholder="请选择项目类型"
                >
                  <!-- <a-select-option v-for="(item, index) in supportTypeData" :key="index" :value="item.code">{{
                    item.name
                  }}</a-select-option> -->
                </a-select>
              </a-form-item>
            </a-col>

            <template v-if="advanced">
              <a-col :md="8" :sm="24">
                <a-form-item label="负责人">
                  <a-select
                    :allowClear="true"
                    style="width: 100%"
                    v-model="queryParam.supportType"
                    placeholder="请选择负责人"
                  >
                    <!-- <a-select-option v-for="(item, index) in supportTypeData" :key="index" :value="item.code">{{
                    item.name
                  }}</a-select-option> -->
                  </a-select>
                </a-form-item>
              </a-col>

              <a-col :md="8" :sm="24">
                <a-form-item label="支架型式">
                  <a-select
                    :allowClear="true"
                    style="width: 100%"
                    v-model="queryParam.supportType"
                    placeholder="请选择支架型式"
                  >
                    <!-- <a-select-option v-for="(item, index) in supportTypeData" :key="index" :value="item.code">{{
                    item.name
                  }}</a-select-option> -->
                  </a-select>
                </a-form-item>
              </a-col>

              <a-col :md="8" :sm="24">
                <a-form-item label="支架型号">
                  <a-input v-model="queryParam.remark" allow-clear placeholder="请输入支架型号" />
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="立项日期">
                  <a-date-picker
                    style="width: 100%"
                    placeholder="请选择立项日期"
                    v-model="queryParam.projectDateDate"
                    @change="onChangeprojectDate"
                  />
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="客户集团">
                  <a-select
                    :allowClear="true"
                    style="width: 100%"
                    v-model="queryParam.customerType"
                    placeholder="请选择客户集团"
                  >
                    <!-- <a-select-option v-for="(item, index) in customerTypeData" :key="index" :value="item.code">{{
                      item.name
                    }}</a-select-option> -->
                  </a-select>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="客户煤矿">
                  <a-select
                    :allowClear="true"
                    style="width: 100%"
                    v-model="queryParam.customerType"
                    placeholder="请选择客户煤矿"
                  >
                    <!-- <a-select-option v-for="(item, index) in customerTypeData" :key="index" :value="item.code">{{
                      item.name
                    }}</a-select-option> -->
                  </a-select>
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
                <a-button style="margin-left: 8px" @click="() => (queryParam = {})">重置</a-button>
                <a @click="toggleAdvanced" style="margin-left: 8px">
                  {{ advanced ? '收起' : '展开' }}
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
        :rowKey="record => record.id"
        :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }"
      >
        <template slot="operator">
          <a-button type="primary" v-if="hasPerm('ProjectInfo:add')" icon="plus" @click="$refs.addForm.add()">新建项目
          </a-button>

          <span slot="supportTypescopedSlots" slot-scope="text">
            {{ 'support_type' | dictType(text) }}
          </span>
          <span slot="typesscopedSlots" slot-scope="text">
            <a-tag v-for="textData in JSON.parse(text)" :key="textData.code" color="green">{{
              'project_type' | dictType(textData)
            }}</a-tag>
          </span>

          <a-popconfirm
            v-if="hasPerm('Project:delete')"
            placement="topRight"
            title="确认删除？"
            @confirm="() => ProjectDelete(record)"
          >
            <a-button icon="delete">删除</a-button>
          </a-popconfirm>

          <a-button v-if="hasPerm('sysUser:export')" icon="down-circle" @click="sysUserExport()">导出</a-button>
        </template>
        <!-- <span slot="sex" slot-scope="text">
          {{ sexFilter(text) }}
        </span>
        <span slot="status" slot-scope="text, record" v-if="hasPerm('sysUser:changeStatus')">
          <a-popconfirm
            placement="top"
            :title="text === 0 ? '确定停用该用户？' : '确定启用该用户？'"
            @confirm="() => editUserStatus(text, record)"
          >
            <a>{{ statusFilter(text) }}</a>
          </a-popconfirm>
        </span>
        <span slot="status" v-else>
          {{ statusFilter(text) }}
        </span> -->
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('sysUser:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('sysUser:edit')" />
          <a-dropdown
            v-if="
              hasPerm('sysUser:resetPwd') ||
                hasPerm('sysUser:grantRole') ||
                hasPerm('sysUser:grantData') ||
                hasPerm('sysUser:delete')
            "
          >
            <a class="ant-dropdown-link">
              更多
              <a-icon type="down" />
            </a>
            <!-- <a-menu slot="overlay">
              <a-menu-item v-if="hasPerm('sysUser:resetPwd')">
                <a-popconfirm placement="topRight" title="确认重置密码？" @confirm="() => resetPwd(record)">
                  <a>重置密码</a>
                </a-popconfirm>
              </a-menu-item>
              <a-menu-item v-if="hasPerm('sysUser:grantRole')">
                <a @click="$refs.userRoleForm.userRole(record)">授权角色</a>
              </a-menu-item>
              <a-menu-item v-if="hasPerm('sysUser:grantData')">
                <a @click="$refs.userOrgForm.userOrg(record)">授权数据</a>
              </a-menu-item>
              <a-menu-item v-if="hasPerm('sysUser:delete')">
                <a-popconfirm placement="topRight" title="确认删除？" @confirm="() => sysUserDelete(record)">
                  <a>删除</a>
                </a-popconfirm>
              </a-menu-item>
            </a-menu> -->
          </a-dropdown>
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
import { sysUserExport } from '@/api/modular/system/userManage'
import { ProjectPage, ProjectDelete } from '@/api/modular/main/ProjectManage'

import addForm from './addForm.vue'
import editForm from './editForm.vue'
export default {
  components: {
    STable,
    addForm,
    editForm
  },
  data() {
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
          width: 120
        },
        {
          title: '负责人',
          align: 'left',
          sorter: true,
          dataIndex: 'types',
          scopedSlots: { customRender: 'typesscopedSlots' },
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
          title: '客户集团',
          align: 'center',
          sorter: true,
          dataIndex: 'customerType',
          scopedSlots: { customRender: 'customerTypescopedSlots' },
          width: 120
        },
        {
          title: '客户煤矿',
          align: 'center',
          sorter: true,
          dataIndex: 'customerType',
          scopedSlots: { customRender: 'customerTypescopedSlots' },
          width: 120
        },
        {
          title: '项目备注',
          align: 'left',
          sorter: true,
          dataIndex: 'remark',
          width: 110
        }
      ],
      tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
      // 加载数据方法 必须为 Promise 对象
      loadData: parameter => {
        return ProjectPage(Object.assign(parameter, this.switchingDate())).then(res => {
          return res.data
        })
      },
      // supportTypeData: [],

      selectedRowKeys: [],
      selectedRows: []
    }
  },
  created() {
    if (this.hasPerm('Project:edit') || this.hasPerm('Project:delete')) {
      this.columns.push({
        title: '操作',
        width: '130px',
        dataIndex: 'action',
        scopedSlots: { customRender: 'action' },
        fixed: 'right'
      })
    }
    const supportTypeOption = this.$options
    this.supportTypeData = supportTypeOption.filters['dictData']('support_type')
  },
  methods: {
    // 收起和展开
    toggleAdvanced() {
      this.advanced = !this.advanced
    },

    // 时间范围选择
    onChangeprojectDate(date, dateString) {
      this.projectDateDateString = dateString
    },

    // 时间格式化
    moment,
    /**
     * 查询参数组装
     */
    switchingDate() {
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

    // 删除
    ProjectDelete(record) {
      ProjectDelete(record).then(res => {
        if (res.success) {
          this.$message.success('删除成功')
          this.$refs.table.refresh()
        } else {
          this.$message.error('删除失败') // + res.message
        }
      })
    },

    // 编辑和新建项目
    handleOk() {
      this.$refs.table.refresh()
    },

    // table组件
    onSelectChange(selectedRowKeys, selectedRows) {
      this.selectedRowKeys = selectedRowKeys
      this.selectedRows = selectedRows
    },

    // 导出用户文件
    sysUserExport(e) {
      this.cardLoading = true
      sysUserExport()
        .then(res => {
          this.cardLoading = false
          this.downloadfile(res)
          // eslint-disable-next-line handle-callback-err
        }).catch(err => {
          this.cardLoading = false
          this.$message.error('下载错误：获取文件流错误')
        })
    },
    downloadfile(res) {
      var blob = new Blob([res.data], {
        type: 'application/octet-stream;charset=UTF-8'
      })
      var contentDisposition = res.headers['content-disposition']
      const filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/
      const matches = filenameRegex.exec(contentDisposition)
      const filename = matches[1].replace(/['"]/g, '')
      var downloadElement = document.createElement('a')
      var href = window.URL.createObjectURL(blob) // 创建下载的链接
      var reg = /^["](.*)["]$/g
      downloadElement.style.display = 'none'
      downloadElement.href = href
      downloadElement.download = decodeURI(filename.replace(reg, '$1')) // 下载后文件名
      document.body.appendChild(downloadElement)
      downloadElement.click() // 点击下载
      document.body.removeChild(downloadElement) // 下载完成移除元素
      window.URL.revokeObjectURL(href)
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
