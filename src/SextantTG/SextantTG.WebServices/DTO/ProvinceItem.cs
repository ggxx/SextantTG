using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class ProvinceItem : DTO
    {
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
    }
}