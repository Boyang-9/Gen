using System.Collections;
using System.Collections.Generic;
using Furion.Extras.Admin.NET;

namespace Admin.NET.Application
{
    /// <summary>
    /// 客户组织机构树
    /// </summary>
    public class CustomerTreeNode : ITreeNode
    {
        public long Id { get; set; }

        public long ParentId { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }

        public int Weight { get; set; }

        public List<CustomerTreeNode> Children { get; set; } = new List<CustomerTreeNode>();


        public long GetId()
        {
            return Id;
        }

        public long GetPid()
        {
            return ParentId;
        }

        public void SetChildren(IList children)
        {
            Children = (List<CustomerTreeNode>)children;
        }
    }
}