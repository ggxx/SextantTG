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
        private ImageList images = new ImageList();
        private static readonly string PicPath = System.Configuration.ConfigurationManager.AppSettings["PIC_PATH"];
        public List<Picture> Pictures { get; private set; }

        public STGReadonlyPictures()
        {
            InitializeComponent();
            Pictures = new List<Picture>();
            images.ImageSize = new Size(32, 32);
            this.listView_Pic.LargeImageList = images;
        }

        public void SetPicturesForSights(string sightsId, string uploaderId, bool allowComment)
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

            this.Pictures = UIUtil.GetPicturesBySightsIdAndUploaderId(sightsId, uploaderId);

            foreach (Picture pic in this.Pictures)
            {
                images.Images.Add(pic.PictureId, new System.Drawing.Bitmap(PicPath + pic.Path));
                this.listView_Pic.Items.Add(pic.PictureId, pic.Description, pic.PictureId);
            }
        }

        public void SetPicturesForTour(string tourId,  bool allowComment)
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

            this.Pictures = UIUtil.GetPicturesByTourId(tourId);
            foreach (Picture pic in this.Pictures)
            {
                images.Images.Add(pic.PictureId, new System.Drawing.Bitmap(PicPath + pic.Path));
                this.listView_Pic.Items.Add(pic.PictureId, pic.Description, pic.PictureId);
            }
        }

        public void SetPicturesForTour(string tourId, string subTourId)
        {
            this.images.Images.Clear();
            this.listView_Pic.Items.Clear();
            this.Pictures.Clear();

            List<Picture> pictures = UIUtil.GetPicturesByTourIdAndSubTourId(tourId, subTourId);
            foreach (Picture pic in pictures)
            {
                images.Images.Add(pic.PictureId, new System.Drawing.Bitmap(PicPath + pic.Path));
                this.listView_Pic.Items.Add(pic.PictureId, pic.Description, pic.PictureId);
            }
        }

        public void ResetList()
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
            using (PictureForm form = new PictureForm(picFile, picId, true))
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