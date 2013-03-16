using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 用户评论实体类
    /// </summary>
    public class UserComment : BaseAR
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
        /// 被评论人ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public string Comment { get; set; }
    }
}
