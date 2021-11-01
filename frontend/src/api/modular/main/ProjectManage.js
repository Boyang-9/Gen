import { axios } from '@/utils/request'

/**
 * 查询项目信息
 *
 * @author zhaoww
 */
export function ProjectPage (parameter) {
  return axios({
    url: '/Project/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 项目信息列表
 *
 * @author zhaoww
 */
export function ProjectList (parameter) {
  return axios({
    url: '/Project/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加项目信息
 *
 * @author zhaoww
 */
export function ProjectAdd (parameter) {
  return axios({
    url: '/Project/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑项目信息
 *
 * @author zhaoww
 */
export function ProjectEdit (parameter) {
  return axios({
    url: '/Project/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除项目信息
 *
 * @author zhaoww
 */
export function ProjectDelete (parameter) {
  return axios({
    url: '/Project/delete',
    method: 'post',
    data: parameter
  })
}

/**
* 获取SysUser列表
* @author zhaoww
*/
export function ProjectFkSysUserList () {
  return axios({
    url: '/Project/fkSysUser',
    method: 'get'
  })
}

/**
* 获取CustomerGroup列表
* @author zhaoww
*/
export function ProjectFkCustomerGroupList () {
  return axios({
    url: '/Project/fkCustomerGroup',
    method: 'get'
  })
}

/**
* 获取CustomerMine列表
* @author zhaoww
*/
export function ProjectFkCustomerMineList () {
  return axios({
    url: '/Project/fkCustomerMine',
    method: 'get'
  })
}
