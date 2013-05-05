using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SextantTG.IServices;
using SextantTG.ActiveRecord;
using System.IO;
using System.Xml;
using System.Text;
using System.Reflection;

namespace SextantTG.WebServices
{
    /// <summary>
    /// WS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://github.com/ggxx/SextantTG/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WS : System.Web.Services.WebService
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

        public WS()
        {
            settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = new UTF8Encoding(false);
            settings.NewLineOnAttributes = true;
        }


        #region Read and Write XML Document

        private void WriteModel<T>(XmlWriter writer, List<T> list) where T : BaseAR
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

        private void WriteModel<T>(XmlWriter writer, T model) where T : BaseAR
        {
            Type type = typeof(T);
            writer.WriteStartElement(type.Name);
            foreach (PropertyInfo property in type.GetProperties())
            {
                XmlUtil.WriteElement(writer, property.Name, property.GetValue(model, null));
            }
            writer.WriteEndElement();
        }

        private void WriteModel(XmlWriter writer, string name, Dictionary<int, string> dict)
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

        private T ReadModel<T>(string input) where T : BaseAR, new()
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

        private List<T> ReadModelList<T>(string input) where T : BaseAR, new()
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

        private void SetModelProperty<T>(T t, PropertyInfo property, XmlDocument xml, string xpath)
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

        private XmlDocument CreateReturnXmlDocument(bool val)
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

        private XmlDocument CreateReturnXmlDocument(int? val)
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

        private XmlDocument CreateReturnXmlDocument(float? val)
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

        private XmlDocument CreateReturnXmlDocument(string val)
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

        private XmlDocument CreateReturnXmlDocument<T>(List<T> list) where T : BaseAR
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

        private XmlDocument CreateReturnXmlDocument<T>(T model) where T : BaseAR
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

        private XmlDocument CreateReturnXmlDocument(string name, Dictionary<int, string> dict)
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

        private XmlDocument CreateErrorXmlDocument(Exception ex)
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


        #region Test Service

        [WebMethod(Description = "测试Web Service")]
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

        #endregion


        #region User Service

