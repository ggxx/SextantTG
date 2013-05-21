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
    public partial class NetPictureForm : Form
    {
        public NetPictureForm(string url)
        {
            InitializeComponent();
            this.textBox_Url.Text = url;
            this.webBrowser.Url = new Uri(url);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
