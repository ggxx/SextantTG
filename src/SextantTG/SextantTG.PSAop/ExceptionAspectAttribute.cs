using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Constraints;

namespace SextantTG.PSAop
{
    [Serializable]
    public class ExceptionAspectAttribute : OnExceptionAspect
    {
        private ILogUtil.ILogHelper logHelper = null;

        public override void OnException(MethodExecutionArgs args)
        {
            if (logHelper == null)
            {
                logHelper = ILogUtil.LogFactory.CreateLogHelper();
            }
            if (args.Instance != null)
            {
                string errorMsg = logHelper.GetLogTimeString() + args.Instance.ToString() + "类的" + args.Method.Name + "方法" + "发生异常,异常信息为：" + args.Exception.Message;
                logHelper.Error(errorMsg);
            }
            else
            {
                string errorMsg = logHelper.GetLogTimeString() + args.Method.Name + "方法" + "发生异常,异常信息为：" + args.Exception.Message;
                logHelper.Error(errorMsg);
            }
            base.OnException(args);
        }
    }
}
