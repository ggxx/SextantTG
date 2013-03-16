using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    public interface IPictureService : IBaseService
    {
        bool SavePictures(List<Picture> pictures, List<Picture> removedPictures, out string message);
        Picture GetPictureByPictureId(string pictureId);
    }
}
