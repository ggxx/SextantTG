using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Model.Entity
{
    /// <summary>
    /// 用户收藏实体类
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 景点ID
        /// </summary>
        public Sights Sights { get; set; }

        /// <summary>
        /// 是否游览过
        /// </summary>
        public bool HasVisited { get; set; }

        /// <summary>
        /// 评分0-10
        /// </summary>
        public int? Stars { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }
    }
}
