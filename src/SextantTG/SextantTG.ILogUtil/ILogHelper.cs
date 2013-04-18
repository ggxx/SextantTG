using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.ILogUtil
{
    public interface ILogHelper
    {
        void Debug(object obj, Exception ex);

        void Debug(object obj);

        void Error(object obj, Exception ex);

        void Error(object obj);

        void Fatal(object obj, Exception ex);

        void Fatal(object obj);

        void Info(object obj, Exception ex);

        void Info(object obj);

        void Warn(object obj, Exception ex);

        void Warn(object obj);

        string GetLogTimeString();
    }
}
