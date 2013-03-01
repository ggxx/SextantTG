using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Model.Entity
{
    /// <summary>
    /// 评论实体类
    /// </summary>
    public abstract class Comment
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public string CommentId { get; set; }

        /// <summary>
        /// 评论人
        /// </summary>
        public User CommentUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }
    }
}
