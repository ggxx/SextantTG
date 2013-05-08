using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text;
using SextantTG.IServices;
using System.Reflection;
using SextantTG.ActiveRecord;
using System.IO;
using SextantTG.WebServices.DTO;

namespace SextantTG.WebServices
{
    /// <summary>
    /// WS2 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://github.com/ggxx/SextantTG/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WS2 : System.Web.Services.WebService
    {
        private static readonly string WebServiceNamespace = "http://github.com/ggxx/SextantTG/";

        private static readonly IBlogService blogSrv = ServiceFactory.CreateService<IBlogService>();
        private static readonly IDictService dictSrv = ServiceFactory.CreateService<IDictService>();
        private static readonly ICommentService commentSrv = ServiceFactory.CreateService<ICommentService>();
        private static readonly ISightsService sightsSrv = ServiceFactory.CreateService<ISightsService>();
        private static readonly ITourService tourSrv = ServiceFactory.CreateService<ITourService>();
        private static readonly IUserService userSrv = ServiceFactory.CreateService<IUserService>();
        private static readonly IPictureService pictureSrv = ServiceFactory.CreateService<IPictureService>();

        private static XmlWriterSettings settings = null;

        public WS2()
        {
            settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = new UTF8Encoding(false);
            settings.NewLineOnAttributes = true;
        }


        #region Read and Write XML Document

        private static void WriteModel<T>(XmlWriter writer, List<T> list) where T : DTO.DTO
        {
            Type type = typeof(T);
            writer.WriteStartElement(type.Name + "List");
            if (list != null)
            {
                foreach (T model in list)
                {
                    writer.WriteStartElement(type.Name);
                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        XmlUtil.WriteElement(writer, property.Name, property.GetValue(model, null));
                    }
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        private static void WriteModel<T>(XmlWriter writer, T model) where T : DTO.DTO
        {
            Type type = typeof(T);
            writer.WriteStartElement(type.Name);
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.PropertyType == typeof(List<DTO.BlogItem>))
                {
                    WriteModel<DTO.BlogItem>(writer, (List<DTO.BlogItem>)property.GetValue(model, null));
                }
                else if (property.PropertyType == typeof(List<DTO.CommentItem>))
                {
                    WriteModel<DTO.CommentItem>(writer, (List<DTO.CommentItem>)property.GetValue(model, null));
                }
                else if (property.PropertyType == typeof(List<DTO.PictureItem>))
                {
                    WriteModel<DTO.PictureItem>(writer, (List<DTO.PictureItem>)property.GetValue(model, null));
                }
                else if (property.PropertyType == typeof(List<DTO.SightsItem>))
                {
                    WriteModel<DTO.SightsItem>(writer, (List<DTO.SightsItem>)property.GetValue(model, null));
                }
                else if (property.PropertyType == typeof(List<DTO.SubtourItem>))
                {
                    WriteModel<DTO.SubtourItem>(writer, (List<DTO.SubtourItem>)property.GetValue(model, null));
                }
                else if (property.PropertyType == typeof(List<DTO.TourItem>))
                {
                    WriteModel<DTO.TourItem>(writer, (List<DTO.TourItem>)property.GetValue(model, null));
                }
                else
                {
                    XmlUtil.WriteElement(writer, property.Name, property.GetValue(model, null));
                }
            }
            writer.WriteEndElement();
        }

        private static void WriteModel(XmlWriter writer, string name, Dictionary<int, string> dict)
        {
            writer.WriteStartElement(name + "List");
            if (dict != null)
            {
                foreach (KeyValuePair<int, string> kvp in dict)
                {
                    writer.WriteStartElement(name);
                    XmlUtil.WriteElement(writer, "Key", kvp.Key);
                    XmlUtil.WriteElement(writer, "Value", kvp.Value);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        private static T ReadModel<T>(string input) where T : DTO.DTO, new()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(input);

            Type type = typeof(T);
            T t = new T();
            foreach (PropertyInfo property in type.GetProperties())
            {
                SetModelProperty(t, property, doc, string.Format("Request/{0}/{1}", type.Name, property.Name));
            }
            return t;
        }

        private static List<T> ReadModelList<T>(string input) where T : DTO.DTO, new()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(input);

            Type type = typeof(T);
            List<T> list = new List<T>();
            foreach (XmlNode node in doc.SelectNodes(string.Format("Request/{0}List", type.Name)))
            {
                T t = new T();
                foreach (PropertyInfo property in type.GetProperties())
                {
                    SetModelProperty(t, property, doc, string.Format("Request/{0}/{1}", type.Name, property.Name));
                }
                list.Add(t);
            }
            return list;
        }

        private static void SetModelProperty<T>(T t, PropertyInfo property, XmlDocument xml, string xpath)
        {
            if (property.PropertyType == typeof(int?) || property.PropertyType == typeof(int))
            {
                property.SetValue(t, XmlUtil.ReadSelectXPathInt(xml, xpath), null);
            }
            else if (property.PropertyType == typeof(float?) || property.PropertyType == typeof(float))
            {
                property.SetValue(t, XmlUtil.ReadSelectXPathFloat(xml, xpath), null);
            }
            else if (property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime))
            {
                property.SetValue(t, XmlUtil.ReadSelectXPathDateTime(xml, xpath), null);
            }
            else if (property.PropertyType == typeof(bool?) || property.PropertyType == typeof(bool))
            {
                property.SetValue(t, XmlUtil.ReadSelectXPathBoolean(xml, xpath), null);
            }
            else if (property.PropertyType == typeof(string))
            {
                property.SetValue(t, XmlUtil.ReadSelectXPathString(xml, xpath), null);
            }
            else
            {
                property.SetValue(t, XmlUtil.ReadSelectXPath(xml, xpath), null);
            }
        }

        private static XmlDocument CreateReturnXmlDocument(bool val)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriter writer = XmlWriter.Create(ms, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Response", WebServiceNamespace);
                XmlUtil.WriteElement(writer, "Message", "");
                writer.WriteStartElement("Result");

                XmlUtil.WriteElement(writer, "Value", val);

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
                return doc;
            }

        }

