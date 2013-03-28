using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace SextantTG.AopAdvice
{
    class UserLog 
    {
        private ILog log;

        public UserLog()
        {
            log = log4net.LogManager.GetLogger("SextantTG Logger");
        }

        public void WriteLog(string message)
        {
            //if (log.IsDebugEnabled)
            //    log.Debug(message);
            //else if (log.IsErrorEnabled)
            //    log.Error(message);
            //else if (log.IsFatalEnabled)
            //    log.Fatal(message);
            //else 
            log.Info(message);
        }
    }
}
