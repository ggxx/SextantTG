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
    public partial class WeiboOauthForm : Form
    {
        private string oauthCode; 
        public WeiboOauthForm()
        {
            InitializeComponent();
        }

        private void OauthOk_button_Click(object sender, EventArgs e)
        {
            oauthCode = this.OauthCode_textbox.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void OauthCancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public string GetOauthCode()
        {
            return oauthCode;
        }
    }
}
