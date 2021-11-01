using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;

namespace Admin.NET.Application
{
    /// <summary>
    /// 客户组织机构表
    /// </summary>
    [Table("Customer")]
    [Comment("客户组织机构表")]
    public class Customer : DEntityBase
    {
        /// <summary>
        /// 父Id
        /// </summary>
        [Comment("父Id")]
        public long Pid { get; set; }

        /// <summary>
        /// 父Ids
        /// </summary>
        [Comment("父Ids")]
        public string Pids { get; set; }

        /// <summary>
        /// 煤矿所属集团
        /// </summary>
        [Comment("煤矿所属集团")]
        public long MineGroupId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Comment("名称")]
        [Required, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 客户组织类型（1:集团，2:公司，3:煤矿）
        /// </summary>
        [Comment("客户组织类型")]
        public CustomerTypeEnum CustomerType { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        public int Sort { get; set; }
        
        /// <summary>
        /// GPS
        /// </summary>
        [Comment("GPS")]
        public string Gps { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        [MaxLength(100)]
        public string Remark { get; set; }
    }
}