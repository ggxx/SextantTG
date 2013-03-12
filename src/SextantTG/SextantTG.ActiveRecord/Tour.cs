/*********************************************************
 * 
 *        Author: 郭旭
 * Last Modified: 2013-03-05
 *     File Name: Tour.cs
 *   Description: 旅行实体类。
 * 
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ActiveRecord
{
    /// <summary>
    /// 旅行实体类
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// 旅行ID
        /// </summary>
        public string TourId { get; set; }

        /// <summary>
        /// 旅行名称
        /// </summary>
        public string TourName { get; set; }

        /// <summary>
        /// 相关的用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public int? Cost { get; set; }

        /// <summary>
        /// 旅行状态
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatingTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memos { get; set; }
    }
}
