/*********************************************************
 * 
 *        Author: 郭旭
 * Last Modified: 2013-03-05
 *     File Name: Country.cs
 *   Description: 国家字典
 * 
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Model
{
    /// <summary>
    /// 国家
    /// </summary>
    public class Country
    {
        /// <summary>
        /// 国家ID
        /// </summary>
        public string CountryId { get; set; }
        
        /// <summary>
        /// 国家名称
        /// </summary>
        public string CountryName { get; set; }
    }
}
