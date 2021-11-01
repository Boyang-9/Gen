using Furion.Extras.Admin.NET;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Furion.Extensions;

namespace Admin.NET.Application
{
    /// <summary>
    /// 项目信息服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "Project", Order = 100)]
    public class ProjectService : IProjectService, IDynamicApiController, ITransient
    {
        private readonly IRepository<Project> _rep;
        private readonly IRepository<SysUser> _sysUserRep;
        private readonly IRepository<Customer> _customerRep;

        public ProjectService(
            IRepository<SysUser> sysUserRep,
            IRepository<Customer> customerRep,
            IRepository<Project> rep
        )
        {
            _sysUserRep = sysUserRep;
            _customerRep = customerRep;
            _rep = rep;
        }

        /// <summary>
        /// 分页查询项目信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/Project/page")]
        public async Task<dynamic> Page([FromQuery] ProjectInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.UserIds), u => EF.Functions.Like(u.UserIds, $"%{input.UserIds.Trim()}%"))
                                     .Where(!string.IsNullOrEmpty(input.SupportType), u => u.SupportType == input.SupportType)
                                     .Where(!string.IsNullOrEmpty(input.SupportModel), u => EF.Functions.Like(u.SupportModel, $"%{input.SupportModel.Trim()}%"))
                                     .Where(input.ProjectDate != null,u => u.ProjectDate == input.ProjectDate)
                                     .Where(!string.IsNullOrEmpty(input.Remark), u => EF.Functions.Like(u.Remark, $"%{input.Remark.Trim()}%"))
                                     .Where(input.CustomerGroupId > 0, u => u.CustomerGroupId == input.CustomerGroupId)
                                     .Where(input.CustomerMineId > 0, u => u.CustomerMineId == input.CustomerMineId)
                                     .Where(!string.IsNullOrEmpty(input.Name), u => EF.Functions.Like(u.Name, $"%{input.Name.Trim()}%"))
                                     .Where(!string.IsNullOrEmpty(input.Types), u => EF.Functions.Like(u.Types, $"%{input.Types.Trim()}%"))
                                     .OrderBy(PageInputOrder.OrderBuilder<ProjectInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<Project>.PageResult<ProjectDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加项目信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/Project/add")]
        public async Task Add(AddProjectInput input)
        {
            var entity = input.Adapt<Project>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/Project/delete")]
        public async Task Delete(DeleteProjectInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/Project/edit")]
        public async Task Update(UpdateProjectInput input)
        {
            var entity = input.Adapt<Project>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取项目信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/Project/detail")]
        public async Task<Project> Get([FromQuery] QueryeProjectInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取项目信息列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/Project/list")]
        public async Task<dynamic> List([FromQuery] ProjectInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    
        
        /// <summary>
        /// 获取SysUser列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Project/fkSysUser")]
        public async Task<dynamic> FkSysUserList()
        {
            var list = await _sysUserRep.DetachedEntities.ToListAsync();
            return list.Select(e => new {Code = e.Id, Name = e.Name});
        }
        
        /// <summary>
        /// 获取Customer列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Project/fkCustomer")]
        public async Task<dynamic> FkCustomerList()
        {
            var list = await _customerRep.DetachedEntities.ToListAsync();
            return list.Select(e => new {Code = e.Id, Name = e.Name});
        }
        
        /// <summary>
        /// 获取Customer列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Project/fkCustomer")]
        public async Task<dynamic> FkCustomerMineList()
        {
            var list = await _customerRep.DetachedEntities.ToListAsync();
            return list.Select(e => new {Code = e.Id, Name = e.Name});
        }

        private async Task DtoMapper(ICollection<ProjectDto> rows)
        {
            foreach (var item in rows)
            {
                // item.SysUserName = (await _sysUserRep.FirstOrDefaultAsync(e => e.Id == item.UserIds))?.Name;
                item.CustomerGroupName = (await _customerRep.FirstOrDefaultAsync(e => e.Id == item.CustomerGroupId))?.Name;
                item.CustomerMineName = (await _customerRep.FirstOrDefaultAsync(e => e.Id == item.CustomerMineId))?.Name;
                item.ProjectDate = item.ProjectDate?.ConvertToDateTime().Date;
            }
        }
    }
}
