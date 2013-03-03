using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    public class Tour
    {
        public string TourId { get; set; }
        public string TourName { get; set; }
        public string UserId { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndData { get; set; }
        public int? Cost { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatingTime { get; set; }
        public string Memos { get; set; }
    }
}
