using System.ComponentModel;

namespace Admin.NET.Application
{
    /// <summary>
    /// 客户机构类型
    /// </summary>
    public enum CustomerTypeEnum
    {
        /// <summary>
        /// 集团
        /// </summary>
        [Description("集团")]
        GROUP = 1,
        
        /// <summary>
        /// 公司
        /// </summary>
        [Description("公司")]
        COMPANY = 2,
        
        /// <summary>
        /// 煤矿
        /// </summary>
        [Description("煤矿")]
        MINE = 3
    }
}