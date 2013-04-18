using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Constraints;

namespace SextantTG.PSAop
{
    [Serializable]
    public class MethodAspectAttribute : OnMethodBoundaryAspect
    {
        private ILogUtil.ILogHelper logHelper = null;

        public override void OnEntry(MethodExecutionArgs args)
        {
            InitLogHelper();

            if (args.Instance != null)
            {
                logHelper.Info(string.Format("{0} 类{1}开始执行{2}操作", logHelper.GetLogTimeString(), args.Instance.ToString(), args.Method.Name));
            }
            else
            {
                logHelper.Info(string.Format("{0} 开始执行{1}操作", logHelper.GetLogTimeString(), args.Method.Name));
            }
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            InitLogHelper();

            if (args.Instance != null)
            {
                logHelper.Info(string.Format("{0} 类{1}结束执行{2}操作", logHelper.GetLogTimeString(), args.Instance.ToString(), args.Method.Name));
            }
            else
            {
                logHelper.Info(string.Format("{0} 开始执行{1}操作", logHelper.GetLogTimeString(), args.Method.Name));
            }
            base.OnExit(args);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            InitLogHelper();

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

        private void InitLogHelper()
        {
            if (logHelper == null)
            {
                logHelper = ILogUtil.LogFactory.CreateLogHelper();
            }
        }
    }
}
