﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class PictureObject : DTO
    {
        public PictureObject()
        {
            this.CommentItemList = new List<CommentItem>();
        }

        /// <summary>
        /// 图片ID
        /// </summary>
        public string PictureId { get; set; }

        /// <summary>
        /// 景点
        /// </summary>
        public string SightName { get; set; }

        /// <summary>
        /// 旅行（可为空）
        /// </summary>
        public string TourName { get; set; }

        /// <summary>
        /// 子旅行（可为空）
        /// </summary>
        public string SubTourName { get; set; }

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

        public String TourId { get; set; }

        public String SubtourId { get; set; }

        List<CommentItem> CommentItemList { get; set; } 
    }
}