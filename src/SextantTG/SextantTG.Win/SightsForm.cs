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
    public partial class SightsForm : Form
    {
        public SightsForm()
        {
            InitializeComponent();
        }

        private void SightsForm_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            this.Column_CityId.DisplayMember = "CityName";
            this.Column_CityId.ValueMember = "CityId";
            this.Column_CityId.DataSource = UIUtil.GetCities();

            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";

            this.comboBox_Province.DisplayMember = "ProvinceName";
            this.comboBox_Province.ValueMember = "ProvinceId";

            this.comboBox_City.DisplayMember = "CityName";
            this.comboBox_City.ValueMember = "CityId";
            
            List<Country> countries = UIUtil.GetCountries();
            //Country country = new Country();
            //country.CountryId = "*";
            //country.CountryName = "<全部>";
            //countries.Insert(0, country);
            this.comboBox_Country.DataSource = countries;
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Country.SelectedValue != null)
            {
                if (comboBox_Country.SelectedValue.ToString() != "*")
                {
                    List<Province> provinces = UIUtil.GetProvincesByCountryId(comboBox_Country.SelectedValue.ToString());
                    //Province province = new Province();
                    //province.ProvinceId = "*";
                    //province.ProvinceName = "<全部>";
                    //provinces.Insert(0, province);
                    this.comboBox_Province.DataSource = provinces;
                }
                else
                {
                    List<Province> provinces = UIUtil.GetProvinces();
                    //Province province = new Province();
                    //province.ProvinceId = "*";
                    //province.ProvinceName = "<全部>";
                    //provinces.Insert(0, province);
                    this.comboBox_Province.DataSource = provinces;
                }
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
                if (comboBox_Province.SelectedValue.ToString() != "*")
                {
                    List<City> cities = UIUtil.GetCitiesByProvinceId(comboBox_Province.SelectedValue.ToString());
                    //City city = new City();
                    //city.CityId = "*";
                    //city.CityName = "<全部>";
                    //cities.Insert(0, city);
                    this.comboBox_City.DataSource = cities;
                }
                else
                {
                    if (comboBox_Country.SelectedValue.ToString() != "*")
                    {
                        List<City> cities = UIUtil.GetCitiesByCountryId(comboBox_Country.SelectedValue.ToString());
                        //City city = new City();
                        //city.CityId = "*";
                        //city.CityName = "<全部>";
                        //cities.Insert(0, city);
                        this.comboBox_City.DataSource = cities;
                    }
                    else
                    {
                        List<City> cities = UIUtil.GetCities();
                        //City city = new City();
                        //city.CityId = "*";
                        //city.CityName = "<全部>";
                        //cities.Insert(0, city);
                        this.comboBox_City.DataSource = cities;
                    }
                }
            }
            else
            {
                this.comboBox_City.DataSource = null;
            }
        }

        private void button_Query_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (this.comboBox_City.SelectedValue != null)
            {
                this.bindingSource.DataSource = UIUtil.GetSightsByCityId(this.comboBox_City.SelectedValue.ToString());
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (this.bindingSource.Current != null)
            {
                using (SightsEditForm form = new SightsEditForm())
                {
                    form.BindControls();
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (this.bindingSource.Current != null)
            {
                using (SightsEditForm form = new SightsEditForm())
                {
                    form.BindControls();
                    form.SetSights(this.bindingSource.Current as Sights);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (this.bindingSource.Current != null)
            {
                string msg;
                if (UIUtil.DeleteSightsBySightsId((this.bindingSource.Current as Sights).SightsId, out msg))
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("操作失败\r\n" + msg, "提示");
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
