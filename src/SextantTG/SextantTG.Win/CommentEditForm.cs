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
    public partial class CommentEditForm : Form
    {
        private int kind = 0;
        private string targetId = string.Empty;

        public CommentEditForm(Sights sights)
        {
            InitializeComponent();
            this.kind = 1;
            this.targetId = sights.SightsId;
        }

        public CommentEditForm(User user)
        {
            InitializeComponent();
            this.kind = 2;
        }

        public CommentEditForm(Picture picture)
        {
            InitializeComponent();
            this.kind = 3;
        }

        public CommentEditForm(Tour tour)
        {
            InitializeComponent();
            this.kind = 4;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox.Text.Trim()))
            {
                MessageBox.Show("评论内容不能为空", "提示");
                return;
            }

            bool val;
            string msg;

            switch (this.kind)
            {
                case 1:
                    SightsComment comment = new SightsComment();
                    comment.Comment = this.textBox.Text;
                    comment.CommentUserId = Config.AppConfig.User.UserId;
                    comment.SightsId = targetId;
                    val = UIUtil.InsertSightsComment(comment, out msg);
                    break;
                case 2:
                    UserComment comment2 = new UserComment();
                    comment2.Comment = this.textBox.Text;
                    comment2.CommentUserId = Config.AppConfig.User.UserId;
                    comment2.UserId = targetId;
                    val = UIUtil.InsertUserComment(comment2, out msg);
                    break;
                case 3:
                    PictureComment comment3 = new PictureComment();
                    comment3.Comment = this.textBox.Text;
                    comment3.CommentUserId = Config.AppConfig.User.UserId;
                    comment3.PictureId = targetId;
                    val = UIUtil.InsertPictureComment(comment3, out msg);
                    break;
                case 4:
                    TourComment comment4 = new TourComment();
                    comment4.Comment = this.textBox.Text;
                    comment4.CommentUserId = Config.AppConfig.User.UserId;
                    comment4.TourId = targetId;
                    val = UIUtil.InsertTourComment(comment4, out msg);
                    break;
                default:
                    val = false;
                    msg = "错误的评论类型";
                    break;
            }

            if (val)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败\r\n" + msg, "提示");
                return;
            }
        }


    }
}
