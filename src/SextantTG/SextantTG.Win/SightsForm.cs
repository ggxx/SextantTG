using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SextantTG.Win
{
    public partial class SightsForm : Form
    {
        public SightsForm()
        {
            InitializeComponent();
        }

        private void SightsForm_Load(object sender, EventArgs e)
        {
            this.bindingSource_Country.DataSource = UIUtil.GetCountries();
            this.bindingSource_Province.DataSource = UIUtil.GetProvinces();
            this.bindingSource_City.DataSource = UIUtil.GetCities();

            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";

            this.comboBox_Province.DisplayMember = "ProvinceName";
            this.comboBox_Province.ValueMember = "ProvinceId";

            this.listBox_Sights.DisplayMember = "CityName";
            this.listBox_Sights.ValueMember = "CityId";
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Country.SelectedValue != null)
            {
                this.bindingSource_Province.Filter = string.Format("CountryId = '{0}'", this.comboBox_Country.SelectedValue);
            }
            else
            {
                this.bindingSource_Province.RemoveFilter();
            }
        }

        private void comboBox_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Province.SelectedValue != null)
            {
                this.bindingSource_City.Filter = string.Format("ProvinceId = '{0}'", this.comboBox_Province.SelectedValue);
            }
            else
            {
                this.bindingSource_City.RemoveFilter();
            }
        }

        private void comboBox_City_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox_Sights_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
