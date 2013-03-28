using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Diagnostics;

namespace SextantTG.Util
{
    /// <summary>
    /// 使用单件模式的日志
    /// </summary>
    public sealed class LogHelper 
    {
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private static readonly ILog log = LogManager.GetLogger((new StackTrace()).GetFrame(2).GetMethod().DeclaringType);
        private readonly static ILog log = log4net.LogManager.GetLogger("SextantTG Logger");

        private LogHelper()
        {
            //log4net.Config.XmlConfigurator.Configure();
        }


        public static void Debug(object obj, Exception ex)
        {
            if (log.IsDebugEnabled)
                log.Debug(obj, ex);
        }

        public static void Debug(object obj)
        {
            if (log.IsDebugEnabled)
                log.Debug(obj);
        }

        public static void Error(object obj, Exception ex)
        {
            if (log.IsErrorEnabled)
                log.Error(obj, ex);
        }

        public static void Error(object obj)
        {
            if (log.IsErrorEnabled)
                log.Error(obj);
        }

        public static void Fatal(object obj, Exception ex)
        {
            if (log.IsFatalEnabled)
                log.Fatal(obj, ex);
        }

        public static void Fatal(object obj)
        {
            if (log.IsFatalEnabled)
                log.Fatal(obj);
        }

        public static void Info(object obj, Exception ex)
        {
            if (log.IsInfoEnabled)
                log.Info(obj, ex);
        }

        public static void Info(object obj)
        {
            if (log.IsInfoEnabled)
                log.Info(obj);
        }

        public static void Warn(object obj, Exception ex)
        {
            if (log.IsWarnEnabled)
                log.Warn(obj, ex);
        }

        public static void Warn(object obj)
        {
            if (log.IsWarnEnabled)
                log.Warn(obj);
        }

        public static string GetLogTimeString()
        {
            return DateTime.Now.ToString("在yyyy年MM月dd日HH时mm分ss秒，");
        }
    }
}
