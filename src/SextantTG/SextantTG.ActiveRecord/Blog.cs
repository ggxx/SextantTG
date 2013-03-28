using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class Blog : BaseAR
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
        /// 日志标题
        /// </summary>
        public string Title { get; set; }

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
