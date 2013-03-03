using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    public class SubTour
    {
        public string TourId { get; set; }
        public string SubTourId { get; set; }
        public string SubTourName { get; set; }
        public string SightsId { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndData { get; set; }
        public DateTime? CreatingTime { get; set; }
        public string Memos { get; set; }

    }
}
