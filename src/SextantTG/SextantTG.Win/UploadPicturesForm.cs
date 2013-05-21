using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTSDK.Tencent;
using OpenTSDK.Tencent.API;
using OpenTSDK.Tencent.Objects;
using SextantTG.ActiveRecord;

namespace SextantTG.Win
{
    public partial class UploadPicturesForm : Form
    {
        private static readonly string PicPath = System.Configuration.ConfigurationManager.AppSettings["PIC_PATH"];

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
                //将图片发布到腾讯微博中
                TencentWeibo tencentWeibo = new TencentWeibo();
                OAuth oauth = tencentWeibo.GetOAuth();
                foreach (Picture pic in stgPictures.Pictures)
                {
                    string path = PicPath + pic.Path;
                    string description;
                    if (pic.Description == null || pic.Description == "")
                        description = "图片";
                    else
                        description = pic.Description;

                    Twitter twitter = new Twitter(oauth);
                    if (oauth != null)
                    {
                        var data = twitter.Add(description, @path, "127.0.0.1");
                    }
                }

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
