﻿using System;
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
        private static readonly ISightsService SightSrv = ServiceFactory.CreateService<ISightsService>();
        private static readonly ITourService tourSrv = ServiceFactory.CreateService<ITourService>();
        private static readonly IUserService userSrv = ServiceFactory.CreateService<IUserService>();
        private static readonly IPictureService pictureSrv = ServiceFactory.CreateService<IPictureService>();
        private static readonly string PicPath = System.Configuration.ConfigurationManager.AppSettings["PIC_PATH"];

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
                else if (property.PropertyType == typeof(List<DTO.SightItem>))
                {
                    WriteModel<DTO.SightItem>(writer, (List<DTO.SightItem>)property.GetValue(model, null));
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
            foreach (XmlNode node in doc.SelectNodes(string.Format("Request/{0}List/{0}", type.Name)))
            {
                T t = new T();
                foreach (PropertyInfo property in type.GetProperties())
                {
                    SetModelProperty(t, property, doc, string.Format("Request/{0}List/{0}[{1}]/{2}", type.Name, list.Count + 1, property.Name));
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
                //property.SetValue(t, XmlUtil.ReadSelectXPath(xml, xpath), null);
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
                List<SightItem> list = new List<SightItem>();
                foreach (Sights sight in SightSrv.GetSights())
                {
                    City city = dictSrv.GetCityByCityId(sight.CityId);
                    Province province = dictSrv.GetProvinceByCityId(sight.CityId);
                    Country country = province != null ? dictSrv.GetCountryByCountryId(province.CountryId) : null;
                    float? stars = SightSrv.GetAverageStarsBySightsId(sight.SightsId);
                    SightItem obj = new SightItem()
                    {
                        CityId = city != null ? city.CityId : "",
                        CityName = city != null ? city.CityName : "",
                        ProvinceId = province != null ? province.ProvinceId : "",
                        ProvinceName = province != null ? province.ProvinceName : "",
                        CountryId = country != null ? country.CountryId : "",
                        CountryName = country != null ? country.CountryName : "",
                        HasVisited = false,
                        SightId = sight.SightsId,
                        SightName = sight.SightsName,
                        SightLevel = sight.SightsLevel,
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
            Sights sight = SightSrv.GetSightsBySightsId(sightId);
            City city = dictSrv.GetCityByCityId(sight.CityId);
            Province province = dictSrv.GetProvinceByCityId(sight.CityId);
            Country country = province != null ? dictSrv.GetCountryByCountryId(province.CountryId) : null;
            float? stars = SightSrv.GetAverageStarsBySightsId(sight.SightsId);
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
                    SightName = SightSrv.GetSightsBySightsId(blog.SightsId).SightsName,
                    SubtourName = tourSrv.GetSubTourByTourIdAndSubTourId(blog.TourId, blog.SubTourId).SubTourName,
                    TourName = tourSrv.GetTourByTourId(blog.TourId).TourName,
                    Title = blog.Title,
                    SightId = blog.SightsId,
                    SubtourId = blog.SubTourId,
                    TourId = blog.TourId,
                    UserId = blog.UserId
                };
                blogList.Add(item);
            }
            foreach (Picture pic in SightSrv.GetPicturesBySightsId(sightId))
            {
                PictureItem item = new PictureItem()
                {
                    CreatingTime = pic.CreatingTime ?? DateTime.MinValue,
                    Description = pic.Description,
                    Path = PicPath + pic.Path,
                    PictureId = pic.PictureId,
                    UploaderName = userSrv.GetUserByUserId(pic.UploaderId).LoginName,
                    SubtourId = pic.SubTourId,
                    TourId = pic.TourId
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
                    CreatingTime = comment.CreatingTime ?? DateTime.MinValue,
                    TargetId = sightId,
                    UserId = comment.CommentUserId
                };
                commentList.Add(item2);
            }

            SightObject sightObject = new SightObject()
            {
                BlogItemList = blogList,
                CityId = sight.CityId,
                CityName = dictSrv.GetCityByCityId(sight.CityId).CityName,
                ProvinceId = province.ProvinceId,
                ProvinceName = province.ProvinceName,
                CountryId = province.CountryId,
                CountryName = dictSrv.GetCountryByProvinceId(province.ProvinceId).CountryName,
                CommentItemList = commentList,
                Description = sight.Description,
                HasVisited = false,
                MyStar = 0,
                PictureItemList = pictureList,
                Price = sight.Price.HasValue ? sight.Price.Value : 0,
                SightId = sight.SightsId,
                SightLevel = sight.SightsLevel,
                SightName = sight.SightsName,
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
                Path = PicPath + pic.Path,
                PictureId = pic.PictureId,
                UploaderName = userSrv.GetUserByUserId(pic.UploaderId).LoginName,
                SightName = SightSrv.GetSightsBySightsId(pic.SightsId).SightsName,
                SubTourName = tourSrv.GetSubTourByTourIdAndSubTourId(pic.TourId, pic.SubTourId).SubTourName,
                TourName = tourSrv.GetTourByTourId(pic.TourId).TourName,
                SubtourId = pic.SubTourId,
                TourId = pic.TourId
            };
            return CreateReturnXmlDocument(item);
        }

        [WebMethod(Description = "获取指定日志")]
        public XmlDocument GetBlogByBlogId(string blogId)
        {
            Blog blog = blogSrv.GetBlogByBlogId(blogId);
            BlogObject item = new BlogObject()
            {
                Anthor = userSrv.GetUserByUserId(blog.UserId).LoginName,
                BlogId = blog.BlogId,
                Content = blog.Content,
                CreatingTime = blog.CreatingTime.HasValue ? blog.CreatingTime.Value : DateTime.MinValue,
                SightName = SightSrv.GetSightsBySightsId(blog.SightsId).SightsName,
                SubtourName = tourSrv.GetSubTourByTourIdAndSubTourId(blog.TourId, blog.SubTourId).SubTourName,
                TourName = tourSrv.GetTourByTourId(blog.TourId).TourName,
                Title = blog.Title,
                SightId = blog.SightsId,
                SubtourId = blog.SubTourId,
                TourId = blog.TourId,
                UserId = blog.UserId,
                IsSync = blog.IsSync == 1
            };
            return CreateReturnXmlDocument(item);
        }

        [WebMethod(Description = "获取所有旅行")]
        public XmlDocument GetToursByUserId(string userId)
        {
            List<TourItem> list = new List<TourItem>();
            foreach (Tour tour in tourSrv.GetToursByUserId(userId))
            {
                TourItem item = new TourItem()
                {
                    EndDate = tour.EndDate.HasValue ? tour.EndDate.Value : DateTime.MinValue,
                    BeginDate = tour.BeginDate.HasValue ? tour.BeginDate.Value : DateTime.MinValue,
                    Status = tour.Status == 0 ? "未进行" : tour.Status == 1 ? "进行中" : tour.Status == 2 ? "已结束" : "",
                    TourId = tour.TourId,
                    TourName = tour.TourName,
                    UserId = tour.UserId
                };
                list.Add(item);
            }
            return CreateReturnXmlDocument(list);
        }

        [WebMethod(Description = "获取指定旅行")]
        public XmlDocument GetTourByTourId(string tourId)
        {
            Tour tour = tourSrv.GetTourByTourId(tourId);
            List<BlogItem> blogList = new List<BlogItem>();
            List<CommentItem> commentList = new List<CommentItem>();
            List<PictureItem> pictureList = new List<PictureItem>();
            List<SubtourItem> subtourList = new List<SubtourItem>();

            foreach (Blog blog in blogSrv.GetBlogsByTourId(tourId))
            {
                BlogItem item = new BlogItem()
                {
                    Anthor = userSrv.GetUserByUserId(blog.UserId).LoginName,
                    BlogId = blog.BlogId,
                    Content = blog.Content,
                    CreatingTime = blog.CreatingTime.HasValue ? blog.CreatingTime.Value : DateTime.MinValue,
                    SightName = SightSrv.GetSightsBySightsId(blog.SightsId).SightsName,
                    SubtourName = tourSrv.GetSubTourByTourIdAndSubTourId(blog.TourId, blog.SubTourId).SubTourName,
                    Title = blog.Title,
                    TourName = tourSrv.GetTourByTourId(blog.TourId).TourName,
                    SightId = blog.SightsId,
                    SubtourId = blog.SubTourId,
                    TourId = blog.TourId,
                    UserId = blog.UserId,
                    IsSync = blog.IsSync == 1
                };
                blogList.Add(item);
            }
            foreach (TourComment comment in commentSrv.GetTourCommentsByTourId(tourId))
            {
                CommentItem item = new CommentItem()
                {
                    Comment = comment.Comment,
                    CommentId = comment.CommentId,
                    CommentUserName = userSrv.GetUserByUserId(comment.CommentUserId).LoginName,
                    CreatingTime = comment.CreatingTime.HasValue ? comment.CreatingTime.Value : DateTime.MinValue,
                    TargetId = comment.TourId,
                    UserId = comment.CommentUserId
                };
                commentList.Add(item);
            }
            foreach (Picture pic in tourSrv.GetPicturesByTourId(tourId))
            {
                PictureItem item = new PictureItem()
                {
                    CreatingTime = pic.CreatingTime ?? DateTime.MinValue,
                    Description = pic.Description,
                    Path = PicPath + pic.Path,
                    PictureId = pic.PictureId,
                    UploaderName = userSrv.GetUserByUserId(pic.UploaderId).LoginName,
                    SubtourId = pic.SubTourId,
                    TourId = pic.TourId
                };
                pictureList.Add(item);
            }
            foreach (SubTour subtour in tourSrv.GetSubToursByTourId(tourId))
            {
                SubtourItem item = new SubtourItem()
                {
                    BeginDate = subtour.BeginDate ?? DateTime.MinValue,
                    EndDate = subtour.EndDate ?? DateTime.MinValue,
                    SightName = SightSrv.GetSightsBySightsId(subtour.SightsId).SightsName,
                    SubtourId = subtour.SubTourId,
                    SubtourName = subtour.SubTourName,
                    TourId = tourId,
                    SightId = subtour.SightsId
                };
                subtourList.Add(item);
            }

            TourObject tourObject = new TourObject()
            {
                BlogItemList = blogList,
                CommentItemList = commentList,
                EndDate = tour.EndDate ?? DateTime.MinValue,
                PictureItemList = pictureList,
                Cost = tour.Cost ?? 0,
                BeginDate = tour.BeginDate ?? DateTime.MinValue,
                Status = tour.Status == 0 ? "未进行" : tour.Status == 1 ? "进行中" : tour.Status == 2 ? "已结束" : "",
                SubtourItemList = subtourList,
                TourId = tour.TourId,
                TourName = tour.TourName,
                UserId = tour.UserId
            };

            return CreateReturnXmlDocument(tourObject);
        }

        [WebMethod(Description = "获取指定子旅行")]
        public XmlDocument GetSubtourByTourIdAndSubtourId(string tourId, string subtourId)
        {
            SubTour subtour = tourSrv.GetSubTourByTourIdAndSubTourId(tourId, subtourId);
            List<BlogItem> blogList = new List<BlogItem>();
            List<PictureItem> pictureList = new List<PictureItem>();

            foreach (Blog blog in blogSrv.GetBlogsByTourIdAndSubTourId(tourId, subtourId))
            {
                BlogItem item = new BlogItem()
                {
                    Anthor = userSrv.GetUserByUserId(blog.UserId).LoginName,
                    BlogId = blog.BlogId,
                    Content = blog.Content,
                    CreatingTime = blog.CreatingTime.HasValue ? blog.CreatingTime.Value : DateTime.MinValue,
                    SightName = SightSrv.GetSightsBySightsId(blog.SightsId).SightsName,
                    SubtourName = tourSrv.GetSubTourByTourIdAndSubTourId(blog.TourId, blog.SubTourId).SubTourName,
                    Title = blog.Title,
                    TourName = tourSrv.GetTourByTourId(blog.TourId).TourName,
                    SightId = blog.SightsId,
                    SubtourId = blog.SubTourId,
                    TourId = blog.TourId,
                    UserId = blog.UserId,
                    IsSync = blog.IsSync == 1
                };
                blogList.Add(item);
            }
            foreach (Picture pic in tourSrv.GetPicturesByTourIdAndSubTourId(tourId, subtourId))
            {
                PictureItem item = new PictureItem()
                {
                    CreatingTime = pic.CreatingTime ?? DateTime.MinValue,
                    Description = pic.Description,
                    Path = PicPath + pic.Path,
                    PictureId = pic.PictureId,
                    UploaderName = userSrv.GetUserByUserId(pic.UploaderId).LoginName,
                    SubtourId = pic.SubTourId,
                    TourId = pic.TourId
                };
                pictureList.Add(item);
            }

            SubtourObject subtourObject = new SubtourObject()
            {
                BeginDate = subtour.BeginDate ?? DateTime.MinValue,
                BlogItemList = blogList,
                EndDate = subtour.EndDate ?? DateTime.MinValue,
                PictureItemList = pictureList,
                SightName = SightSrv.GetSightsBySightsId(subtour.SightsId).SightsName,
                SubtourId = subtourId,
                SubtourName = subtour.SubTourName,
                TourId = tourId
            };

            return CreateReturnXmlDocument(subtourObject);
        }


        [WebMethod(Description = "获取所有景点(已登录)")]
        public XmlDocument GetSights2(string userId)
        {
            try
            {
                List<SightItem> list = new List<SightItem>();
                foreach (Sights sight in SightSrv.GetSights())
                {
                    City city = dictSrv.GetCityByCityId(sight.CityId);
                    Province province = dictSrv.GetProvinceByCityId(sight.CityId);
                    Country country = province != null ? dictSrv.GetCountryByCountryId(province.CountryId) : null;
                    float? stars = SightSrv.GetAverageStarsBySightsId(sight.SightsId);
                    SightItem obj = new SightItem()
                    {
                        CityId = city != null ? city.CityId : "",
                        CityName = city != null ? city.CityName : "",
                        ProvinceId = province != null ? province.ProvinceId : "",
                        ProvinceName = province != null ? province.ProvinceName : "",
                        CountryId = country != null ? country.CountryId : "",
                        CountryName = country != null ? country.CountryName : "",
                        HasVisited = userSrv.GetFavoriteByUserIdAndSightsId(userId, sight.SightsId) != null,
                        SightId = sight.SightsId,
                        SightName = sight.SightsName,
                        SightLevel = sight.SightsLevel,
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
            Sights sight = SightSrv.GetSightsBySightsId(sightId);
            City city = dictSrv.GetCityByCityId(sight.CityId);
            Province province = dictSrv.GetProvinceByCityId(sight.CityId);
            Country country = province != null ? dictSrv.GetCountryByCountryId(province.CountryId) : null;
            Favorite fav = userSrv.GetFavoriteByUserIdAndSightsId(userId, sightId);
            float? stars = SightSrv.GetAverageStarsBySightsId(sight.SightsId);
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
                    SightName = SightSrv.GetSightsBySightsId(blog.SightsId).SightsName,
                    SubtourName = tourSrv.GetSubTourByTourIdAndSubTourId(blog.TourId, blog.SubTourId).SubTourName,
                    TourName = tourSrv.GetTourByTourId(blog.TourId).TourName,
                    Title = blog.Title,
                    SightId = blog.SightsId,
                    SubtourId = blog.SubTourId,
                    TourId = blog.TourId,
                    UserId = blog.UserId,
                    IsSync = blog.IsSync == 1
                };
                blogList.Add(item);
            }
            foreach (Picture pic in SightSrv.GetPicturesBySightsId(sightId))
            {
                PictureItem item = new PictureItem()
                {
                    CreatingTime = pic.CreatingTime ?? DateTime.MinValue,
                    Description = pic.Description,
                    Path = PicPath + pic.Path,
                    PictureId = pic.PictureId,
                    UploaderName = userSrv.GetUserByUserId(pic.UploaderId).LoginName,
                    SubtourId = pic.SubTourId,
                    TourId = pic.TourId
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
                    CreatingTime = comment.CreatingTime.HasValue ? comment.CreatingTime.Value : DateTime.MinValue,
                    TargetId = sightId,
                    UserId = comment.CommentUserId
                };
                commentList.Add(item2);
            }

            SightObject sightObject = new SightObject()
            {
                BlogItemList = blogList,
                CityId = sight.CityId,
                CityName = dictSrv.GetCityByCityId(sight.CityId).CityName,
                ProvinceId = province.ProvinceId,
                ProvinceName = province.ProvinceName,
                CountryId = province.CountryId,
                CountryName = dictSrv.GetCountryByProvinceId(province.ProvinceId).CountryName,
                CommentItemList = commentList,
                Description = sight.Description,
                HasVisited = fav != null ? fav.Visited == 1 : false,
                MyStar = fav != null ? fav.Stars.HasValue ? fav.Stars.Value : 0 : 0,
                PictureItemList = pictureList,
                Price = sight.Price.HasValue ? sight.Price.Value : 0,
                SightId = sight.SightsId,
                SightLevel = sight.SightsLevel,
                SightName = sight.SightsName,
                Stars = stars ?? 0
            };

            return CreateReturnXmlDocument(sightObject);
        }



        [WebMethod(Description = "获取所有国家")]
        public XmlDocument GetCountries()
        {
            try
            {
                List<CountryItem> items = new List<CountryItem>();
                foreach (Country country in dictSrv.GetCountries())
                {
                    CountryItem item = new CountryItem()
                    {
                        CountryId = country.CountryId,
                        CountryName = country.CountryName
                    };
                    items.Add(item);
                }
                return CreateReturnXmlDocument(items);
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取所有省份")]
        public XmlDocument GetProvinces()
        {
            try
            {
                List<ProvinceItem> items = new List<ProvinceItem>();
                foreach (Province province in dictSrv.GetProvinces())
                {
                    ProvinceItem item = new ProvinceItem()
                    {
                        CountryId = province.CountryId,
                        CountryName = dictSrv.GetCountryByProvinceId(province.ProvinceId).CountryName,
                        ProvinceId = province.ProvinceId,
                        ProvinceName = province.ProvinceName
                    };
                    items.Add(item);
                }
                return CreateReturnXmlDocument(items);
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取所有城市")]
        public XmlDocument GetCities()
        {
            try
            {
                List<CityItem> items = new List<CityItem>();
                foreach (City city in dictSrv.GetCities())
                {
                    Province province = dictSrv.GetProvinceByCityId(city.CityId);
                    Country country = dictSrv.GetCountryByProvinceId(province.ProvinceId);
                    CityItem item = new CityItem()
                    {
                        CityId = city.CityId,
                        CityName = city.CityName,
                        CountryId = country.CountryId,
                        CountryName = country.CountryName,
                        ProvinceId = province.ProvinceId,
                        ProvinceName = province.ProvinceName
                    };
                    items.Add(item);
                }
                return CreateReturnXmlDocument(items);
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "保存旅行")]
        public XmlDocument SaveTour(string tourString, string subtoursString, string removedSubtoursString)
        {
            try
            {
                TourObject tourObject = ReadModel<TourObject>(tourString);
                List<SubtourItem> subtours = ReadModelList<SubtourItem>(subtoursString);
                List<SubtourItem> removedSubtours = ReadModelList<SubtourItem>(removedSubtoursString);
                Tour tour = new Tour()
                {
                    BeginDate = tourObject.BeginDate,
                    Cost = tourObject.Cost,
                    CreatingTime = System.DateTime.Now,
                    EndDate = tourObject.EndDate,
                    Memos = "",
                    Status = tourObject.Status == "未进行" ? 0 : tourObject.Status == "进行中" ? 1 : 2,
                    TourId = tourObject.TourId,
                    TourName = tourObject.TourName,
                    UserId = tourObject.UserId
                };
                List<SubTour> subtourList = new List<SubTour>();
                List<SubTour> rmSubtourList = new List<SubTour>();
                foreach (SubtourItem item in subtours)
                {
                    SubTour subtour = new SubTour()
                    {
                        BeginDate = item.BeginDate,
                        CreatingTime = System.DateTime.Now,
                        EndDate = item.EndDate,
                        Memos = "",
                        SightsId = item.SightId,
                        SubTourId = item.SubtourId,
                        SubTourName = item.SubtourName,
                        TourId = item.TourId
                    };
                    subtourList.Add(subtour);
                }
                foreach (SubtourItem item in removedSubtours)
                {
                    SubTour subtour = new SubTour()
                    {
                        BeginDate = item.BeginDate,
                        CreatingTime = System.DateTime.Now,
                        EndDate = item.EndDate,
                        Memos = "",
                        SightsId = item.SightId,
                        SubTourId = item.SubtourId,
                        SubTourName = item.SubtourName,
                        TourId = item.TourId
                    };
                    rmSubtourList.Add(subtour);
                }
                string msg;
                if (tourSrv.SaveTour(tour, subtourList, rmSubtourList, out msg))
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

        [WebMethod(Description = "删除旅行")]
        public XmlDocument DeleteTour(string tourId, bool deletePictures)
        {
            try
            {
                string msg;
                if (tourSrv.DeleteTour(tourSrv.GetTourByTourId(tourId), deletePictures, out msg))
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

        [WebMethod(Description = "添加评论")]
        public XmlDocument InsertTourComment(string commentString)
        {
            try
            {
                CommentItem item = ReadModel<CommentItem>(commentString);
                TourComment comment = new TourComment()
                {
                    Comment = item.Comment,
                    CommentId = item.CommentId,
                    CommentUserId = item.UserId,
                    CreatingTime = DateTime.Now,
                    TourId = item.TargetId,
                };
                string msg;

                if (commentSrv.InsertTourComment(comment, out msg))
                {
                    return CreateReturnXmlDocument(true);
                }
                else
                {
                    return CreateErrorXmlDocument(new Exception(msg));
                }
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "撰写日志")]
        public XmlDocument InsertBlog(string blogString)
        {
            try
            {
                BlogObject item = ReadModel<BlogObject>(blogString);
                string msg;
                Blog blog = new Blog()
                {
                    BlogId = item.BlogId,
                    Content = item.Content,
                    CreatingTime = System.DateTime.Now,
                    SightsId = item.SightId,
                    SubTourId = item.SubtourId,
                    Title = item.Title,
                    TourId = item.TourId,
                    UserId = item.UserId,
                    IsSync = item.IsSync ? 1 : 0
                };
                if (blogSrv.SaveBlog(blog, out msg))
                {
                    return CreateReturnXmlDocument(true);
                }
                else
                {
                    return CreateErrorXmlDocument(new Exception(msg));
                }
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }


        //public XmlDocument SyncBlog(string blogId)
        //{

        //}

        [WebMethod(Description = "上传图片")]
        public XmlDocument UploadPicture(string pictureString, string base64code)
        {
            return null;
            //PictureItem pic = ReadModel<PictureItem>(pictureString);
            //byte[] bytes = Convert.FromBase64String(base64code);

            //pic.Path = Util.StringHelper.CreateGuid();

            //File.WriteAllBytes(PicPath + pic.Path, bytes);
            //return CreateReturnXmlDocument(true);
            //ltResult2.Text = Encoding.Default.GetString(bytes);
        }
    }
}
