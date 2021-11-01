using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 项目信息输出参数
    /// </summary>
    public class ProjectOutput
    {
        /// <summary>
        /// 负责人
        /// </summary>
        public string UserIds { get; set; }
        
        /// <summary>
        /// 支架型式
        /// </summary>
        public string SupportType { get; set; }
        
        /// <summary>
        /// 支架型号
        /// </summary>
        public string SupportModel { get; set; }
        
        /// <summary>
        /// 立项日期
        /// </summary>
        public DateTimeOffset ProjectDate { get; set; }
        
        /// <summary>
        /// 项目备注
        /// </summary>
        public string Remark { get; set; }
        
        /// <summary>
        /// 客户集团
        /// </summary>
        public long CustomerGroupId { get; set; }
        
        /// <summary>
        /// 客户煤矿
        /// </summary>
        public long CustomerMineId { get; set; }
        
        /// <summary>
        /// Id主键
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 项目类型
        /// </summary>
        public string Types { get; set; }
        
    }
}
