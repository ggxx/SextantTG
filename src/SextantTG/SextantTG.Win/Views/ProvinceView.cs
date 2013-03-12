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
    internal partial class ProvinceView : UserControl
    {
        private string provinceId = "";

        internal ProvinceView()
        {
            InitializeComponent();
        }

        internal void BindData()
        {
            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";
            //this.comboBox_Country.DataSource = UIUtil.GetCountries();
        }

        internal void SetProvince(Province province)
        {
            this.provinceId = province.ProvinceId;
            this.textBox_ProvinceName.Text = province.ProvinceName;
            this.comboBox_Country.SelectedValue = province.CountryId;
        }

        private Province GetProvince()
        {
            Province province = new Province();
            province.ProvinceId = this.provinceId;
            province.ProvinceName = this.textBox_ProvinceName.Text;
            province.CountryId = this.comboBox_Country.SelectedValue.ToString();

            return province;
        }

        internal bool Save(out string message)
        {
            if (string.IsNullOrEmpty(provinceId))
            {
                return UIUtil.InsertProvince(GetProvince(), out message);
            }
            else
            {
                return UIUtil.UpdateProvince(GetProvince(), out message);
            }
        }
    }
}
