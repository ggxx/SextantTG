using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IServices;
using SextantTG.IDAL;
using SextantTG.ActiveRecord;
using System.Data.Common;

namespace SextantTG.Services
{
    public class PictureService : IPictureService
    {
        private IDataContext dataContext = null;
        private IPictureDAL pictureDal = null;

        public PictureService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            pictureDal = DALFactory.CreateDAL<IPictureDAL>();
        }

        public bool SavePictures(List<Picture> pictures, List<Picture> removedPictures, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (Picture picture in pictures)
                        {
                            if (picture.PictureId.StartsWith("_"))
                            {
                                picture.PictureId = picture.PictureId.Substring(1);
                                pictureDal.InsertPicture(picture, trans);
                            }
                            else
                            {
                                pictureDal.UpdatePicture(picture, trans);
                            }
                        }
                        foreach (Picture picture in removedPictures)
                        {
                            pictureDal.DeletePictureByPictureId(picture.PictureId, trans);
                        }
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public Picture GetPictureByPictureId(string pictureId)
        {
            return pictureDal.GetPictureByPictureId(pictureId);
        }

        public void Dispose()
        {
            dataContext.Dispose();
            pictureDal.Dispose();
        }
    }
}
