using Furion.Extras.Admin.NET;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Furion.LinqBuilder;

namespace Admin.NET.Application
{
    /// <summary>
    /// 客户组织机构表服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "Customer", Order = 100)]
    public class CustomerService : ICustomerService, IDynamicApiController, ITransient
    {
        private readonly IRepository<Customer> _rep;

        public CustomerService(IRepository<Customer> rep)
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询客户组织机构表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/Customer/page")]
        public async Task<dynamic> Page([FromQuery] CustomerInput input)
        {
            var entities = await _rep.DetachedEntities
                .Where(!input.Pid.IsNullOrEmpty(),
                    x =>
                        EF.Functions.Like(x.Pids, $"%{input.Pid}%") || x.Id == long.Parse(input.Pid.Trim())
                )
                .Where(!input.Name.IsNullOrEmpty(), x => x.Name.Contains(input.Name))
                .Where(input.CustomerType > 0, x => x.CustomerType == input.CustomerType)
                .OrderBy(x => x.CustomerType).ThenBy(x => x.Sort)
                .ToPagedListAsync(input.PageNo, input.PageSize);

            var result = XnPageResult<Customer>.PageResult<CustomerDto>(entities);
            return result;
        }

        /// <summary>
        /// 增加客户组织机构表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/Customer/add")]
        public async Task Add(AddCustomerInput input)
        {
            var entity = input.Adapt<Customer>();
            await FillPids(entity);
            await entity.InsertAsync();
        }

        /// <summary>
        /// 填充父Ids字段
        /// </summary>
        /// <param name>customer</para>
        /// <returns></returns>
        private async Task FillPids(Customer customer)
        {
            if (customer.Pid == 0L)
            {
                customer.Pids = "[" + 0 + "],";
            }
            else
            {
                var t = await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == customer.Pid);
                customer.Pids = t.Pids + "[" + t.Id + "],";
            }
        }

        /// <summary>
        /// 删除客户组织机构表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/Customer/delete")]
        public async Task Delete(DeleteCustomerInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.FakeDeleteNowAsync();
        }

        /// <summary>
        /// 更新客户组织机构表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/Customer/edit")]
        public async Task Update(UpdateCustomerInput input)
        {
            var entity = input.Adapt<Customer>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取客户组织机构表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/Customer/detail")]
        public async Task<Customer> Get([FromQuery] QueryeCustomerInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取客户组织机构表列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/Customer/list")]
        public async Task<dynamic> List([FromQuery] CustomerInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }

        /// <summary>
        /// 获取客户组织机构树
        /// </summary>
        /// <returns></returns>
        [HttpGet("/Customer/tree")]
        public async Task<dynamic> GetCustomerTree()
        {
            var customers = await _rep.DetachedEntities
                .OrderBy(u => u.Sort)
                .Select(x => new CustomerTreeNode
                {
                    Id = x.Id,
                    ParentId = x.Pid,
                    Title = x.Name,
                    Value = x.Id.ToString(),
                    Weight = x.Sort
                }).ToListAsync();
            return new TreeBuildUtil<CustomerTreeNode>().Build(customers);
        }
    }
}