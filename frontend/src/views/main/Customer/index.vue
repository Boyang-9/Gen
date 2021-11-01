<template>
  <a-row :gutter="24">
    <a-col :md="5" :sm="24" style="padding: 0 0 0 0;">
      <a-card :bordered="false" :loading="loading">
        <div v-if="Array.isArray(this.orgTree)">
          <a-tree
            style="scroll:true"
            :treeData="orgTree"
            v-if="orgTree.length"
            @select="handleClick"
            :defaultExpandAll="true"
            :defaultExpandedKeys="defaultExpandedKeys"
            :replaceFields="replaceFields"
          />
        </div>
        <div v-else>
          <a-empty :image="simpleImage" />
        </div>
      </a-card>
    </a-col>

    <a-col :md="19" :sm="24">
      <a-card :bordered="false" :bodyStyle="tstyle">
        <div class="table-page-search-wrapper" v-if="hasPerm('Customer:page')">
          <a-form layout="inline">
            <a-row :gutter="48">
              <a-col :md="8" :sm="24">
                <a-form-item label="名称">
                  <a-input v-model="queryParam.name" allow-clear placeholder="请输入名称" />
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="客户组织类型">
                  <a-select
                    :allowClear="true"
                    style="width: 100%"
                    v-model="queryParam.customerType"
                    placeholder="请选择客户组织类型"
                  >
                    <a-select-option
                      v-for="(item, index) in customerTypeData"
                      :key="index"
                      :value="item.code"
                    >{{ item.name }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col>

              <a-col :md="8" :sm="24">
                <span class="table-page-search-submitButtons">
                  <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
                  <a-button style="margin-left: 8px" @click="() => (queryParam = {})">重置</a-button>
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
          <template class="table-operator" slot="operator" v-if="hasPerm('Customer:add')">
            <a-button
              type="primary"
              v-if="hasPerm('Customer:add')"
              icon="plus"
              @click="$refs.addForm.add()"
            >新增客户组织</a-button>
          </template>

          <span
            slot="customerTypescopedSlots"
            slot-scope="text"
          >{{ 'customer_type' | dictType(text) }}</span>

          <span slot="action" slot-scope="text, record">
            <a v-if="hasPerm('Customer:edit')" @click="$refs.editForm.edit(record)">编辑</a>
            <a-divider
              type="vertical"
              v-if="hasPerm('Customer:edit') & hasPerm('Customer:delete')"
            />
            <a-popconfirm
              v-if="hasPerm('Customer:delete')"
              placement="topRight"
              title="确认删除？"
              @confirm="() => CustomerDelete(record)"
            >
              <a>删除</a>
            </a-popconfirm>
          </span>
        </s-table>
        <add-form ref="addForm" @ok="handleOk" />
        <edit-form ref="editForm" @ok="handleOk" />
      </a-card>
    </a-col>
  </a-row>
</template>
<script>
import { STable } from '@/components'
import { CustomerPage, CustomerDelete, CustomerTree } from '@/api/modular/main/CustomerManage'
import addForm from './addForm.vue'
import editForm from './editForm.vue'
import { Empty } from 'ant-design-vue'

export default {
  components: {
    STable,
    addForm,
    editForm
  },
  data() {
    return {
      loading: false,
      orgTree: null,
      simpleImage: Empty.PRESENTED_IMAGE_SIMPLE,
      defaultExpandedKeys: [],
      replaceFields: { key: 'id' },

      advanced: false, // 高级搜索 展开/关闭
      queryParam: {},
      columns: [
        {
          title: '名称',
          align: 'center',
          sorter: true,
          dataIndex: 'name'
        },
        {
          title: '客户组织类型',
          align: 'center',
          sorter: true,
          dataIndex: 'customerType',
          scopedSlots: { customRender: 'customerTypescopedSlots' }
        },
        {
          title: '排序',
          align: 'center',
          sorter: true,
          dataIndex: 'sort'
        },
        {
          title: '备注',
          align: 'center',
          sorter: true,
          dataIndex: 'remark'
        }
      ],
      tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
      // 加载数据方法 必须为 Promise 对象
      loadData: parameter => {
        return CustomerPage(Object.assign(parameter, this.queryParam)).then(res => {
          return res.data
        })
      },
      customerTypeData: [],
      selectedRowKeys: [],
      selectedRows: []
    }
  },
  created() {
    if (this.hasPerm('Customer:edit') || this.hasPerm('Customer:delete')) {
      this.columns.push({
        title: '操作',
        width: '150px',
        dataIndex: 'action',
        scopedSlots: { customRender: 'action' }
      })
    }
    const customerTypeOption = this.$options
    this.customerTypeData = customerTypeOption.filters['dictData']('customer_type')

    this.getOrgTree()
  },
  methods: {
    /**
     * 查询参数组装
     */
    switchingDate() {
      const obj = JSON.parse(JSON.stringify(this.queryParam))
      return obj
    },
    /**
     * 获取到机构树，展开顶级下树节点，考虑到后期数据量变大，不建议全部展开
     */
    getOrgTree() {
      CustomerTree(Object.assign(this.queryParam)).then(res => {
        this.loading = false
        if (!res.success || res.data.length === 0) {
          return
        }
        this.orgTree = res.data
        this.queryParam.parentId = this.orgTree[0].id
        // 全部展开，上面api方法提供的不生效，先用此方法
        for (var item of res.data) {
          // eslint-disable-next-line eqeqeq
          if (item.parentId == 0) {
            this.defaultExpandedKeys.push(item.id)
          }
        }
        this.$refs.table.refresh()
      })
    },
    CustomerDelete(record) {
      CustomerDelete(record).then(res => {
        if (res.success) {
          this.$message.success('删除成功')
          this.$refs.table.refresh()
        } else {
          this.$message.error('删除失败') // + res.message
        }
      })
    },
    handleClick(e) {
      this.queryParam = {
        pid: e.toString()
      }
      this.$refs.table.refresh(true)
    },
    toggleAdvanced() {
      this.advanced = !this.advanced
    },
    handleOk() {
      this.getOrgTree()
    },
    onSelectChange(selectedRowKeys, selectedRows) {
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
