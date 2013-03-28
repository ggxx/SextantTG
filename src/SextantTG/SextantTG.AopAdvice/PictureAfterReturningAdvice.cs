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
    public class PictureAfterReturningAdvice : IAfterReturningAdvice
    {
        public void AfterReturning(object returnValue, MethodInfo method, object[] args, object target)
        {
            switch (method.Name)
            {
                case "InsertPicture":
                    LogHelper.Info(LogHelper.GetLogTimeString() + "用户上传了一张图片，" + (args[0] as Picture).ToString());
                    break;
                case "UpdatePicture":
                    LogHelper.Info(LogHelper.GetLogTimeString() + "用户更改了一张图片，" + (args[0] as Picture).ToString());
                    break;
                case "DeletePicture":
                    LogHelper.Info(LogHelper.GetLogTimeString() + "用户删除了一张图片，" + (args[0] as Picture).ToString());
                    break;
                default:
                    break;
            }
        }
    }
}
