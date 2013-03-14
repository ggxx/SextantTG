using SextantTG.ActiveRecord;
using SextantTG.Util;
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
    public partial class ViewSightsForm : Form
    {
        public ViewSightsForm()
        {
            InitializeComponent();
        }

        private void SightsForm_Load(object sender, EventArgs e)
        {
            //this.Column_CityId.DisplayMember = "CityName";
            //this.Column_CityId.ValueMember = "CityId";
            //this.Column_CityId.DataSource = UIUtil.GetCities();

            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";

            this.comboBox_Province.DisplayMember = "ProvinceName";
            this.comboBox_Province.ValueMember = "ProvinceId";

            this.comboBox_City.DisplayMember = "CityName";
            this.comboBox_City.ValueMember = "CityId";

            this.comboBox_Country.DataSource = UIUtil.GetCountries();

            this.listBox_Sights.DisplayMember = "SightsName";
            this.listBox_Sights.ValueMember = "SightsId";
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Country.SelectedValue != null)
            {
                this.comboBox_Province.DataSource = UIUtil.GetProvincesByCountryId(comboBox_Country.SelectedValue.ToString());
            }
            else
            {
                this.comboBox_Province.DataSource = null;
                this.comboBox_City.DataSource = null;
            }
        }

        private void comboBox_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Province.SelectedValue != null)
            {
                this.comboBox_City.DataSource = UIUtil.GetCitiesByProvinceId(comboBox_Province.SelectedValue.ToString());
            }
            else
            {
                this.comboBox_City.DataSource = null;
            }
        }

        private void comboBox_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_City.SelectedValue != null)
            {
                this.listBox_Sights.DataSource = UIUtil.GetSightsByCityId(comboBox_City.SelectedValue.ToString());
            }
            else
            {
                this.listBox_Sights.DataSource = null;
            }
        }

        private void listBox_Sights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Sights.SelectedItem != null)
            {
                BindItem(this.listBox_Sights.SelectedItem as Sights);
                
            }
        }

        private void BindItem(Sights sights)
        {
            float? stars = UIUtil.GetAverageStarsBySightsId(sights.SightsId);

            this.textBox_SightsName.Text = sights.SightsName;
            this.textBox_Stars.Text = CustomTypeConverter.ToString(stars, "n2");
            this.textBox_Country.Text = UIUtil.GetCountryByProvinceId(UIUtil.GetProvinceByCityId(sights.CityId).ProvinceId).CountryName;
            this.textBox_Province.Text = UIUtil.GetProvinceByCityId(sights.CityId).ProvinceName;
            this.textBox_City.Text = UIUtil.GetCityByCityId(sights.CityId).CityName;
            this.textBox_SightsLevel.Text = sights.SightsLevel;
            this.textBox_Price.Text = CustomTypeConverter.ToString(sights.Price, "n2");
            this.textBox_Description.Text = sights.Description;


        }


    }
}
