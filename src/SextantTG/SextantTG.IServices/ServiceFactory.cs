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

        public static T CreateService<T>() where T : IBaseService
        {
            Type t = typeof(T);
            if (t.Equals(typeof(IBlogService))) { return (T)Assembly.Load(SERVICES).CreateInstance(BLOG_SERVICE); }
            else if (t.Equals(typeof(IDictService))) { return (T)Assembly.Load(SERVICES).CreateInstance(DICT_SERVICE); }
            else if (t.Equals(typeof(IUserService))) { return (T)Assembly.Load(SERVICES).CreateInstance(USER_SERVICE); }
            else if (t.Equals(typeof(ICommentService))) { return (T)Assembly.Load(SERVICES).CreateInstance(COMMENT_SERVICE); }
            else if (t.Equals(typeof(ISightsService))) { return (T)Assembly.Load(SERVICES).CreateInstance(SIGHTS_SERVICE); }
            else if (t.Equals(typeof(ITourService))) { return (T)Assembly.Load(SERVICES).CreateInstance(TOUR_SERVICE); }
            else { throw new ArgumentException("Type of T is unkown"); }
        }
    }
}
