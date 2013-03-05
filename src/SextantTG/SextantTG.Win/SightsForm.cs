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
    public partial class SightsForm : Form
    {
        public SightsForm()
        {
            InitializeComponent();
        }

        private void SightsForm_Load(object sender, EventArgs e)
        {
            this.comboBox_Countries.DisplayMember = "CountryName";
            this.comboBox_Countries.ValueMember = "CountryId";
            this.comboBox_Countries.DataSource = UIUtil.GetCountries();
        }
    }
}
