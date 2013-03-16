using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 权限实体类
    /// </summary>
    public class Permission : BaseAR
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>
        public int? PermissionType { get; set; }
    }
}
