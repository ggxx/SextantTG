using AopAlliance.Intercept;
using SextantTG.ActiveRecord;
using SextantTG.Util;
using Spring.Aop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SextantTG.AopAdvice
{
    public class SubTourAfterReturningAdvice : IAfterReturningAdvice
    {
        private ILogUtil.ILogHelper logHelper = ILogUtil.LogFactory.CreateLogHelper();

        public void AfterReturning(object returnValue, MethodInfo method, object[] args, object target)
        {
            switch (method.Name)
            {
                case "InsertSubTour":
                    logHelper.Info(logHelper.GetLogTimeString() + "用户在旅行计划中增加了一个景点，" + (args[0] as SubTour).ToString());
                    break;
                case "UpdateSubTourFromOld":
                    logHelper.Info(logHelper.GetLogTimeString() + "用户在旅行计划中修改了一个景点，原景点是" + (args[1] as SubTour).ToString() + "。新景点是" + (args[0] as SubTour).ToString());
                    break;
                case "DeleteSubTour":
                    logHelper.Info(logHelper.GetLogTimeString() + "用户在旅行计划中删除了一个景点，" + (args[0] as SubTour).ToString());
                    break;
                default:
                    break;
            }
        }
    }
}
