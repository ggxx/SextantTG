using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 图片评论实体类
    /// </summary>
    public class PictureComment : BaseAR
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
        /// 图片ID
        /// </summary>
        public string PictureId { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public string Comment { get; set; }
    }
}
