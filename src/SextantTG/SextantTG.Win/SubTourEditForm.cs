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
    public partial class SubTourEditForm : Form
    {
        public SubTour SubTour { get; private set; }

        public SubTourEditForm()
        {
            InitializeComponent();

            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";

            this.comboBox_Province.DisplayMember = "ProvinceName";
            this.comboBox_Province.ValueMember = "ProvinceId";

            this.comboBox_City.DisplayMember = "CityName";
            this.comboBox_City.ValueMember = "CityId";

            this.comboBox_Sights.DisplayMember = "SightsName";
            this.comboBox_Sights.ValueMember = "SightsId";

            this.comboBox_Country.DataSource = UIUtil.GetCountries();
        }

        public void SetSubTour(SubTour subTour)
        {
            string country, province, city;
            city = UIUtil.GetSightsBySightsId(subTour.SightsId).CityId;
            province = UIUtil.GetProvinceByCityId(city).ProvinceId;
            country = UIUtil.GetCountryByProvinceId(province).CountryId;

            this.SubTour = subTour;
            this.textBox_TourName.Text = this.SubTour.SubTourName;
            this.comboBox_Country.SelectedValue = country;
            this.comboBox_Province.SelectedValue = province;
            this.comboBox_City.SelectedValue = city;
            this.comboBox_Sights.SelectedValue = this.SubTour.SightsId;
            this.dateTimePicker_Begin.Value = this.SubTour.BeginDate.Value;
            this.dateTimePicker_End.Value = this.SubTour.EndDate.Value;
            this.textBox_Memos.Text = this.SubTour.Memos;
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Country.SelectedValue != null)
            {
                List<Province> provinces = UIUtil.GetProvincesByCountryId(comboBox_Country.SelectedValue.ToString());
                this.comboBox_Province.DataSource = provinces;
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
                List<City> cities = UIUtil.GetCitiesByProvinceId(comboBox_Province.SelectedValue.ToString());
                this.comboBox_City.DataSource = cities;
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
                this.comboBox_Sights.DataSource = UIUtil.GetSightsByCityId(comboBox_City.SelectedValue.ToString());
            }
            else
            {
                this.comboBox_Sights.DataSource = null;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox_TourName.Text.Trim()))
            {
                MessageBox.Show("行程名称不能为空", "提示");
                return;
            }
            if (this.comboBox_Sights.SelectedValue == null)
            {
                MessageBox.Show("景点不能为空", "提示");
                return;
            }

            if (this.SubTour == null)
                this.SubTour = new SubTour();

            this.SubTour.SubTourName = this.textBox_TourName.Text.Trim();
            this.SubTour.SightsId = this.comboBox_Sights.SelectedValue.ToString();
            this.SubTour.BeginDate = this.dateTimePicker_Begin.Value;
            this.SubTour.EndDate = this.dateTimePicker_End.Value;
            this.SubTour.Memos = this.textBox_Memos.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }
}
