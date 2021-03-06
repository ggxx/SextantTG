﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SextantTG.WebServices.DTO
{
    public class SubtourItem : DTO
    {        
        /// <summary>
        /// 所属旅行ID
        /// </summary>
        public string TourId { get; set; }

        /// <summary>
        /// 子旅行ID
        /// </summary>
        public string SubtourId { get; set; }

        /// <summary>
        /// 子旅行名称
        /// </summary>
        public string SubtourName { get; set; }

        /// <summary>
        /// 相关景点ID
        /// </summary>
        public string SightId { get; set; }

        /// <summary>
        /// 相关景点
        /// </summary>
        public string SightName { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}