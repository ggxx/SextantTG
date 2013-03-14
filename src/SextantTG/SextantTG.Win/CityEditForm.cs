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
    public partial class CityEditForm : Form
    {
        private City city = null;

        public CityEditForm()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";
            this.comboBox_Country.DataSource = UIUtil.GetCountries();

            this.comboBox_Province.DisplayMember = "ProvinceName";
            this.comboBox_Province.ValueMember = "ProvinceId";
            //this.comboBox_Province.DataSource = UIUtil.GetProvinces();
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Country.SelectedValue != null)
            {
                this.comboBox_Province.DataSource = UIUtil.GetProvincesByCountryId(this.comboBox_Country.SelectedValue.ToString());
            }
        }

        public void SetCity(City city)
        {
            this.city = city;
            this.textBox_CityName.Text = city.CityName;
            this.comboBox_Country.SelectedValue = UIUtil.GetCountryByProvinceId(city.ProvinceId).CountryId;
            this.comboBox_Province.SelectedValue = city.ProvinceId;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            bool val;
            string msg;
            if (this.city == null || string.IsNullOrEmpty(this.city.CityId))
            {
                this.city = new City();
                city.CityName = this.textBox_CityName.Text.Trim();
                city.ProvinceId = this.comboBox_Province.SelectedValue.ToString();
                val = UIUtil.InsertCity(city, out msg);
            }
            else
            {
                city.CityName = this.textBox_CityName.Text.Trim();
                city.ProvinceId = this.comboBox_Province.SelectedValue.ToString();
                val = UIUtil.UpdateCity(city, out msg);
            }

            if (val)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败\r\n" + msg,"提示");
                return;
            }
        }
    }
}
