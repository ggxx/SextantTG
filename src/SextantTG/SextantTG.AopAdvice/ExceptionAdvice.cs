using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Aop;
using System.Reflection;
using SextantTG.Util;

namespace SextantTG.AopAdvice
{
    /// <summary>
    /// 异常通知
    /// </summary>
    public class ExceptionAdvice : IThrowsAdvice
    {
        private ILogUtil.ILogHelper logHelper = ILogUtil.LogFactory.CreateLogHelper();

        public void AfterThrowing(MethodInfo method, object[] args, object target, Exception ex)
        {
            string errorMsg = logHelper.GetLogTimeString() + target + "类的" + method + "方法" + "发生异常,异常信息为：" + ex.Message;
            logHelper.Error(errorMsg);
        }
    }
}
