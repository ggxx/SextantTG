using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class CommentItem : DTO
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public string CommentId { get; set; }

        /// <summary>
        /// 评论人
        /// </summary>
        public string CommentUserName { get; set; }

        public string UserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatingTime { get; set; }

        /// <summary>
        /// 被评论ID
        /// </summary>
        public string TargetId { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public string Comment { get; set; }
    }
}