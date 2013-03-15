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
    public partial class UserPermissionForm : Form
    {
        private string userId = string.Empty;
        

        public UserPermissionForm()
        {
            InitializeComponent();
        }

        public void SetUser(string userId)
        {
            this.userId = userId;
            List<Permission> permissions = UIUtil.GetPermissionsByUserId(userId);
            Dictionary<int, string> all = UIUtil.GetPermissionsDict();

            foreach (KeyValuePair<int, string> p in all)
            {
                this.listBox_All.Items.Add(p.Value);
            }

            foreach (Permission p in permissions)
            {
                string v;
                if (all.TryGetValue(p.PermissionType.Value, out v))
                {
                    this.listBox_Current.Items.Add(v);
                    this.listBox_All.Items.Remove(v);
                }
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            foreach (object item in this.listBox_All.SelectedItems)
            {
                selectedItems.Add(item.ToString());
                this.listBox_Current.Items.Add(item);
            }
            foreach (string item in selectedItems)
            {
                this.listBox_All.Items.Remove(item);
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            foreach (object item in this.listBox_Current.SelectedItems)
            {
                selectedItems.Add(item.ToString());
                this.listBox_All.Items.Add(item);
            }
            foreach (string item in selectedItems)
            {
                this.listBox_Current.Items.Remove(item);
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> all = UIUtil.GetPermissionsDict();
            List<Permission> list = new List<Permission>();
            foreach (object item in this.listBox_Current.Items)
            {
                foreach (KeyValuePair<int, string> k in all)
                {
                    if (k.Value.Equals(item.ToString()))
                    {
                        Permission p = new Permission();
                        p.UserId = this.userId;
                        p.PermissionType = k.Key;
                        list.Add(p);
                        break;
                    }
                }
            }

            string msg;
            if (UIUtil.UpdatePermissionsByUserId(this.userId, list, out msg))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败", "提示");
                return;
            }
        }
    }
}
