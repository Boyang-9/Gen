import { axios } from '@/utils/request'

/**
 * 获取客户组织机构树
 */
export function CustomerTree (parameter) {
  return axios({
    url: '/Customer/tree',
    method: 'get',
    params: parameter
  })
}

/**
 * 查询客户组织机构表
 */
export function CustomerPage (parameter) {
  return axios({
    url: '/Customer/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 客户组织机构表列表
 */
export function CustomerList (parameter) {
  return axios({
    url: '/Customer/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加客户组织机构表
 */
export function CustomerAdd (parameter) {
  return axios({
    url: '/Customer/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑客户组织机构表
 */
export function CustomerEdit (parameter) {
  return axios({
    url: '/Customer/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除客户组织机构表
 */
export function CustomerDelete (parameter) {
  return axios({
    url: '/Customer/delete',
    method: 'post',
    data: parameter
  })
}
