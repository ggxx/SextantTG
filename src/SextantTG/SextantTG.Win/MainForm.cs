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

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitMenu();
        }

        private void InitMenu()
        {
            if (Config.AppConfig.User != null)
            {
                myToolStripMenuItem.Visible = true;
            }
            else
            {
                myToolStripMenuItem.Visible = false;
            }

            if (Config.AppConfig.Permissions != null && Config.AppConfig.Permissions.Exists(delegate(Permission p)
            {
                return p.PermissionType.HasValue && p.PermissionType.Value == 9;
            }))
            {
                managementToolStripMenuItem.Visible = true;
            }
            else
            {
                managementToolStripMenuItem.Visible = false;
            }
        }

        private void cityDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(CitiesForm));
        }

        private void provinceDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(ProvincesForm));
        }

        private void countryDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(CountriesForm));
        }

        private void userDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(UsersForm));
        }

        private void sightsDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(SightsForm));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox())
            {
                aboutBox.ShowDialog();
            }
        }

        private void viewSightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(ViewSightsForm));
        }

        private void viewTourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(ViewTourForm));
        }

        private void myMainToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newTourToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void myTourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenMdiChildForm(typeof(MyTourForm));
        }
    }
}
