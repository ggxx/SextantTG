/*********************************************************
 * 
 *        Author: 郭旭
 * Last Modified: 2013-03-05
 *     File Name: Sights.cs
 *   Description: 景点实体类
 * 
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Win.Models
{
    /// <summary>
    /// 景点实体类
    /// </summary>
    public class Sights
    {
        /// <summary>
        /// 景点ID
        /// </summary>
        public string SightsId { get; set; }
        
        /// <summary>
        /// 所属城市ID
        /// </summary>
        public string CityId { get; set; }

        /// <summary>
        /// 景点级别
        /// </summary>
        public string SightsLevel { get; set; }

        /// <summary>
        /// 景点介绍
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 门票价格
        /// </summary>
        public int? Price { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memos { get; set; }
    }
}
