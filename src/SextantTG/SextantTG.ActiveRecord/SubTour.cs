/*********************************************************
 * 
 *        Author: 郭旭
 * Last Modified: 2013-03-05
 *     File Name: SubTour.cs
 *   Description: 子旅行实体类。对于一次旅行而言，可能游览多个景点，
 *                每个景点的游览称为一个子旅行。
 * 
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 子旅行实体类
    /// </summary>
    public class SubTour
    {
        /// <summary>
        /// 所属旅行ID
        /// </summary>
        public string TourId { get; set; }
        
        /// <summary>
        /// 子旅行ID
        /// </summary>
        public string SubTourId { get; set; }

        /// <summary>
        /// 子旅行名称
        /// </summary>
        public string SubTourName { get; set; }

        /// <summary>
        /// 相关景点ID
        /// </summary>
        public string SightsId { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreatingTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memos { get; set; }

    }
}
