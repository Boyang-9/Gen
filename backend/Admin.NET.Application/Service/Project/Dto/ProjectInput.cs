using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 项目信息输入参数
    /// </summary>
    public class ProjectInput : PageInputBase
    {
        /// <summary>
        /// 负责人
        /// </summary>
        public virtual string UserIds { get; set; }
        
        /// <summary>
        /// 支架型式
        /// </summary>
        public virtual string SupportType { get; set; }
        
        /// <summary>
        /// 支架型号
        /// </summary>
        public virtual string SupportModel { get; set; }
        
        /// <summary>
        /// 立项日期
        /// </summary>
        public virtual DateTimeOffset? ProjectDate { get; set; }
        
        /// <summary>
        /// 项目备注
        /// </summary>
        public virtual string Remark { get; set; }
        
        /// <summary>
        /// 客户集团
        /// </summary>
        public virtual long? CustomerGroupId { get; set; }
        
        /// <summary>
        /// 客户煤矿
        /// </summary>
        public virtual long? CustomerMineId { get; set; }
        
        /// <summary>
        /// 项目名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 项目类型
        /// </summary>
        public virtual string Types { get; set; }
        
    }

    public class AddProjectInput : ProjectInput
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required(ErrorMessage = "项目名称不能为空")]
        public override string Name { get; set; }
        
        /// <summary>
        /// 项目类型
        /// </summary>
        [Required(ErrorMessage = "项目类型不能为空")]
        public override string Types { get; set; }
        
    }

    public class DeleteProjectInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateProjectInput : ProjectInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeProjectInput : DeleteProjectInput
    {

    }
}
