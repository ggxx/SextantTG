using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class SightItem : DTO
    {
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
    }
}