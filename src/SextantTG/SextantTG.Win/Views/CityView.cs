using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SextantTG.ActiveRecord;

namespace SextantTG.Win.Views
{
    public partial class CityView : UserControl
    {
        private string cityId = "";

        private City GetCity()
        {
            City city = new City();
            city.CityId = this.cityId;
            city.CityName = this.textBox_CityName.Text.Trim();
            city.ProvinceId = this.comboBox_Province.SelectedValue.ToString();
            return city;
        }

        public CityView()
        {
            InitializeComponent();

            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";
            this.comboBox_Country.DataSource = UIUtil.GetCountries();

            this.comboBox_Province.DisplayMember = "ProvinceName";
            this.comboBox_Province.ValueMember = "ProvinceId";
            //this.comboBox_Province.DataSource = UIUtil.GetProvinces();
        }

        public void SetCity(City city)
        {
            this.cityId = city.CityId;
            this.textBox_CityName.Text = city.CityName;
            this.comboBox_Country.SelectedValue = UIUtil.GetCountryByProvinceId(city.ProvinceId).CountryId;
            this.comboBox_Province.SelectedValue = city.ProvinceId;
        }

        public bool Save(out string message)
        {
            if (string.IsNullOrEmpty(this.cityId))
            {
                return UIUtil.InsertCity(GetCity(), out message);
            }
            else
            {
                return UIUtil.UpdateCity(GetCity(), out message);
            }
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Country.SelectedValue != null)
            {
                this.comboBox_Province.DataSource = UIUtil.GetProvincesByCountryId(this.comboBox_Country.SelectedValue.ToString());
            }
            else
            {
                this.comboBox_Province.DataSource = null;
            }
        }
    }
}
