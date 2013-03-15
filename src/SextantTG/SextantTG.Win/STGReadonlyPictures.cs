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

        public STGReadonlyPictures()
        {
            InitializeComponent();
            images.ImageSize = new Size(256, 256);
            this.listView_Pic.LargeImageList = images;
        }

        public void SetPicturesForSights(string sightsId, string uploaderId)
        {
            images.Images.Clear();
            this.listView_Pic.Items.Clear();

            List<Picture> pictures = UIUtil.GetPicturesBySightsIdAndUploaderId(sightsId, uploaderId);
           
            foreach (Picture pic in pictures)
            {
                images.Images.Add(pic.PictureId, new System.Drawing.Bitmap(PicPath + pic.Path));
                this.listView_Pic.Items.Add(pic.PictureId, pic.Description, pic.PictureId);
            }
        }

        public void SetPicturesForTour(string tourId)
        {
            images.Images.Clear();
            this.listView_Pic.Items.Clear();

            List<Picture> remotePics = UIUtil.GetPicturesByTourId(tourId);
            foreach (Picture pic in remotePics)
            {
                images.Images.Add(pic.PictureId, new System.Drawing.Bitmap(PicPath + pic.Path));
                this.listView_Pic.Items.Add(pic.PictureId, pic.Description, pic.PictureId);
            }
        }

        public void SetPicturesForTour(string tourId, string subTourId)
        {
            this.images.Images.Clear();
            this.listView_Pic.Items.Clear();

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
        }
    }
}