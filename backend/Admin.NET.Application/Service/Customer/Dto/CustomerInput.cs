using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 客户组织机构表输入参数
    /// </summary>
    public class CustomerInput : PageInputBase
    {
        /// <summary>
        /// 父Id
        /// </summary>
        public virtual string Pid { get; set; }

        /// <summary>
        /// 父Ids
        /// </summary>
        public virtual string Pids { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 客户组织类型
        /// </summary>
        public virtual Admin.NET.Application.CustomerTypeEnum CustomerType { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// GPS
        /// </summary>
        public virtual string Gps { get; set; }
    }

    public class AddCustomerInput : CustomerInput
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public override string Name { get; set; }

        /// <summary>
        /// 客户组织类型
        /// </summary>
        [Required(ErrorMessage = "客户组织类型不能为空")]
        public override Admin.NET.Application.CustomerTypeEnum CustomerType { get; set; }
    }

    public class DeleteCustomerInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
    }

    public class UpdateCustomerInput : CustomerInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
    }

    public class QueryeCustomerInput : DeleteCustomerInput
    {
    }
}