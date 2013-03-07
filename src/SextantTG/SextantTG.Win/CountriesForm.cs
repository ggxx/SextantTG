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
    public partial class CountriesForm : Form
    {
        public CountriesForm()
        {
            InitializeComponent();

            this.dataGridView.DataSource = UIUtil.GetCountries();

        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            CountryEditForm form = new CountryEditForm();
            form.ShowDialog();

            this.Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            CountryEditForm form = new CountryEditForm();
            form.ShowDialog();
        }
    }
}
