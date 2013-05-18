using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class SightObject : DTO
    {
        public SightObject()
        {
            this.BlogItemList = new List<BlogItem>();
            this.CommentItemList = new List<CommentItem>();
            this.PictureItemList = new List<PictureItem>();
        }

        /// <summary>
        /// 景点ID
        /// </summary>
        public string SightId { get; set; }

        /// <summary>
        /// 景点名称
        /// </summary>
        public string SightName { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// 景点级别
        /// </summary>
        public string SightLevel { get; set; }

        /// <summary>
        /// 是否游览过
        /// </summary>
        public bool HasVisited { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public float Stars { get; set; }

        /// <summary>
        /// 评分
        /// </summary>
        public int MyStar { get; set; }

        /// <summary>
        /// 景点介绍
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 门票价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public List<PictureItem> PictureItemList { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public List<CommentItem> CommentItemList { get; set; }

        /// <summary>
        /// 日志
        /// </summary>
        public List<BlogItem> BlogItemList { get; set; }


    }
}