using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Aop;
using System.Reflection;
using SextantTG.ActiveRecord;
using SextantTG.Util;
using AopAlliance.Intercept;

namespace SextantTG.AopAdvice
{
    public class TourAfterReturningAdvice : IAfterReturningAdvice
    {
        private ILogUtil.ILogHelper logHelper = ILogUtil.LogFactory.CreateLogHelper();

        public void AfterReturning(object returnValue, MethodInfo method, object[] args, object target)
        {
            switch (method.Name)
            {
                case "InsertTour":
                    logHelper.Info(logHelper.GetLogTimeString() + "用户增加了一次旅行计划，" + (args[0] as Tour).ToString());
                    break;
                case "UpdateTourFromOld":
                    logHelper.Info(logHelper.GetLogTimeString() + "用户修改了一次旅行计划，原旅行是" + (args[1] as Tour).ToString() + "。新旅行是" + (args[0] as Tour).ToString());
                    break;
                case "DeleteTour":
                    logHelper.Info(logHelper.GetLogTimeString() + "用户删除了一次旅行计划，" + (args[0] as Tour).ToString());
                    break;
                default:
                    break;
            }






            //string message = "";

            //if (method.Name == "SaveTour" || method.Name == "InsertTour")
            //{
            //    if (args != null)
            //    {
            //        Tour tour = (Tour)args[0];
            //        List<SubTour> addSubTourList = (List<SubTour>)args[1];
            //        List<SubTour> delSubTourList = (List<SubTour>)args[2];
            //        Tour oldtour = (Tour)args[3];
            //        if (oldtour != null)
            //        {
            //            message += LogHelper.GetLogTimeString() + "修改旅行计划:" + "旅行Id:" + "，旅行名称：" + tour.TourName;
            //            LogHelper.Info(message);

            //            if (oldtour.TourId == tour.TourId)
            //            {
            //                string modifyMessage = "                             修改内容：";
            //                if (oldtour.TourName != tour.TourName)
            //                    modifyMessage += "旅行名称从" + oldtour.TourName + "变为->" + tour.TourName + "；";
            //                if (oldtour.BeginDate != tour.BeginDate)
            //                    modifyMessage += "旅行开始时间从" + oldtour.BeginDate + "变为->" + tour.BeginDate + "；";
            //                if (oldtour.EndDate != tour.EndDate)
            //                    modifyMessage += "旅行结束时间从" + oldtour.EndDate + "变为->" + tour.EndDate + "；";
            //                if (oldtour.Cost != tour.Cost)
            //                    modifyMessage += "旅行花费从" + oldtour.Cost + "变为->" + tour.Cost + "；";
            //                if (oldtour.Status != tour.Status)
            //                    modifyMessage += "旅行状态从" + oldtour.Status + "变为->" + tour.Status + "；";
            //                if (oldtour.UserId != tour.UserId)
            //                    modifyMessage += "旅行者从" + oldtour.UserId + "变为->" + tour.UserId + "；";

            //                if (addSubTourList != null)
            //                {
            //                    foreach (SubTour stour in addSubTourList)
            //                    {
            //                        modifyMessage += "当前旅行计划景点：" + stour.SubTourName + ";";
            //                    }
            //                }
            //                if (delSubTourList != null)
            //                {
            //                    foreach (SubTour stour in delSubTourList)
            //                    {
            //                        modifyMessage += "删除旅行计划景点：" + stour.SubTourName + ";";
            //                    }
            //                }
            //                LogHelper.Info(modifyMessage);
            //            }
            //        }
            //        else
            //        {
            //            message += LogHelper.GetLogTimeString() + "新增旅行计划：" + "旅行Id:" + "，旅行名称：" + tour.TourName;
            //            LogHelper.Info(message);
            //        }
            //    }
            //    else if (method.Name == "DeleteTourByTourId")
            //    {
            //        message = LogHelper.GetLogTimeString() + "删除旅行计划:";

            //        if (args != null)
            //        {
            //            string tourId = (string)args[0];
            //            message += "旅行ID:" + tourId;
            //        }
            //        LogHelper.Info(message);
            //    }
            //}
        }

    }
}
