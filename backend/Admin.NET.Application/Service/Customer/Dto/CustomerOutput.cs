using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 客户组织机构表输出参数
    /// </summary>
    public class CustomerOutput
    {
        /// <summary>
        /// 父Id
        /// </summary>
        public long Pid { get; set; }
        
        /// <summary>
        /// 父Ids
        /// </summary>
        public string Pids { get; set; }
        
        /// <summary>
        /// 煤矿所属集团
        /// </summary>
        public long MineGroupId { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 客户组织类型
        /// </summary>
        public Admin.NET.Application.CustomerTypeEnum CustomerType { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        
        /// <summary>
        /// GPS
        /// </summary>
        public string Gps { get; set; }
        
        /// <summary>
        /// Id主键
        /// </summary>
        public long Id { get; set; }
        
    }
}
