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
    public partial class CountriesForm : Form
    {
        public CountriesForm()
        {
            InitializeComponent();
        }

        private void CountriesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            //this.dataGridView.AutoGenerateColumns = true;
            this.bindingSource.DataSource = UIUtil.GetCountries();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            using (CountryEditForm form = new CountryEditForm())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            Country country = this.bindingSource.Current as Country;
            if (country != null)
            {
                using (CountryEditForm form = new CountryEditForm())
                {
                    form.SetCountry(country);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            Country country = this.bindingSource.Current as Country;
            if (country != null)
            {
                string msg;
                if (UIUtil.DeleteCountry(country, out msg))
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("操作失败\r\n" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
