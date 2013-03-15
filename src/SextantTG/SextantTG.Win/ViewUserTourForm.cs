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
    public partial class ViewUserTourForm : Form
    {
        public ViewUserTourForm()
        {
            InitializeComponent();
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            using (TourEditForm form = new TourEditForm())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
 
                }
            }
        }
    }
}
