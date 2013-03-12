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
    public partial class ProvincesForm : Form
    {
        public ProvincesForm()
        {
            InitializeComponent();
        }

        private void ProvincesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.bindingSource.DataSource = UIUtil.GetProvinces();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            using (ProvinceEditForm form = new ProvinceEditForm())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            Province province = this.bindingSource.Current as Province;
            if (province != null)
            {
                using (ProvinceEditForm form = new ProvinceEditForm())
                {
                    form.SetProvince(province);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            Province province = this.bindingSource.Current as Province;
            if (province != null)
            {
                string msg;
                if (UIUtil.DeleteProvinceByProvinceId(province.ProvinceId, out msg))
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("删除国家失败", "提示");
                    return;
                }
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
