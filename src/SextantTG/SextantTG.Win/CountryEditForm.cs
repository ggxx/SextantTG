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
        public CountryEditForm()
        {
            InitializeComponent();
        }

        public CountryEditForm(Country country)
        {
            InitializeComponent();
            this.countryView.SetCountry(country);
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string message;
            if (this.countryView.Save(out message))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error", message);
            }
        }
    }
}
