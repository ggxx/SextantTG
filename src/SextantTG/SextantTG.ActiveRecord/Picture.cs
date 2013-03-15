using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 图片实体类
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public string PictureId { get; set; }

        /// <summary>
        /// 景点ID
        /// </summary>
        public string SightsId { get; set; }

        /// <summary>
        /// 日志ID（可为空）
        /// </summary>
        public string BlogId { get; set; }

        /// <summary>
        /// 图片存储的相对路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 图片描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 上传人
        /// </summary>
        public string UploaderId { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }
    }
}
