using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Aop;
using System.Reflection;
using SextantTG.ActiveRecord;
using SextantTG.Util;

namespace SextantTG.AopAdvice
{
    public class SightsAfterReturningAdvice : IAfterReturningAdvice
    {
        public void AfterReturning(object returnValue, MethodInfo method, object[] args, object target)
        {
            switch (method.Name)
            {
                case "InsertSights":
                    LogHelper.Info(LogHelper.GetLogTimeString() + "用户新增了一个景点，" + (args[0] as Sights).ToString());
                    break;
                case "UpdateSightsFromOld":
                    LogHelper.Info(LogHelper.GetLogTimeString() + "用户更改了一个景点，原景点是" + (args[1] as Sights).ToString() + "。新景点是" + (args[0] as Sights).ToString());
                    break;
                case "DeleteSights":
                    LogHelper.Info(LogHelper.GetLogTimeString() + "用户删除了一个景点，" + (args[0] as Sights).ToString());
                    break;
                default:
                    break;
            }

            //string message = "";
            //if (method.Name == "InsertSights")
            //{
            //    if (args != null)
            //    {
            //        message = LogHelper.GetLogTimeString() + "增加景点:";
            //        Sights sig = args[0] as Sights;
            //        if (sig != null)
            //        {
            //            message += "景点ID:" + sig.SightsId + "，景点名称：" + sig.SightsName;
            //            LogHelper.Info(message);
            //        }
            //    }
            //}
            //else if (method.Name == "UpdateSightsFromOld")
            //{
            //    message = LogHelper.GetLogTimeString() + "修改景点:";

            //    if (args != null)
            //    {
            //        Sights sig = (Sights)args[0];
            //        message += "景点ID:" + sig.SightsId + "，景点名称：" + sig.SightsName;
            //        LogHelper.Info(message);

            //        List<Picture> currentPic = (List<Picture>)args[1];
            //        List<Picture> removedPic = (List<Picture>)args[2];

            //        Sights beforeSights = (Sights)args[3];
            //        //获取景点修改前的信息并比较输出
            //        if (beforeSights != null )
            //        {
            //            if (beforeSights.SightsId == sig.SightsId)
            //            {
            //                string modifyMessage = "                             修改内容：";
            //                if (beforeSights.SightsName != sig.SightsName)
            //                    modifyMessage += "景点名称从" + beforeSights.SightsName + "变为->" + sig.SightsName + "；" ;
            //                if(beforeSights.SightsLevel != sig.SightsLevel)
            //                    modifyMessage += " 景点级别从" + beforeSights.SightsLevel + "变为->" + sig.SightsLevel + "；";
            //                if (beforeSights.Price != sig.Price)
            //                    modifyMessage += " 景点价格从" + beforeSights.Price + "变为->" + sig.Price + "；";
            //                if (beforeSights.Description != sig.Description)
            //                    modifyMessage += " 景点介绍变为->" + sig.Description + "；";

            //                if (currentPic != null)
            //                {
            //                    foreach (Picture pic in currentPic)
            //                    {
            //                        modifyMessage += "景点照片：" + pic.Description;
            //                    }
            //                }
            //                if (removedPic != null)
            //                {
            //                    foreach (Picture pic in removedPic)
            //                    {
            //                        modifyMessage += "删除照片：" + pic.Description;
            //                    }
            //                }
            //                LogHelper.Info(modifyMessage);
            //            }
            //        }
            //    }
            //}
            //else if (method.Name == "DeleteSightsBySightsId")
            //{
            //    message = LogHelper.GetLogTimeString() + "删除景点:";

            //    if (args != null)
            //    {
            //        string sigId = (string)args[0];
            //        //message += sightsDal.GetSightBySightsId(sigId).SightsName;
            //    }

            //    LogHelper.Info(message);
            //}

        }
    }
}
