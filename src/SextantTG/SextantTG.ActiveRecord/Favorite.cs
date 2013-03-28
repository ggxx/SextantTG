using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 用户收藏实体类
    /// </summary>
    public class Favorite : BaseAR
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 景点ID
        /// </summary>
        public string SightsId { get; set; }

        /// <summary>
        /// 是否游览过
        /// </summary>
        public int? Visited { get; set; }

        /// <summary>
        /// 评分0-10
        /// </summary>
        public int? Stars { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }

        public override string ToString()
        {
            return string.Format("用户ID:{0}, 景点ID:{1}, 是否游览过:{2}, 评分:{3}", UserId, SightsId, Visited == 1 ? "是" : "否", Stars);
        }
    }
}
