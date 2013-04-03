using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SextantTG.ActiveRecord;
using System.IO;

namespace SextantTG.Win
{
    public partial class STGReadonlyPictures : UserControl
    {
        private bool allowComment = false;
        private ImageList images = new ImageList();
        private static readonly string PicPath = System.Configuration.ConfigurationManager.AppSettings["PIC_PATH"];
        
        /// <summary>
        /// 设置或获取控件中的所有图片
        /// </summary>
        internal List<Picture> Pictures { get; private set; }

        public STGReadonlyPictures()
        {
            InitializeComponent();
            Pictures = new List<Picture>();
            images.ImageSize = new Size(32, 32);
            this.listView_Pic.LargeImageList = images;
        }

        /// <summary>
        /// 设置控件，显示指定用户上传的关于指定景点所有的图片
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <param name="uploaderId">用户ID</param>
        /// <param name="allowComment">是否允许添加图片评论</param>
        internal void SetPicturesForSights(string sightsId, string uploaderId, bool allowComment)
        {
            if (allowComment)
            {
                this.addCommentToolStripMenuItem.Visible = true;
            }
            else
            {
                this.addCommentToolStripMenuItem.Visible = false;
            }

            images.Images.Clear();
            this.listView_Pic.Items.Clear();

            this.allowComment = allowComment;
            this.Pictures = UIUtil.GetPicturesBySightsIdAndUploaderId(sightsId, uploaderId);

            foreach (Picture pic in this.Pictures)
            {
                images.Images.Add(pic.PictureId, new System.Drawing.Bitmap(PicPath + pic.Path));
                this.listView_Pic.Items.Add(pic.PictureId, pic.Description, pic.PictureId);
            }
        }

        /// <summary>
        /// 设置控件，显示指定用户上传的关于指定旅行的所有图片
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <param name="allowComment">是否允许添加图片评论</param>
        internal void SetPicturesForTour(string tourId, bool allowComment)
        {
            if (allowComment)
            {
                this.addCommentToolStripMenuItem.Visible = true;
            }
            else
            {
                this.addCommentToolStripMenuItem.Visible = false;
            }

            images.Images.Clear();
            this.listView_Pic.Items.Clear();

            this.allowComment = allowComment;
            this.Pictures = UIUtil.GetPicturesByTourId(tourId);
            foreach (Picture pic in this.Pictures)
            {
                images.Images.Add(pic.PictureId, new System.Drawing.Bitmap(PicPath + pic.Path));
                this.listView_Pic.Items.Add(pic.PictureId, pic.Description, pic.PictureId);
            }
        }

        /// <summary>
        /// 重置控件，清除所有图片
        /// </summary>
        internal void ResetList()
        {
            this.images.Images.Clear();
            this.listView_Pic.Items.Clear();
            this.Pictures.Clear();
        }

        private void listView_Pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && this.listView_Pic.SelectedItems != null)
            {
                this.contextMenuStrip.Show(this.listView_Pic, e.Location);
            }
        }

        private void viewPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string picFile = PicPath + this.Pictures[this.listView_Pic.SelectedIndices[0]].Path;
            string picId = this.Pictures[this.listView_Pic.SelectedIndices[0]].PictureId;
            using (PictureForm form = new PictureForm(picFile, picId, !allowComment))
            {
                form.ShowDialog();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string picFile = PicPath + this.Pictures[this.listView_Pic.SelectedIndices[0]].Path;
            FileUtil.SaveFile(picFile, true);
        }

        private void listView_Pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && this.listView_Pic.SelectedItems != null)
            {
                viewPictureToolStripMenuItem_Click(sender, e);
            }
        }

        private void addCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CommentEditForm form = new CommentEditForm(this.Pictures[this.listView_Pic.SelectedIndices[0]]))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                { }
            }
        }
    }
}