using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using System.Diagnostics;
using System.IO;

namespace SextantTG.Assertion
{
    public class AssertionApi
    {
        public static void AssertForSights(Sights sights)
        {
            Debug.Assert(!string.IsNullOrEmpty(sights.SightsName), "景点名称不能为空！");
            Debug.Assert(!string.IsNullOrEmpty(sights.CityId), "所属城市不能为空！");
            Debug.Assert(!string.IsNullOrEmpty(sights.SightsLevel), "景点等级不能为空！");
            Debug.Assert(sights.SightsName.Length <= 20, "景点名称不能超过20个字符！");
        }

        public static void AssertForTour(Tour tour)
        {
            Debug.Assert(!string.IsNullOrEmpty(tour.TourName), "旅行名称不能为空！");
            Debug.Assert(tour.TourName.Length <= 20, "旅行名称不能超过20个字符！");
            Debug.Assert((tour.BeginDate <= tour.EndDate), "旅行时间错误！");     
        }

        public static void AssertForUser(string password)
        {
            if (password.Length < 5)
            {
                Debug.Assert(false, "密码太短！要求不小于5个字符");
            }
            else if (password.Length > 30)
            {
                Debug.Assert(false, "密码太长！要求不大于30个字符");
            }
        }

        public static void AssertForPicture(Picture pic)
        {
            FileInfo file = new FileInfo(pic.Path);
            string fileExtension = file.Extension;
            if (fileExtension != "jpg" || fileExtension != "BMP" || fileExtension != "PNG" || fileExtension != "JPEG" || fileExtension != "GIF" || fileExtension != "TIFF")
                Debug.Assert(false, "照片格式错误！");
        }
    }
}
