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
    public partial class UploadPicturesForm : Form
    {
        public UploadPicturesForm(string sightsId, string tourId, string subTourId, string uploaderId)
        {
            InitializeComponent();

            this.stgPictures.SetPicturesForTour(sightsId, tourId, subTourId, uploaderId);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string msg;
            if (UIUtil.SavePictures(stgPictures.Pictures, stgPictures.RemovedPictures, out msg))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败\r\n" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
