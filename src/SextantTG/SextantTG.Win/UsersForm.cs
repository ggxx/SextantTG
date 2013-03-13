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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.bindingSource.DataSource = UIUtil.GetUsers();
        }

        private void button_Blacklist_Click(object sender, EventArgs e)
        {
            User user = this.bindingSource.Current as User;
            if (user != null)
            {
                if (user.Status != 1)
                {
                    string msg;
                    user.Status = 1;
                    if (!UIUtil.UpdateUser(user, out msg))
                    {
                        MessageBox.Show("操作失败\r\n" + msg, "提示");
                        return;
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
        }

        private void button_Revert_Click(object sender, EventArgs e)
        {
            User user = this.bindingSource.Current as User;
            if (user != null)
            {
                if (user.Status != 0)
                {
                    string msg;
                    user.Status = 0;
                    if (!UIUtil.UpdateUser(user, out msg))
                    {
                        MessageBox.Show("操作失败\r\n" + msg, "提示");
                        return;
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
        }

        private void button_Permission_Click(object sender, EventArgs e)
        {
            User user = this.bindingSource.Current as User;
            if (user != null)
            {
                using (UserPermissionForm form = new UserPermissionForm())
                {
                    form.SetUser(user.UserId);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }


    }
}
