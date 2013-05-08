using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class PictureItem : DTO
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public string PictureId { get; set; }

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
        public string UploaderName { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }
    }
}