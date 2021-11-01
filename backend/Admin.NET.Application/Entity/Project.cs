using System;
using System.ComponentModel.DataAnnotations.Schema;
using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;

namespace Admin.NET.Application
{
    [Table("Project")]
    [Comment("项目信息")]
    public class Project : DEntityBase 
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Comment("项目名称")]
        public string Name { get; set; }

        /// <summary>
        /// 项目类型
        /// </summary>
        [Comment("项目类型")]
        public string Types { get; set; }

        /// <summary>
        /// 负责人 (多对多)
        /// </summary>
        [Comment("负责人")]
        public string UserIds { get; set; }

        /// <summary>
        /// 支架型式
        /// </summary>
        [Comment("支架型式")]
        public string SupportType { get; set; }

        /// <summary>
        /// 支架型号
        /// </summary>
        [Comment("支架型号")]
        public string SupportModel { get; set; }

        /// <summary>
        /// 立项日期
        /// </summary>
        [Comment("立项日期")]
        public DateTimeOffset? ProjectDate { get; set; }

        /// <summary>
        /// 项目备注
        /// </summary>
        [Comment("项目备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 客户集团
        /// </summary>
        [Comment("客户集团")]
        public virtual Customer? CustomerGroup { get; set; }

        /// <summary>
        /// 客户集团编号
        /// </summary>
        [Comment("客户集团编号")]
        public long? CustomerGroupId { get; set; }

        /// <summary>
        /// 客户煤矿
        /// </summary>
        [Comment("客户煤矿")]
        public Customer CustomerMine { get; set; }

        /// <summary>
        /// 客户煤矿编号
        /// </summary>
        [Comment("客户煤矿编号")]
        public long? CustomerMineId { get; set; } 
    }
}