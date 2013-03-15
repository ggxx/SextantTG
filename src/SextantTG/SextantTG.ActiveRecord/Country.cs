using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 国家
    /// </summary>
    public class Country
    {
        /// <summary>
        /// 国家ID
        /// </summary>
        [DisplayName("国家ID")]
        public string CountryId { get; set; }
        
        /// <summary>
        /// 国家名称
        /// </summary>
        [DisplayName("国家名称")]
        public string CountryName { get; set; }
    }
}
