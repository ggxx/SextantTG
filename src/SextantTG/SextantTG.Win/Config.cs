using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.Win
{
    internal sealed class Config
    {
        public string User { get; set; }

        //以下代码实现单件模式Singleton
        private Config() { }
        internal static readonly Config AppConfig = new Config();
    }
}
