/*********************************************************
 * 
 *        Author: 郭旭
 * Last Modified: 2013-03-05
 *     File Name: Blog.cs
 *   Description: 日志记录的实体类
 * 
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Model
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        public string BlogId { get; set; }

        /// <summary>
        /// 日志创建者ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 日志相关的景点ID
        /// </summary>
        public string SightsId { get; set; }

        /// <summary>
        /// 日志相关的旅行
        /// </summary>
        public string TourId { get; set; }

        /// <summary>
        /// 日志相关的子旅行ID
        /// </summary>
        public string SubTourId { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }
    }
}
