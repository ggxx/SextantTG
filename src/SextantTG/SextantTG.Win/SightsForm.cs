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

            this.comboBox_Countries.DisplayMember = "CountryName";
            this.comboBox_Countries.ValueMember = "CountryId";

            this.comboBox_Provinces.DisplayMember = "ProvinceName";
            this.comboBox_Provinces.ValueMember = "ProvinceId";

            this.listBox_Sights.DisplayMember = "CityName";
            this.listBox_Sights.ValueMember = "CityId";
        }

        private void comboBox_Countries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Countries.SelectedValue != null)
            {
                this.bindingSource_Province.Filter = string.Format("CountryId = '{0}'", this.comboBox_Countries.SelectedValue);
            }
            else
            {
                this.bindingSource_Province.RemoveFilter();
            }
        }

        private void comboBox_Provinces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Provinces.SelectedValue != null)
            {
                this.bindingSource_City.Filter = string.Format("ProvinceId = '{0}'", this.comboBox_Provinces.SelectedValue);
            }
            else
            {
                this.bindingSource_City.RemoveFilter();
            }
        }

        private void listBox_Cities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox_Sights.SelectedValue != null)
            {

            }
            else
            {
 
            }
        }
    }
}