        private static XmlDocument CreateReturnXmlDocument(int? val)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriter writer = XmlWriter.Create(ms, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Response", WebServiceNamespace);
                XmlUtil.WriteElement(writer, "Message", "");
                writer.WriteStartElement("Result");

                XmlUtil.WriteElement(writer, "Value", val);

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
                return doc;
            }
        }

        private static XmlDocument CreateReturnXmlDocument(float? val)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriter writer = XmlWriter.Create(ms, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Response", WebServiceNamespace);
                XmlUtil.WriteElement(writer, "Message", "");
                writer.WriteStartElement("Result");

                XmlUtil.WriteElement(writer, "Value", val);

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
                return doc;
            }
        }

        private static XmlDocument CreateReturnXmlDocument(string val)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriter writer = XmlWriter.Create(ms, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Response", WebServiceNamespace);
                XmlUtil.WriteElement(writer, "Message", "");
                writer.WriteStartElement("Result");

                XmlUtil.WriteElement(writer, "Value", val);

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
                return doc;
            }
        }

        private static XmlDocument CreateReturnXmlDocument<T>(List<T> list) where T : DTO.DTO
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriter writer = XmlWriter.Create(ms, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Response", WebServiceNamespace);
                XmlUtil.WriteElement(writer, "Message", "");
                writer.WriteStartElement("Result");

                WriteModel(writer, list);

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
                return doc;
            }
        }

        private static XmlDocument CreateReturnXmlDocument<T>(T model) where T : DTO.DTO
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriter writer = XmlWriter.Create(ms, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Response", WebServiceNamespace);
                XmlUtil.WriteElement(writer, "Message", "");
                writer.WriteStartElement("Result");

                WriteModel(writer, model);

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
                return doc;
            }
        }

        private static XmlDocument CreateReturnXmlDocument(string name, Dictionary<int, string> dict)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriter writer = XmlWriter.Create(ms, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Response", WebServiceNamespace);
                XmlUtil.WriteElement(writer, "Message", "");
                writer.WriteStartElement("Result");

                WriteModel(writer, name, dict);

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
                return doc;
            }
        }

        private static XmlDocument CreateErrorXmlDocument(Exception ex)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                string err = "unkown error";
                if (ex != null && !string.IsNullOrEmpty(ex.Message))
                {
                    err = ex.Message;
                }

                XmlWriter writer = XmlWriter.Create(ms, settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("Response", WebServiceNamespace);
                XmlUtil.WriteElement(writer, "Message", err);
                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                writer.Close();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
                return doc;
            }
        }

        #endregion


        [WebMethod(Description = "测试")]
        public XmlDocument HelloWorld()
        {
            try
            {
                return CreateReturnXmlDocument("Hello World");
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "用户登录")]
        public XmlDocument Login(string loginName, string password)
        {
            try
            {
                User user = userSrv.Login(loginName, password);

                if (user == null)
                {
                    throw new Exception("用户名或口令错误");
                }
                if (user.Status != 0)
                {
                    throw new Exception("用户帐户被冻结");
                }

                UserObject userObject = new UserObject()
                {
                    UserId = user.UserId,
                    LoginName = user.LoginName,
                    Email = user.Email,
                    Status = user.Status
                };

                return CreateReturnXmlDocument(userObject);
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "用户注册")]
        public XmlDocument Regist(string userString, string password)
        {
            try
            {
                UserObject userObject = ReadModel<UserObject>(userString);
                User user = new User()
                {
                    UserId = userObject.UserId,
                    LoginName = userObject.LoginName,
                    Email = userObject.Email,
                    Status = userObject.Status
                };
                string msg;
                if (userSrv.InsertUser(user, password, out msg))
                {
                    return CreateReturnXmlDocument(true);
                }
                else
                {
                    throw new Exception(msg);
                }
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取所有景点(未登录)")]
        public XmlDocument GetSights()
        {
            try
            {
                List<SightsItem> list = new List<SightsItem>();
                foreach (Sights sights in sightsSrv.GetSights())
                {
                    City city = dictSrv.GetCityByCityId(sights.CityId);
                    Province province = dictSrv.GetProvinceByCityId(sights.CityId);
                    Country country = province != null ? dictSrv.GetCountryByCountryId(province.CountryId) : null;
                    float? stars = sightsSrv.GetAverageStarsBySightsId(sights.SightsId);
                    SightsItem obj = new SightsItem()
                    {
                        CityName = city != null ? city.CityName : "",
                        ProvinceName = province != null ? province.ProvinceName : "",
                        CountryName = country != null ? country.CountryName : "",
                        HasVisited = false,
                        SightsId = sights.SightsId,
                        SightsName = sights.SightsName,
                        SightsLevel = sights.SightsLevel,
                        Stars = stars ?? 0
                    };
                    list.Add(obj);
                }
                return CreateReturnXmlDocument(list);
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定景点(未登录)")]
        public XmlDocument GetSightBySightId(string sightId)
        {
            Sights sights = sightsSrv.GetSightsBySightsId(sightId);
            City city = dictSrv.GetCityByCityId(sights.CityId);
            Province province = dictSrv.GetProvinceByCityId(sights.CityId);
            Country country = province != null ? dictSrv.GetCountryByCountryId(province.CountryId) : null;
            float? stars = sightsSrv.GetAverageStarsBySightsId(sights.SightsId);
            List<BlogItem> blogList = new List<BlogItem>();
            List<PictureItem> pictureList = new List<PictureItem>();
            List<CommentItem> commentList = new List<CommentItem>();

            foreach (Blog blog in blogSrv.GetBlogsBySightsId(sightId))
            {
                BlogItem item = new BlogItem()
                {
                    Anthor = userSrv.GetUserByUserId(blog.UserId).LoginName,
                    BlogId = blog.BlogId,
                    Content = blog.Content,
                    CreatingTime = blog.CreatingTime.HasValue ? blog.CreatingTime.Value : DateTime.MinValue,
                    SightName = sightsSrv.GetSightsBySightsId(blog.SightsId).SightsName,
                    SubtourName = tourSrv.GetSubTourByTourIdAndSubTourId(blog.TourId, blog.SubTourId).SubTourName,
                    TourName = tourSrv.GetTourByTourId(blog.TourId).TourName,
                    Title = blog.Title,
                };
                blogList.Add(item);
            }
            foreach (Picture pic in sightsSrv.GetPicturesBySightsId(sightId))
            {
                PictureItem item = new PictureItem()
                {
                    CreatingTime = pic.CreatingTime,
                    Description = pic.Description,
                    Path = pic.Path,
                    PictureId = pic.PictureId,
                    UploaderName = userSrv.GetUserByUserId(pic.UploaderId).LoginName
                };
                pictureList.Add(item);
            }
            foreach (SightsComment comment in commentSrv.GetSightsCommentsBySightsId(sightId))
            {
                CommentItem item2 = new CommentItem()
                {
                    Comment = comment.Comment,
                    CommentId = comment.CommentId,
                    CommentUserName = userSrv.GetUserByUserId(comment.CommentUserId).LoginName,
                    CreatingTime = comment.CreatingTime.HasValue ? comment.CreatingTime : DateTime.MinValue,
                    TargetId = sightId
                };
                commentList.Add(item2);
            }

            SightsObject sightObject = new SightsObject()
            {
                BlogList = blogList,
                CityName = dictSrv.GetCityByCityId(sights.CityId).CityName,
                ProvinceName = province.ProvinceName,
                CountryName = dictSrv.GetCountryByProvinceId(province.ProvinceId).CountryName,
                CommentList = commentList,
                Description = sights.Description,
                HasVisited = false,
                MyStar = 0,
                PictureList = pictureList,
                Price = sights.Price.HasValue ? sights.Price.Value : 0,
                SightsId = sights.SightsId,
                SightsLevel = sights.SightsLevel,
                SightsName = sights.SightsName,
                Stars = stars ?? 0
            };

            return CreateReturnXmlDocument(sightObject);
        }

        [WebMethod(Description = "获取指定图片")]
        public XmlDocument GetPictureByPictureId(string pictureId)
        {
            Picture pic = pictureSrv.GetPictureByPictureId(pictureId);
            PictureObject item = new PictureObject()
            {
                CreatingTime = pic.CreatingTime,
                Description = pic.Description,
                Path = pic.Path,
                PictureId = pic.PictureId,
                UploaderName = userSrv.GetUserByUserId(pic.UploaderId).LoginName
            };
            return CreateReturnXmlDocument(item);
        }

        [WebMethod(Description = "获取指定日志")]
        public XmlDocument GetBlogByBlogId(string blogId)
        {
            Blog blog = blogSrv.GetBlogByBlogId(blogId);
            BlogItem item = new BlogItem()
            {
                Anthor = userSrv.GetUserByUserId(blog.UserId).LoginName,
                BlogId = blog.BlogId,
                Content = blog.Content,
                CreatingTime = blog.CreatingTime.HasValue ? blog.CreatingTime.Value : DateTime.MinValue,
                SightName = sightsSrv.GetSightsBySightsId(blog.SightsId).SightsName,
                SubtourName = tourSrv.GetSubTourByTourIdAndSubTourId(blog.TourId, blog.SubTourId).SubTourName,
                TourName = tourSrv.GetTourByTourId(blog.TourId).TourName,
                Title = blog.Title,
            };
            return CreateReturnXmlDocument(item);
        }












        [WebMethod(Description = "获取所有景点(已登录)")]
        public XmlDocument GetSights2(string userId)
        {
            try
            {
                List<SightsItem> list = new List<SightsItem>();
                foreach (Sights sights in sightsSrv.GetSights())
                {
                    City city = dictSrv.GetCityByCityId(sights.CityId);
                    Province province = dictSrv.GetProvinceByCityId(sights.CityId);
                    Country country = province != null ? dictSrv.GetCountryByCountryId(province.CountryId) : null;
                    float? stars = sightsSrv.GetAverageStarsBySightsId(sights.SightsId);
                    SightsItem obj = new SightsItem()
                    {
                        CityName = city != null ? city.CityName : "",
                        ProvinceName = province != null ? province.ProvinceName : "",
                        CountryName = country != null ? country.CountryName : "",
                        HasVisited = userSrv.GetFavoriteByUserIdAndSightsId(userId, sights.SightsId) != null,
                        SightsId = sights.SightsId,
                        SightsName = sights.SightsName,
                        SightsLevel = sights.SightsLevel,
                        Stars = stars.HasValue ? stars.Value : 0
                    };
                    list.Add(obj);
                }
                return CreateReturnXmlDocument(list);
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定景点(已登录)")]
        public XmlDocument GetSightBySightId2(string sightId, string userId)
        {
            Sights sights = sightsSrv.GetSightsBySightsId(sightId);
            City city = dictSrv.GetCityByCityId(sights.CityId);
            Province province = dictSrv.GetProvinceByCityId(sights.CityId);
            Country country = province != null ? dictSrv.GetCountryByCountryId(province.CountryId) : null;
            Favorite fav = userSrv.GetFavoriteByUserIdAndSightsId(userId, sightId);
            float? stars = sightsSrv.GetAverageStarsBySightsId(sights.SightsId);
            List<BlogItem> blogList = new List<BlogItem>();
            List<PictureItem> pictureList = new List<PictureItem>();
            List<CommentItem> commentList = new List<CommentItem>();

            foreach (Blog blog in blogSrv.GetBlogsBySightsId(sightId))
            {
                BlogItem item = new BlogItem()
                {
                    Anthor = userSrv.GetUserByUserId(blog.UserId).LoginName,
                    BlogId = blog.BlogId,
                    Content = blog.Content,
                    CreatingTime = blog.CreatingTime.HasValue ? blog.CreatingTime.Value : DateTime.MinValue,
                    SightName = sightsSrv.GetSightsBySightsId(blog.SightsId).SightsName,
                    SubtourName = tourSrv.GetSubTourByTourIdAndSubTourId(blog.TourId, blog.SubTourId).SubTourName,
                    TourName = tourSrv.GetTourByTourId(blog.TourId).TourName,
                    Title = blog.Title,
                };
                blogList.Add(item);
            }
            foreach (Picture pic in sightsSrv.GetPicturesBySightsId(sightId))
            {
                PictureItem item = new PictureItem()
                {
                    CreatingTime = pic.CreatingTime,
                    Description = pic.Description,
                    Path = pic.Path,
                    PictureId = pic.PictureId,
                    UploaderName = userSrv.GetUserByUserId(pic.UploaderId).LoginName
                };
                pictureList.Add(item);
            }
            foreach (SightsComment comment in commentSrv.GetSightsCommentsBySightsId(sightId))
            {
                CommentItem item2 = new CommentItem()
                {
                    Comment = comment.Comment,
                    CommentId = comment.CommentId,
                    CommentUserName = userSrv.GetUserByUserId(comment.CommentUserId).LoginName,
                    CreatingTime = comment.CreatingTime.HasValue ? comment.CreatingTime : DateTime.MinValue,
                    TargetId = sightId
                };
                commentList.Add(item2);
            }

            SightsObject sightObject = new SightsObject()
            {
                BlogList = blogList,
                CityName = dictSrv.GetCityByCityId(sights.CityId).CityName,
                ProvinceName = province.ProvinceName,
                CountryName = dictSrv.GetCountryByProvinceId(province.ProvinceId).CountryName,
                CommentList = commentList,
                Description = sights.Description,
                HasVisited = fav != null ? fav.Visited == 1 : false,
                MyStar = fav != null ? fav.Stars.HasValue ? fav.Stars.Value : 0 : 0,
                PictureList = pictureList,
                Price = sights.Price.HasValue ? sights.Price.Value : 0,
                SightsId = sights.SightsId,
                SightsLevel = sights.SightsLevel,
                SightsName = sights.SightsName,
                Stars = stars ?? 0
            };

            return CreateReturnXmlDocument(sightObject);
        }
    }
}
