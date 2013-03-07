/*********************************************************
 * 
 *        Author: 郭旭
 * Last Modified: 2013-03-05
 *     File Name: City.cs
 *   Description: 城市字典
 * 
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Win.Models
{
    /// <summary>
    /// 城市
    /// </summary>
    public class City
    {
        /// <summary>
        /// 城市ID
        /// </summary>
        public string CityId { get; set; }
        
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        
        /// <summary>
        /// 所属省份ID
        /// </summary>
        public string ProvinceId { get; set; }
    }
}
