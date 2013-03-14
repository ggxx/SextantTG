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
    public partial class STGPictures : UserControl
    {
        private static readonly string PicPath = System.Configuration.ConfigurationManager.AppSettings["PIC_PATH"];
        private ImageList images = new ImageList();

        private string uploaderId, blogId;
        private string sightsId;
        public List<Picture> Pictures { get; private set; }
        public List<Picture> RemovedPictures { get; private set; }


        public STGPictures()
        {
            InitializeComponent();
            RemovedPictures = new List<Picture>();
            images.ImageSize = new Size(32, 32);
            this.listView_Pic.LargeImageList = images;
        }

        public void SetPicturesForSights(string sightsId, string uploaderId)
        {
            this.images.Images.Clear();
            this.listView_Pic.Items.Clear();

            this.sightsId = sightsId;
            this.uploaderId = uploaderId;

            if (string.IsNullOrEmpty(sightsId))
            {
                return;
            }

            this.Pictures = UIUtil.GetPicturesBySightsIdAndUploaderId(sightsId, uploaderId);
            foreach (Picture pic in Pictures)
            {
                this.images.Images.Add(pic.PictureId, new System.Drawing.Bitmap(PicPath + pic.Path));
                this.listView_Pic.Items.Add(pic.PictureId, pic.Description, pic.PictureId);
            }
        }

        public void SetPicturesForBlog(string blogId)
        {
            //List<Picture> remotePics = UIUtil.getpi(sightsId, uploaderId);
            //foreach (Picture pic in remotePics)
            //{
            //    images.Images.Add(pic.PictureId, new System.Drawing.Bitmap(PicPath + pic.Path));
            //    this.listView_Pic.Items.Add(pic.PictureId, pic.Description, pic.PictureId);
            //}
        }

        private void button_Upload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string p in dialog.FileNames)
                    {
                        if (File.Exists(p))
                        {
                            FileInfo file = new FileInfo(p);

                            Picture picture = new Picture();
                            picture.PictureId = "_" + Util.StringHelper.CreateGuid();
                            picture.SightsId = this.sightsId;
                            picture.BlogId = this.blogId;
                            picture.UploaderId = this.uploaderId;
                            picture.Path = picture.PictureId.Substring(1) + file.Extension;
                            this.Pictures.Add(picture);

                            File.Copy(p, PicPath + picture.Path);

                            images.Images.Add(picture.PictureId, new System.Drawing.Bitmap(p));
                            this.listView_Pic.Items.Add(picture.PictureId, file.Name, picture.PictureId);
                        }
                    }
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            for (int i = this.listView_Pic.Items.Count - 1; i >= 0; i--)
            {
                if (this.listView_Pic.SelectedIndices.Contains(i))
                {
                    if (!this.Pictures[i].PictureId.StartsWith("_"))
                    {
                        this.RemovedPictures.Add(this.Pictures[i]);
                    }

                    this.listView_Pic.Items.RemoveAt(i);
                    images.Images.RemoveAt(i);
                    this.Pictures.RemoveAt(i);
                }
            }
        }

        private void listView_Pic_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox_Desc.TextChanged -= textBox_Desc_TextChanged;
            if (this.listView_Pic.SelectedItems != null && this.listView_Pic.SelectedItems.Count == 1)
            {
                this.textBox_Desc.Enabled = true;
                this.textBox_Desc.Text = this.Pictures[this.listView_Pic.SelectedIndices[0]].Description;
            }
            else
            {
                this.textBox_Desc.Enabled = false;
                this.textBox_Desc.Text = string.Empty;
            }
            this.textBox_Desc.TextChanged += textBox_Desc_TextChanged;
        }

        private void textBox_Desc_TextChanged(object sender, EventArgs e)
        {
            if (this.listView_Pic.SelectedItems != null && this.listView_Pic.SelectedItems.Count == 1)
            {
                this.Pictures[this.listView_Pic.SelectedIndices[0]].Description = this.textBox_Desc.Text.Trim();
            }
        }
    }
}