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
        public string UserId { get; set; }
        public string TourId { get; set; }
        public string SubtourId { get; set; }
        public string SightId { get; set; }
        public bool IsSync { get; set; }
    }
}
