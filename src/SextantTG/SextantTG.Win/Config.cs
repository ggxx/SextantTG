using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.Win
{
    internal sealed class Config
    {
        public User User { get; set; }
        public List<Permission> Permissions { get; set; } 

        //以下代码实现单件模式Singleton
        private Config() { }
        internal static readonly Config AppConfig = new Config();
    }
}
