using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.DomainModel
{
    public class SightsComment : Comment
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


        public string SightsId { get; set; }
    }
}