        [WebMethod(Description = "获取所有用户")]
        public XmlDocument GetUsers()
        {
            try
            {
                return CreateReturnXmlDocument(userSrv.GetUsers());
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
                return CreateReturnXmlDocument(userSrv.Login(loginName, password));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定用户")]
        public XmlDocument GetUserByLoginName(string loginName)
        {
            try
            {
                return CreateReturnXmlDocument(userSrv.GetUserByLoginName(loginName));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定用户")]
        public XmlDocument GetUserByEmail(string email)
        {
            try
            {
                return CreateReturnXmlDocument(userSrv.GetUserByEmail(email));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定用户")]
        public XmlDocument GetUserByUserId(string userId)
        {
            try
            {
                return CreateReturnXmlDocument(userSrv.GetUserByUserId(userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取用户权限列表")]
        public XmlDocument GetPermissionsByUserId(string userId)
        {
            try
            {
                return CreateReturnXmlDocument(userSrv.GetPermissionsByUserId(userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "新增用户")]
        public XmlDocument InsertUser(string inputUser, string password)
        {
            try
            {
                User user = ReadModel<User>(inputUser);
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

        [WebMethod(Description = "更新用户")]
        public XmlDocument UpdateUser(string inputUser)
        {
            try
            {
                User user = ReadModel<User>(inputUser);
                string msg;
                if (userSrv.UpdateUser(user, out msg))
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

        [WebMethod(Description = "获取用户收藏景点")]
        public XmlDocument GetFavoritesByUserId(string userId)
        {
            try
            {
                return CreateReturnXmlDocument(userSrv.GetFavoritesByUserId(userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定的收藏景点")]
        public XmlDocument GetFavoriteByUserIdAndSightsId(string userId, string sightsId)
        {
            try
            {
                return CreateReturnXmlDocument(userSrv.GetFavoriteByUserIdAndSightsId(userId, sightsId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "更新用户权限")]
        public XmlDocument UpdatePermissionsByUserId(string userId, string inputPermissions)
        {
            try
            {
                string msg = "";
                List<Permission> permissions = ReadModelList<Permission>(inputPermissions);
                if (userSrv.UpdatePermissionsByUserId(userId, permissions, out msg))
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

        [WebMethod(Description = "保存用户收藏景点")]
        public XmlDocument SaveFavorite(string inputFavorite)
        {
            try
            {
                string msg;
                Favorite favorite = ReadModel<Favorite>(inputFavorite);
                if (userSrv.SaveFavorite(favorite, out msg))
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

        #endregion


        #region Blog Service

        [WebMethod(Description = "获取指定用户的所有日志")]
        public XmlDocument GetBlogsByUserId(string userId)
        {
            try
            {
                return CreateReturnXmlDocument(blogSrv.GetBlogsByUserId(userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定景点的所有日志")]
        public XmlDocument GetBlogsBySightsId(string sightsId)
        {
            try
            {
                return CreateReturnXmlDocument(blogSrv.GetBlogsBySightsId(sightsId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定用户与指定景点的所有日志")]
        public XmlDocument GetBlogsByUserIdAndSightsId(string userId, string sightsId)
        {
            try
            {
                return CreateReturnXmlDocument(blogSrv.GetBlogsByUserIdAndSightsId(userId, sightsId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定旅行的所有相关日志")]
        public XmlDocument GetBlogsByTourIdAndSubTourId(string tourId, string subTourId)
        {
            try
            {
                return CreateReturnXmlDocument(blogSrv.GetBlogsByTourIdAndSubTourId(tourId, subTourId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定日志")]
        public XmlDocument GetBlogByBlogId(string blogId)
        {
            try
            {
                return CreateReturnXmlDocument(blogSrv.GetBlogByBlogId(blogId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定旅行的所有相关日志")]
        public XmlDocument GetBlogsByTourId(string tourId)
        {
            try
            {
                return CreateReturnXmlDocument(blogSrv.GetBlogsByTourId(tourId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "删除指定日志")]
        public XmlDocument DeleteBlog(string inputBlog, bool deletePictures)
        {
            try
            {
                string msg;
                Blog blog = ReadModel<Blog>(inputBlog);
                if (blogSrv.DeleteBlog(blog, deletePictures, out msg))
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

        [WebMethod(Description = "保存日志")]
        public XmlDocument SaveBlog(string inputBlog)
        {
            try
            {
                string msg;
                Blog blog = ReadModel<Blog>(inputBlog);
                if (blogSrv.SaveBlog(blog, out msg))
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

        #endregion


        #region Comment Service

        [WebMethod(Description = "获取指定图片的评论")]
        public XmlDocument GetPictureCommentsByPictureId(string pictureId)
        {
            try
            {
                return CreateReturnXmlDocument(commentSrv.GetPictureCommentsByPictureId(pictureId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定景点的评论")]
        public XmlDocument GetSightsCommentsBySightsId(string sightsId)
        {
            try
            {
                return CreateReturnXmlDocument(commentSrv.GetSightsCommentsBySightsId(sightsId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定旅行的评论")]
        public XmlDocument GetTourCommentsByTourId(string tourId)
        {
            try
            {
                return CreateReturnXmlDocument(commentSrv.GetTourCommentsByTourId(tourId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取关于指定用户的评论")]
        public XmlDocument GetUserCommentsByUserId(string userId)
        {
            try
            {
                return CreateReturnXmlDocument(commentSrv.GetUserCommentsByUserId(userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "新增一条图片评论")]
        public XmlDocument InsertPictureComment(string inputComment)
        {
            try
            {
                string msg;
                PictureComment comment = ReadModel<PictureComment>(inputComment);
                if (commentSrv.InsertPictureComment(comment, out msg))
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

        [WebMethod(Description = "更新一条图片评论")]
        public XmlDocument UpdatePictureComment(string inputComment)
        {
            try
            {
                string msg;
                PictureComment comment = ReadModel<PictureComment>(inputComment);
                if (commentSrv.UpdatePictureComment(comment, out msg))
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

        [WebMethod(Description = "删除一条图片评论")]
        public XmlDocument DeletePictureComment(string inputComment)
        {
            try
            {
                string msg;
                PictureComment comment = ReadModel<PictureComment>(inputComment);
                if (commentSrv.DeletePictureComment(comment, out msg))
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

        [WebMethod(Description = "新增一条景点评论")]
        public XmlDocument InsertSightsComment(string inputComment)
        {
            try
            {
                string msg;
                SightsComment comment = ReadModel<SightsComment>(inputComment);
                if (commentSrv.InsertSightsComment(comment, out msg))
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

        [WebMethod(Description = "更新一条景点评论")]
        public XmlDocument UpdateSightsComment(string inputComment)
        {
            try
            {
                string msg;
                SightsComment comment = ReadModel<SightsComment>(inputComment);
                if (commentSrv.UpdateSightsComment(comment, out msg))
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

        [WebMethod(Description = "删除一条景点评论")]
        public XmlDocument DeleteSightsComment(string inputComment)
        {
            try
            {
                string msg;
                SightsComment comment = ReadModel<SightsComment>(inputComment);
                if (commentSrv.DeleteSightsComment(comment, out msg))
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

        [WebMethod(Description = "新增一条旅行评论")]
        public XmlDocument InsertTourComment(string inputComment)
        {
            try
            {
                string msg;
                TourComment comment = ReadModel<TourComment>(inputComment);
                if (commentSrv.InsertTourComment(comment, out msg))
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

        [WebMethod(Description = "更新一条旅行评论")]
        public XmlDocument UpdateTourComment(string inputComment)
        {
            try
            {
                string msg;
                TourComment comment = ReadModel<TourComment>(inputComment);
                if (commentSrv.UpdateTourComment(comment, out msg))
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

        [WebMethod(Description = "删除一条旅行评论")]
        public XmlDocument DeleteTourComment(string inputComment)
        {
            try
            {
                string msg;
                TourComment comment = ReadModel<TourComment>(inputComment);
                if (commentSrv.DeleteTourComment(comment, out msg))
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

        [WebMethod(Description = "新增一条用户评论")]
        public XmlDocument InsertUserComment(string inputComment)
        {
            try
            {
                string msg;
                UserComment comment = ReadModel<UserComment>(inputComment);
                if (commentSrv.InsertUserComment(comment, out msg))
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

        [WebMethod(Description = "更新一条用户评论")]
        public XmlDocument UpdateUserComment(string inputComment)
        {
            try
            {
                string msg;
                UserComment comment = ReadModel<UserComment>(inputComment);
                if (commentSrv.UpdateUserComment(comment, out msg))
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

        [WebMethod(Description = "删除一条用户评论")]
        public XmlDocument DeleteUserComment(string inputComment)
        {
            try
            {
                string msg;
                UserComment comment = ReadModel<UserComment>(inputComment);
                if (commentSrv.DeleteUserComment(comment, out msg))
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

        #endregion


        #region Dictionary Service

        [WebMethod(Description = "获取所有国家")]
        public XmlDocument GetCountries()
        {
            try
            {
                return CreateReturnXmlDocument(dictSrv.GetCountries());
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
                return CreateReturnXmlDocument(dictSrv.GetProvinces());
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
                return CreateReturnXmlDocument(dictSrv.GetCities());
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定国家的省份")]
        public XmlDocument GetProvincesByCountryId(string countryId)
        {
            try
            {
                return CreateReturnXmlDocument(dictSrv.GetProvincesByCountryId(countryId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定省份的城市")]
        public XmlDocument GetCitiesByProvinceId(string provinceId)
        {
            try
            {
                return CreateReturnXmlDocument(dictSrv.GetCitiesByProvinceId(provinceId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定国家的城市")]
        public XmlDocument GetCitiesByCountryId(string countryId)
        {
            try
            {
                return CreateReturnXmlDocument(dictSrv.GetCitiesByCountryId(countryId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定省份的国家")]
        public XmlDocument GetCountryByProvinceId(string provinceId)
        {
            try
            {
                return CreateReturnXmlDocument(dictSrv.GetCountryByProvinceId(provinceId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定城市的省份")]
        public XmlDocument GetProvinceByCityId(string cityId)
        {
            try
            {
                return CreateReturnXmlDocument(dictSrv.GetProvinceByCityId(cityId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定国家")]
        public XmlDocument GetCountryByCountryId(string countryId)
        {
            try
            {
                return CreateReturnXmlDocument(dictSrv.GetCountryByCountryId(countryId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定省份")]
        public XmlDocument GetProvinceByProvinceId(string provinceId)
        {
            try
            {
                return CreateReturnXmlDocument(dictSrv.GetProvinceByProvinceId(provinceId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定城市")]
        public XmlDocument GetCityByCityId(string cityId)
        {
            try
            {
                return CreateReturnXmlDocument(dictSrv.GetCityByCityId(cityId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取权限类型字典")]
        public XmlDocument GetPermissionsDict()
        {
            try
            {
                return CreateReturnXmlDocument("PermissionType", dictSrv.GetPermissionsDict());
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取旅行状态字典")]
        public XmlDocument GetTourStatusDict()
        {
            try
            {
                return CreateReturnXmlDocument("TourStatus", dictSrv.GetTourStatusDict());
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "新增国家")]
        public XmlDocument InsertCountry(string inputCountry)
        {
            try
            {
                string msg;
                Country country = ReadModel<Country>(inputCountry);
                if (dictSrv.InsertCountry(country, out msg))
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

        [WebMethod(Description = "更新国家")]
        public XmlDocument UpdateCountry(string inputCountry)
        {
            try
            {
                string msg;
                Country country = ReadModel<Country>(inputCountry);
                if (dictSrv.UpdateCountry(country, out msg))
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

        [WebMethod(Description = "删除国家")]
        public XmlDocument DeleteCountry(string inputCountry)
        {
            try
            {
                string msg;
                Country country = ReadModel<Country>(inputCountry);
                if (dictSrv.DeleteCountry(country, out msg))
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

        [WebMethod(Description = "新增省份")]
        public XmlDocument InsertProvince(string inputProvince)
        {
            try
            {
                string msg;
                Province province = ReadModel<Province>(inputProvince);
                if (dictSrv.InsertProvince(province, out msg))
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

        [WebMethod(Description = "更新省份")]
        public XmlDocument UpdateProvince(string inputProvince)
        {
            try
            {
                string msg;
                Province province = ReadModel<Province>(inputProvince);
                if (dictSrv.UpdateProvince(province, out msg))
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

        [WebMethod(Description = "删除省份")]
        public XmlDocument DeleteProvince(string inputProvince)
        {
            try
            {
                string msg;
                Province province = ReadModel<Province>(inputProvince);
                if (dictSrv.DeleteProvince(province, out msg))
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

        [WebMethod(Description = "新增城市")]
        public XmlDocument InsertCity(string inputCity)
        {
            try
            {
                string msg;
                City city = ReadModel<City>(inputCity);
                if (dictSrv.InsertCity(city, out msg))
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

        [WebMethod(Description = "更新城市")]
        public XmlDocument UpdateCity(string inputCity)
        {
            try
            {
                string msg;
                City city = ReadModel<City>(inputCity);
                if (dictSrv.UpdateCity(city, out msg))
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

        [WebMethod(Description = "删除城市")]
        public XmlDocument DeleteCity(string inputCity)
        {
            try
            {
                string msg;
                City city = ReadModel<City>(inputCity);
                if (dictSrv.DeleteCity(city, out msg))
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

        #endregion


        #region Picture Service

        [WebMethod(Description = "获取图片")]
        public XmlDocument GetPictureByPictureId(string pictureId)
        {
            try
            {
                return CreateReturnXmlDocument(pictureSrv.GetPictureByPictureId(pictureId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "保存图片")]
        public XmlDocument SavePictures(string inputPictures, string inputRemovedPictures)
        {
            try
            {
                string msg;
                List<Picture> pictures = ReadModelList<Picture>(inputPictures);
                List<Picture> removedPictures = ReadModelList<Picture>(inputRemovedPictures);
                if (pictureSrv.SavePictures(pictures, removedPictures, out msg))
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



        #endregion


        #region Sights Service

        [WebMethod(Description = "获取所有景点")]
        public XmlDocument GetSights()
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetSights());
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定国家的景点")]
        public XmlDocument GetSightsByCountryId(string countryId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetSightsByCountryId(countryId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定省份的景点")]
        public XmlDocument GetSightsByProvinceId(string provinceId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetSightsByProvinceId(provinceId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定城市的景点")]
        public XmlDocument GetSightsByCityId(string cityId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetSightsByCityId(cityId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定景点")]
        public XmlDocument GetSightsBySightsId(string sightsId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetSightsBySightsId(sightsId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定景点的平均评分")]
        public XmlDocument GetAverageStarsBySightsId(string sightsId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetAverageStarsBySightsId(sightsId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定用户上传的指定景点的图片")]
        public XmlDocument GetPicturesBySightsIdAndUploaderId(string sightsId, string uploaderId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetPicturesBySightsIdAndUploaderId(sightsId, uploaderId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取用户游览过的景点")]
        public XmlDocument GetVisitedSights(string userId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetVisitedSights(userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取用户游览过的指定国家的景点")]
        public XmlDocument GetVisitedSightsByCountryId(string countryId, string userId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetVisitedSightsByCountryId(countryId, userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取用户游览过的指定省份的景点")]
        public XmlDocument GetVisitedSightsByProvinceId(string provinceId, string userId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetVisitedSightsByProvinceId(provinceId, userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取用户浏览过的指定城市的景点")]
        public XmlDocument GetVisitedSightsByCityId(string cityId, string userId)
        {
            try
            {
                return CreateReturnXmlDocument(sightsSrv.GetVisitedSightsByCityId(cityId, userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "新增景点")]
        public XmlDocument InsertSights(string inputSights, string inputPictures)
        {
            try
            {
                string msg;
                Sights sights = ReadModel<Sights>(inputSights);
                List<Picture> pictures = ReadModelList<Picture>(inputPictures);
                if (sightsSrv.InsertSights(sights, pictures, out msg))
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


        [WebMethod(Description = "更新景点")]
        public XmlDocument UpdateSights(string inputSights, string inputPictures, string inputRemovedPictures)
        {
            try
            {
                string msg;
                Sights sights = ReadModel<Sights>(inputSights);
                List<Picture> pictures = ReadModelList<Picture>(inputPictures);
                List<Picture> removedPictures = ReadModelList<Picture>(inputRemovedPictures);
                if (sightsSrv.UpdateSights(sights, pictures, removedPictures, out msg))
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

        [WebMethod(Description = "删除景点")]
        public XmlDocument DeleteSights(string inputSights)
        {
            try
            {
                string msg;
                Sights sights = ReadModel<Sights>(inputSights);
                if (sightsSrv.DeleteSights(sights, out msg))
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

        #endregion


        #region Tour Service

        [WebMethod(Description = "获取指定用户的所有旅行")]
        public XmlDocument GetToursByUserId(string userId)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetToursByUserId(userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定旅行")]
        public XmlDocument GetTourByTourId(string tourId)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetTourByTourId(tourId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定景点相关的旅行")]
        public XmlDocument GetToursBySightsId(string sightsId)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetToursBySightsId(sightsId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取包括指定日期的旅行")]
        public XmlDocument GetToursByDate(DateTime date)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetToursByDate(date));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定景点相关，并包括指定日期的旅行")]
        public XmlDocument GetToursBySightsIdAndDate(string sightsId, DateTime date)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetToursBySightsIdAndDate(sightsId, date));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "删除旅行")]
        public XmlDocument DeleteTour(string inputTour, bool deletePictures)
        {
            try
            {
                string msg;
                Tour tour = ReadModel<Tour>(inputTour);
                if (tourSrv.DeleteTour(tour, deletePictures, out msg))
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

        [WebMethod(Description = "保存旅行")]
        public XmlDocument SaveTour(string inputTour, string inputSubTours, string inputRemovedSubTours)
        {
            try
            {
                string msg;
                Tour tour = ReadModel<Tour>(inputTour);
                List<SubTour> subTours = ReadModelList<SubTour>(inputSubTours);
                List<SubTour> removedSubTours = ReadModelList<SubTour>(inputRemovedSubTours);
                if (tourSrv.SaveTour(tour, subTours, removedSubTours, out msg))
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

        [WebMethod(Description = "获取指定旅行的子旅行")]
        public XmlDocument GetSubToursByTourId(string tourId)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetSubToursByTourId(tourId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定子旅行")]
        public XmlDocument GetSubTourByTourIdAndSubTourId(string tourId, string subTourId)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetSubTourByTourIdAndSubTourId(tourId, subTourId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定用户的子旅行")]
        public XmlDocument GetSubToursByUserId(string userId)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetSubToursByUserId(userId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定景点相关的所有子旅行")]
        public XmlDocument GetSubToursBySightsId(string sightsId)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetSubToursBySightsId(sightsId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定旅行的图片")]
        public XmlDocument GetPicturesByTourId(string tourId)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetPicturesByTourId(tourId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        [WebMethod(Description = "获取指定子旅行的图片")]
        public XmlDocument GetPicturesByTourIdAndSubTourId(string tourId, string subTourId)
        {
            try
            {
                return CreateReturnXmlDocument(tourSrv.GetPicturesByTourIdAndSubTourId(tourId, subTourId));
            }
            catch (Exception ex)
            {
                return CreateErrorXmlDocument(ex);
            }
        }

        #endregion

    }
}

