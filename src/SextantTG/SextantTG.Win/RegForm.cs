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
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string loginName = textBox_LoginName.Text;
            string email = textBox_Email.Text.Trim();
            string password = textBox_Password.Text;
            string password2 = textBox_Password2.Text;
            string msg;

            // 口令相同
            if (!password.Equals(password2))
            {
                MessageBox.Show("两次输入的口令不一致", "提示");
                return;
            }

            // 非空
            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("用户信息不能为空", "提示");
                return;
            }

            // 唯一
            if (UIUtil.GetUserByLoginName(loginName) != null)
            {
                MessageBox.Show("用户名已被使用", "提示");
                return;
            }
            if (UIUtil.GetUserByEmail(email) != null)
            {
                MessageBox.Show("Email地址已被使用", "提示");
                return;
            }

            User user = new User();
            user.Email = email;
            user.LoginName = loginName;
            user.Status = 0;
            if (UIUtil.InsertUser(user, password, out msg))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败\r\n" + msg, "提示");
                return;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
