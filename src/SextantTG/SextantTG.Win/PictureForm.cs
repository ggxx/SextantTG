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
    public partial class PictureForm : Form
    {
        private string pictureId;

        public PictureForm(string picFile, string picId, bool isReadonly)
        {
            InitializeComponent();

            this.pictureId = picId;

            this.Column_C_CommentUserId.DisplayMember = "LoginName";
            this.Column_C_CommentUserId.ValueMember = "UserId";
            this.Column_C_CommentUserId.DataSource = UIUtil.GetUsers();

            this.pictureBox.ImageLocation = picFile;
            this.bindingSource_Comment.DataSource = UIUtil.GetPictureCommentsByPictureId(picId);
            if (isReadonly)
            {
                this.button_Comment.Visible = false;
            }
            else
            {
                this.button_Comment.Visible = true;
            }
        }

        private void button_Comment_Click(object sender, EventArgs e)
        {
            using (CommentEditForm form = new CommentEditForm(UIUtil.GetPictureByPictureId(pictureId)))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.bindingSource_Comment.DataSource = UIUtil.GetPictureCommentsByPictureId(pictureId);
                }
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
