using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class BlogObject : DTO
    {
        public BlogObject()
        {
            this.CommentItemList = new List<CommentItem>();
        }

        public string BlogId { get; set; }
        public string Anthor { get; set; }
        public string SightName { get; set; }
        public string TourName { get; set; }
        public string SubtourName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatingTime { get; set; }
        List<CommentItem> CommentItemList { get; set; }
    }
}