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
    public partial class SightsEditForm : Form
    {
        private Sights sights = null;

        public SightsEditForm()
        {
            InitializeComponent();
        }

        public void BindControls()
        {
            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";

            this.comboBox_Province.DisplayMember = "ProvinceName";
            this.comboBox_Province.ValueMember = "ProvinceId";

            this.comboBox_City.DisplayMember = "CityName";
            this.comboBox_City.ValueMember = "CityId";

            this.comboBox_Country.DataSource = UIUtil.GetCountries();
        }

        public void SetSights(Sights sights)
        {
            this.sights = sights;
            this.textBox_SightsName.Text = sights.SightsName;
            this.comboBox_Country.SelectedValue = UIUtil.GetProvinceByCityId(sights.CityId).CountryId;
            this.comboBox_Province.SelectedValue = UIUtil.GetProvinceByCityId(sights.CityId).ProvinceId;
            this.comboBox_City.SelectedValue = sights.CityId;
            this.comboBox_SightsLevel.SelectedItem = sights.SightsLevel;
            this.maskedTextBox_Price.Text = Util.TypeConverter.ToString(sights.Price, "n2");
            this.textBox_Description.Text = sights.Description;
            this.textBox_Memos.Text = sights.Memos;
            this.textBox_CreatingTime.Text = Util.TypeConverter.ToString(sights.CreatingTime, "yyyy-MM-dd HH:mm:ss");
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox_SightsName.Text.Trim()))
            {
                MessageBox.Show("景点名称不能为空", "提示");
                return;
            }
            if (this.comboBox_City.SelectedValue == null)
            {
                MessageBox.Show("所属城市不能为空", "提示");
                return;
            }
            if (string.IsNullOrEmpty(this.comboBox_SightsLevel.Text))
            {
                MessageBox.Show("景点等级不能为空", "提示");
                return;
            }

            bool val;
            string msg;
            if (this.sights == null || string.IsNullOrEmpty(this.sights.SightsId))
            {
                sights = new Sights();
                sights.SightsName = this.textBox_SightsName.Text.Trim();
                sights.CityId = this.comboBox_City.SelectedValue.ToString();
                sights.SightsLevel = this.comboBox_SightsLevel.Text;
                sights.Price = Util.TypeConverter.ToInt32Null(this.maskedTextBox_Price.Text);
                sights.Description = this.textBox_Description.Text.Trim();
                sights.Memos = this.textBox_Memos.Text.Trim();
                sights.CreatingTime = Util.TypeConverter.ToDateTimeNull(this.textBox_CreatingTime.Text, "yyyy-MM-dd HH:mm:ss");

                val = UIUtil.InsertSights(sights, out msg);
            }
            else
            {
                sights.SightsName = this.textBox_SightsName.Text.Trim();
                sights.CityId = this.comboBox_City.SelectedValue.ToString();
                sights.SightsLevel = this.comboBox_SightsLevel.Text;
                sights.Price = Util.TypeConverter.ToInt32Null(this.maskedTextBox_Price.Text);
                sights.Description = this.textBox_Description.Text.Trim();
                sights.Memos = this.textBox_Memos.Text.Trim();
                sights.CreatingTime = Util.TypeConverter.ToDateTimeNull(this.textBox_CreatingTime.Text, "yyyy-MM-dd HH:mm:ss");

                val = UIUtil.UpdateSights(sights, out msg);
            }

            if (val)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败\r\n" + msg, "提示");
                return;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Country.SelectedValue != null)
            {
                if (comboBox_Country.SelectedValue.ToString() != "*")
                {
                    this.comboBox_Province.DataSource = UIUtil.GetProvincesByCountryId(comboBox_Country.SelectedValue.ToString());
                }
                else
                {
                    this.comboBox_Province.DataSource = UIUtil.GetProvinces();
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
                    this.comboBox_City.DataSource = UIUtil.GetCitiesByProvinceId(comboBox_Province.SelectedValue.ToString());
                }
                else
                {
                    if (comboBox_Country.SelectedValue.ToString() != "*")
                    {
                        this.comboBox_City.DataSource = UIUtil.GetCitiesByCountryId(comboBox_Country.SelectedValue.ToString());
                    }
                    else
                    {
                        this.comboBox_City.DataSource = UIUtil.GetCities();
                    }
                }
            }
            else
            {
                this.comboBox_City.DataSource = null;
            }
        }
    }
}
