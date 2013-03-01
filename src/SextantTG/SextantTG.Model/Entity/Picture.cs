using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Model.Entity
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
        /// 景点
        /// </summary>
        public Sights Sights { get; set; }

        /// <summary>
        /// 日志（可为空）
        /// </summary>
        public Blog Blog { get; set; }

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
        public User Uploader { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }

    }
}
