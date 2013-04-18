using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace SextantTG.ILogUtil
{
    public class LogFactory
    {
        private static readonly string LOG = ConfigurationManager.AppSettings["LOG"];
        private static readonly string LOG_HELPER = ConfigurationManager.AppSettings["LOG_HELPER"];

        public static ILogHelper CreateLogHelper()
        {
            return (ILogHelper)Assembly.Load(LOG).CreateInstance(LOG_HELPER);
        }
    }
}
