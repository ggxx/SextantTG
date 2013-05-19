using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class TourObject : DTO
    {
        public TourObject()
        {
            this.BlogItemList = new List<BlogItem>();
            this.CommentItemList = new List<CommentItem>();
            this.PictureItemList = new List<PictureItem>();
            this.SubtourItemList = new List<SubtourItem>();
        }

        public string TourId { get; set; }
        public string TourName { get; set; }
        public string Status { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Cost { get; set; }
        public string UserId { get; set; }
        public List<SubtourItem> SubtourItemList { get; set; }
        public List<PictureItem> PictureItemList { get; set; }
        public List<BlogItem> BlogItemList { get; set; }
        public List<CommentItem> CommentItemList { get; set; }
    }
}