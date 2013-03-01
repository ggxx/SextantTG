using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Model.Entity
{
    /// <summary>
    /// 日志实体类
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        public string BlogId { get; set; }

        /// <summary>
        /// 日志创建者
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 日志相关的景点
        /// </summary>
        public Sights Sights { get; set; }

        /// <summary>
        /// 日志相关的旅行
        /// </summary>
        public Tour Tour { get; set; }

        /// <summary>
        /// 日志相关的子旅行
        /// </summary>
        public SubTour SubTour { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }

        /// <summary>
        /// 对该日志的评价列表
        /// </summary>
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// 日志包含的图片列表
        /// </summary>
        public List<Picture> Pictures { get; set; }
    }
}
