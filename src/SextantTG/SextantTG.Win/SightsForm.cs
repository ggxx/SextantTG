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

        }
    }
}
