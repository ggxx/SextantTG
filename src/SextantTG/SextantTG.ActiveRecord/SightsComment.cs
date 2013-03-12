/*********************************************************
 * 
 *        Author: 郭旭
 * Last Modified: 2013-03-05
 *     File Name: Sights.cs
 *   Description: 景点评论实体类
 * 
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 景点评论
    /// </summary>
    public class SightsComment
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public string CommentId { get; set; }

        /// <summary>
        /// 评论人
        /// </summary>
        public string CommentUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }

        /// <summary>
        /// 景点ID
        /// </summary>
        public string SightsId { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public string Comment { get; set; }
    }
}
