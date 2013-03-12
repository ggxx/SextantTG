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
    internal partial class CountryView : UserControl
    {
        private string countryId = "";

        internal CountryView()
        {
            InitializeComponent();
        }

        private Country GetCountry()
        {
            Country country = new Country();
            country.CountryId = this.countryId;
            country.CountryName = this.textBox_CountryName.Text.Trim();
            return country;
        }

        internal void SetCountry(Country country)
        {
            this.countryId = country.CountryId;
            this.textBox_CountryName.Text = country.CountryName;
        }

        internal bool Save(out string message)
        {
            if (string.IsNullOrEmpty(countryId))
            {
                return UIUtil.InsertCountry(GetCountry(), out message);
            }
            else
            {
                return UIUtil.UpdateCountry(GetCountry(), out message);
            }
        }
    }
}
