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
    public partial class CountryEditForm : Form
    {
        private Country country = null;

        public CountryEditForm()
        {
            InitializeComponent();
        }

        public void SetCountry(Country country)
        {
            this.country = country;
            this.textBox_CountryName.Text = country.CountryName;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            bool val;
            string msg;
            if (country == null || string.IsNullOrEmpty(country.CountryId))
            {
                country = new Country();
                country.CountryName = this.textBox_CountryName.Text.Trim();
                val = UIUtil.InsertCountry(country, out msg);
            }
            else
            {
                country.CountryName = this.textBox_CountryName.Text.Trim();
                val = UIUtil.UpdateCountry(country, out msg);
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
    }
}
