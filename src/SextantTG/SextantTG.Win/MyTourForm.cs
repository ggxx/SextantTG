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
    public partial class MyTourForm : Form
    {
        public MyTourForm()
        {
            InitializeComponent();

            this.listBox_Tour.DisplayMember = "TourName";
            this.listBox_Tour.ValueMember = "TourId";

            this.Column_ST_SightsId.DisplayMember = "SightsName";
            this.Column_ST_SightsId.ValueMember = "SightsId";
            this.Column_ST_SightsId.DataSource = UIUtil.GetSights();

            this.Column_C_CommentUserId.DisplayMember = "LoginName";
            this.Column_C_CommentUserId.ValueMember = "UserId";
            this.Column_C_CommentUserId.DataSource = UIUtil.GetUsers();
        
            this.Column_B_TourId.DisplayMember = "TourName";
            this.Column_B_TourId.ValueMember = "TourId";
            this.Column_B_TourId.DataSource = UIUtil.GetToursByUserId(Config.AppConfig.User.UserId);

            this.Column_B_SubTourId.DisplayMember = "SubTourName";
            this.Column_B_SubTourId.ValueMember = "SubTourId";
            this.Column_B_SubTourId.DataSource = UIUtil.GetSubToursByUserId(Config.AppConfig.User.UserId);

            this.Column_B_SightsId.DisplayMember = "SightsName";
            this.Column_B_SightsId.ValueMember = "SightsId";
            this.Column_B_SightsId.DataSource = UIUtil.GetSights();
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            using (TourEditForm form = new TourEditForm())
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindControls();
                }
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (this.listBox_Tour.SelectedItem != null)
            {
                using (TourEditForm form = new TourEditForm())
                {
                    form.SetTour(listBox_Tour.SelectedItem as Tour);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindControls();
                    }
                }
            }
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            if (this.listBox_Tour.SelectedItem != null)
            {
                string tourId = (listBox_Tour.SelectedItem as Tour).TourId;
                bool val;
                string msg;
                switch (MessageBox.Show("是否删除与行旅行有关的图片与日志？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        val = UIUtil.DeleteTourByTourId(tourId, true, out msg);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        val = UIUtil.DeleteTourByTourId(tourId, false, out msg);
                        break;
                    default:
                        return;
                }

                if (val)
                {
                    listBox_Tour_SelectedIndexChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("操作失败\r\n" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void ViewUserTourForm_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            this.listBox_Tour.DataSource = UIUtil.GetToursByUserId(Config.AppConfig.User.UserId);
        }

        private void listBox_Tour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox_Tour.SelectedItem != null)
            {
                BindItem(this.listBox_Tour.SelectedItem as Tour);
            }
            else
            {
                ClearBindItem();
            }
        }

        private void BindItem(Tour tour)
        {
            string status = string.Empty;
            UIUtil.GetTourStatusDict().TryGetValue(tour.Status.Value, out status);

            this.textBox_TourName.Text = tour.TourName;
            this.textBox_User.Text = UIUtil.GetUserByUserId(tour.UserId).LoginName;
            this.textBox_Cost.Text = CustomTypeConverter.ToString(tour.Cost, "n2");
            this.textBox_BeginDate.Text = CustomTypeConverter.ToString(tour.BeginDate, "yyyy-MM-dd");
            this.textBox_EndDate.Text = CustomTypeConverter.ToString(tour.EndDate, "yyyy-MM-dd");
            this.textBox_Status.Text = status;
            this.textBox_Memos.Text = tour.Memos;

            //
            this.stgReadonlyPictures.SetPicturesForTour(tour.TourId);

            //
            this.bindingSource_SubTour.DataSource = UIUtil.GetSubToursByTourId(tour.TourId);

            //
            this.bindingSource_Comment.DataSource = UIUtil.GetTourCommentsByTourId(tour.TourId);

            //
            this.bindingSource_Blog.DataSource = UIUtil.GetBlogsByTourId(tour.TourId);

            if (tour.Status != 0)
            {
                this.button_Blog.Enabled = true;
                this.button_Picture.Enabled = true;
            }
            else
            {
                this.button_Blog.Enabled = false;
                this.button_Picture.Enabled = false;
            }
        }

        private void ClearBindItem()
        {
            this.textBox_TourName.Text = string.Empty;
            this.textBox_User.Text = string.Empty;
            this.textBox_Cost.Text = string.Empty;
            this.textBox_BeginDate.Text = string.Empty;
            this.textBox_EndDate.Text = string.Empty;
            this.textBox_Memos.Text = string.Empty;

            //
            this.stgReadonlyPictures.ResetList();

            //
            this.dataGridView_SubTour.AutoGenerateColumns = true;
            this.bindingSource_SubTour.DataSource = null;

            //
            this.dataGridView_Comment.AutoGenerateColumns = true;
            this.bindingSource_Comment.DataSource = null;

            //
            this.dataGridView_Blog.AutoGenerateColumns = true;
            this.bindingSource_Blog.DataSource = null;

            this.button_Blog.Enabled = false;
            this.button_Picture.Enabled = false;
        }

        private void button_Comment_Click(object sender, EventArgs e)
        {
            if (listBox_Tour.SelectedItem != null)
            {
                using (CommentEditForm form = new CommentEditForm(this.listBox_Tour.SelectedItem as Tour))
                {
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        BindItem(this.listBox_Tour.SelectedItem as Tour);
                    }
                }
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Blog_Click(object sender, EventArgs e)
        {
            if (listBox_Tour.SelectedItem != null)
            {
                string tourId = listBox_Tour.SelectedValue.ToString();
                string subTourId = string.Empty;
                string userId = Config.AppConfig.User.UserId;

                if (bindingSource_SubTour.Current != null)
                {
                    subTourId = (bindingSource_SubTour.Current as SubTour).SubTourId;
                }

                using (FindSubTourForm form = new FindSubTourForm(userId))
                {
                    form.SetListSelectedItem(tourId, subTourId);
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        using (BlogEditForm blogForm = new BlogEditForm(form.SubTour, userId))
                        {
                            if (blogForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                BindItem(this.listBox_Tour.SelectedItem as Tour);
                            }
                        }
                    }
                }
            }
        }

        private void button_Picture_Click(object sender, EventArgs e)
        {
            if (listBox_Tour.SelectedItem != null)
            {
                string tourId = listBox_Tour.SelectedValue.ToString();
                string userId = Config.AppConfig.User.UserId;

                using (FindSubTourForm form = new FindSubTourForm(userId, tourId))
                {
                    form.SetListSelectedItem(tourId, "");
                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        using (MyTourPicturesForm picForm = new MyTourPicturesForm(form.SubTour.SightsId, form.SubTour.TourId, form.SubTour.SubTourId, userId))
                        {
                            if (picForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                BindItem(this.listBox_Tour.SelectedItem as Tour);
                            }
                        }
                    }
                }
            }
        }
    }
}
