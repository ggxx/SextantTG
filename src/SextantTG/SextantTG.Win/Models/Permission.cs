/*********************************************************
 * 
 *        Author: 郭旭
 * Last Modified: 2013-03-05
 *     File Name: Permission.cs
 *   Description: 用户权限实体类
 * 
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Win.Models
{
    /// <summary>
    /// 权限实体类
    /// </summary>
    public class Permission
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
