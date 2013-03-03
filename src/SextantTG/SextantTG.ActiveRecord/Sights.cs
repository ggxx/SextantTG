using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 景点实体类
    /// </summary>
    public class Sights
    {
        public string SightsId { get; set; }
        public string CityId { get; set; }
        public string SightsLevel { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public DateTime? CreatingTime { get; set; }
        public string Memos { get; set; }
    }
}
