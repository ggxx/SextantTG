using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class BlogItem : DTO
    {
        public string BlogId { get; set; }
        public string Anthor { get; set; }
        public string Title { get; set; }
        public string SightName { get; set; }
        public string TourName { get; set; }
        public string SubtourName { get; set; }
        public string Content { get; set; }
        public DateTime CreatingTime { get; set; }
    }
}
