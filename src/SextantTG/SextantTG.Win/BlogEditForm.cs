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
    public partial class BlogEditForm : Form
    {
        public Blog Blog { get; private set; }

        public BlogEditForm(Blog blog)
        {
            InitializeComponent();

            this.Blog = blog;
        }

        public BlogEditForm(SubTour subTour, string userId)
        {
            InitializeComponent();

            this.Blog = new Blog();
            this.Blog.SightsId = subTour.SightsId;
            this.Blog.SubTourId = subTour.SubTourId;
            this.Blog.TourId = subTour.TourId;
            this.Blog.UserId = userId;
            this.Blog.Title = string.Empty;
            this.Blog.Content = string.Empty;
        }



        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void BlogEditForm_Load(object sender, EventArgs e)
        {
            this.textBox_TourName.Text = UIUtil.GetTourByTourId(this.Blog.TourId).TourName;
            this.textBox_Sights.Text = UIUtil.GetSightsBySightsId(this.Blog.SightsId).SightsName;
            this.textBox_Title.Text = this.Blog.Title;
            this.textBox_Content.Text = this.Blog.Content;
        }

        private void button_Favorite_Click(object sender, EventArgs e)
        {
            using (FavoriteEditForm form = new FavoriteEditForm(this.Blog.SightsId))
            {
                form.ShowDialog();
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox_Title.Text.Trim()))
            {
                MessageBox.Show("日志标题不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.textBox_Content.Text.Trim()))
            {
                MessageBox.Show("日志正文不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Blog.Title = this.textBox_Title.Text.Trim();
            this.Blog.Content = this.textBox_Content.Text;

            string msg;
            if (UIUtil.SaveBlog(this.Blog, out msg))
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
