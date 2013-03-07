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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form OpenMdiChildForm(Type formType)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.GetType() == formType)
                {
                    childForm.Activate();
                    return childForm;
                }
            }

            Form form = (Form)Activator.CreateInstance(formType);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            return form;
        }

        private void sightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(SightsForm));
        }

        private void cityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(CitiesForm));
        }

        private void provinceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(ProvincesForm));
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(CountriesForm));
        }


    }
}
