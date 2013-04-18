using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ILogUtil;
using log4net;

namespace SextantTG.Log4Net
{
    public class LogHelper : ILogHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger("SextantTG Logger");

        public LogHelper()
        {
            //log4net.Config.XmlConfigurator.Configure();
        }


        public void Debug(object obj, Exception ex)
        {
            if (log.IsDebugEnabled)
                log.Debug(obj, ex);
        }

        public void Debug(object obj)
        {
            if (log.IsDebugEnabled)
                log.Debug(obj);
        }

        public void Error(object obj, Exception ex)
        {
            if (log.IsErrorEnabled)
                log.Error(obj, ex);
        }

        public void Error(object obj)
        {
            if (log.IsErrorEnabled)
                log.Error(obj);
        }

        public void Fatal(object obj, Exception ex)
        {
            if (log.IsFatalEnabled)
                log.Fatal(obj, ex);
        }

        public void Fatal(object obj)
        {
            if (log.IsFatalEnabled)
                log.Fatal(obj);
        }

        public void Info(object obj, Exception ex)
        {
            if (log.IsInfoEnabled)
                log.Info(obj, ex);
        }

        public void Info(object obj)
        {
            if (log.IsInfoEnabled)
                log.Info(obj);
        }

        public void Warn(object obj, Exception ex)
        {
            if (log.IsWarnEnabled)
                log.Warn(obj, ex);
        }

        public void Warn(object obj)
        {
            if (log.IsWarnEnabled)
                log.Warn(obj);
        }

        public string GetLogTimeString()
        {
            return DateTime.Now.ToString("在yyyy年MM月dd日HH时mm分ss秒，");
        }
    }
}
