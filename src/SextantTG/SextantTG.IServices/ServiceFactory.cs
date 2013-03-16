using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace SextantTG.IServices
{
    public class ServiceFactory
    {
        private static readonly string SERVICES = ConfigurationManager.AppSettings["SERVICES"];
        private static readonly string DICT_SERVICE = ConfigurationManager.AppSettings["DICT_SERVICE"];
        private static readonly string BLOG_SERVICE = ConfigurationManager.AppSettings["BLOG_SERVICE"];
        private static readonly string USER_SERVICE = ConfigurationManager.AppSettings["USER_SERVICE"];
        private static readonly string COMMENT_SERVICE = ConfigurationManager.AppSettings["COMMENT_SERVICE"];
        private static readonly string SIGHTS_SERVICE = ConfigurationManager.AppSettings["SIGHTS_SERVICE"];
        private static readonly string TOUR_SERVICE = ConfigurationManager.AppSettings["TOUR_SERVICE"];
        private static readonly string PICTURE_SERVICE = ConfigurationManager.AppSettings["PICTURE_SERVICE"];

        public static T CreateService<T>() where T : IBaseService
        {
            T t;
            Type type = typeof(T);
            if (type.Equals(typeof(IBlogService))) { t = (T)Assembly.Load(SERVICES).CreateInstance(BLOG_SERVICE); }
            else if (type.Equals(typeof(IDictService))) { t = (T)Assembly.Load(SERVICES).CreateInstance(DICT_SERVICE); }
            else if (type.Equals(typeof(IUserService))) { t = (T)Assembly.Load(SERVICES).CreateInstance(USER_SERVICE); }
            else if (type.Equals(typeof(ICommentService))) { t = (T)Assembly.Load(SERVICES).CreateInstance(COMMENT_SERVICE); }
            else if (type.Equals(typeof(ISightsService))) { t = (T)Assembly.Load(SERVICES).CreateInstance(SIGHTS_SERVICE); }
            else if (type.Equals(typeof(ITourService))) { t = (T)Assembly.Load(SERVICES).CreateInstance(TOUR_SERVICE); }
            else if (type.Equals(typeof(IPictureService))) { t = (T)Assembly.Load(SERVICES).CreateInstance(PICTURE_SERVICE); }
            else { throw new ArgumentException("Type of T is unkown"); }

            if (t != null) { return t; }
            else { throw new Exception(string.Format("Cannot create service, Interface Name: {0}", type.ToString())); }
        }
    }
}
