using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 省份
    /// </summary>
    public class Province
    {
        /// <summary>
        /// 省份ID
        /// </summary>
        public string ProvinceId { get; set; }
        
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
        
        /// <summary>
        /// 所属国家ID
        /// </summary>
        public string CountryId { get; set; }
    }
}
