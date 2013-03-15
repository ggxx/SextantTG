using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SextantTG.Win
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //检测数据库文件
            //if (!System.IO.File.Exists(string.Empty)) { }

            //登录
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //启动主界面
            Application.Run(new MainForm());
        }
    }
}
