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
    public partial class ProvinceEditForm : Form
    {
        private Province province;

        public ProvinceEditForm()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            this.comboBox_Country.DisplayMember = "CountryName";
            this.comboBox_Country.ValueMember = "CountryId";
            this.comboBox_Country.DataSource = UIUtil.GetCountries();
        }

        public void SetProvince(Province province)
        {
            this.province = province;
            this.textBox_ProvinceName.Text = province.ProvinceName;
            this.comboBox_Country.SelectedValue = province.CountryId;
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
            if (this.province == null)
            {
                this.province = new Province();
                this.province.ProvinceName = this.textBox_ProvinceName.Text.Trim();
                this.province.CountryId = this.comboBox_Country.SelectedValue.ToString();
                val = UIUtil.InsertProvince(province, out msg);
            }
            else
            {
                this.province.ProvinceName = this.textBox_ProvinceName.Text.Trim();
                this.province.CountryId = this.comboBox_Country.SelectedValue.ToString();
                val = UIUtil.UpdateProvince(province, out msg);
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
