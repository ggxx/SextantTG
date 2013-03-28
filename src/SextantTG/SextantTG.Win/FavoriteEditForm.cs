using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SextantTG.ActiveRecord;
using SextantTG.Util;

namespace SextantTG.Win
{
    public partial class FavoriteEditForm : Form
    {
        private string sightsId;

        public FavoriteEditForm(string sightsId)
        {
            InitializeComponent();
            this.sightsId = sightsId;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string msg;

            Favorite fav = new Favorite();
            fav.SightsId = this.sightsId;
            fav.UserId = Config.AppConfig.User.UserId;
            fav.Stars = (int?)this.numericUpDown.Value;
            fav.Visited = this.radioButton_Yes.Checked ? 1 : 0;


            if (UIUtil.SaveFavorite(fav, out msg))
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
    }
}
