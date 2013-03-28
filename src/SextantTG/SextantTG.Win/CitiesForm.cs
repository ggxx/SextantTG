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
    public partial class CitiesForm : Form
    {
        public CitiesForm()
        {
            InitializeComponent();
        }

        private void CitiesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {


            this.Column_ProvinceId.DataSource = UIUtil.GetProvinces();
            this.Column_ProvinceId.DisplayMember = "ProvinceName";
            this.Column_ProvinceId.ValueMember = "ProvinceId";

            //this.dataGridView.AutoGenerateColumns = true;
            this.bindingSource.DataSource = UIUtil.GetCities();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            using (CityEditForm form = new CityEditForm())
            {
                form.BindData();
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            City city = this.bindingSource.Current as City;
            if (city != null)
            {
                using (CityEditForm form = new CityEditForm())
                {
                    form.BindData();
                    form.SetCity(city);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            City city = this.bindingSource.Current as City;
            if (city != null)
            {
                string msg;
                if (UIUtil.DeleteCity(city, out msg))
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("操作失败\r\n" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
