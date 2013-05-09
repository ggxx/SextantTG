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
            this.BlogList = new List<BlogItem>();
            this.CommentList = new List<CommentItem>();
            this.PictureList = new List<PictureItem>();
            this.SubtourList = new List<SubtourItem>();
        }

        public string TourId { get; set; }
        public string TourName { get; set; }
        public string Status { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Cost { get; set; }
        public List<SubtourItem> SubtourList { get; set; }
        public List<PictureItem> PictureList { get; set; }
        public List<BlogItem> BlogList { get; set; }
        public List<CommentItem> CommentList { get; set; }
    }
}