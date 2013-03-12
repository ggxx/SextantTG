using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SextantTG.ActiveRecord;

namespace SextantTG.Win
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button_Guest_Click(object sender, EventArgs e)
        {
            Config.AppConfig.User = null;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string loginName = this.textBox_LoginName.Text;
            string password = this.textBox_Password.Text;

            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("用户名和口令均不能为空", "提示");
                return;
            }

            Config.AppConfig.User = UIUtil.Login(loginName, password);
            if (Config.AppConfig.User != null)
            {
                if (Config.AppConfig.User.Status == 1)
                {
                    MessageBox.Show("该用户名已被禁止登录", "提示");
                    return;
                }

                Config.AppConfig.Permissions = UIUtil.GetPermissionsByUserId(Config.AppConfig.User.UserId);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或口令错误", "提示");
                return;
            }
        }

        private void button_Reg_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            using (RegForm form = new RegForm())
            {
                form.ShowDialog();
            }

            this.Visible = true;
        }
    }
}
