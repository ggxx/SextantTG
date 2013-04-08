using SextantTG.AopAdvice;
using Spring.Aop.Framework;
using System;
using System.Configuration;
using System.Reflection;

namespace SextantTG.IDAL
{
    /// <summary>
    /// 提供静态方法，实例化DAL的工厂类, using factory pattern
    /// </summary>
    public sealed class DALFactory
    {
        private static readonly string DAL = ConfigurationManager.AppSettings["DAL"];
        private static readonly string BLOG_DAL = ConfigurationManager.AppSettings["BLOG_DAL"];
        private static readonly string CITY_DAL = ConfigurationManager.AppSettings["CITY_DAL"];
        private static readonly string COUNTRY_DAL = ConfigurationManager.AppSettings["COUNTRY_DAL"];
        private static readonly string FAVORITE_DAL = ConfigurationManager.AppSettings["FAVORITE_DAL"];
        private static readonly string PERMISSION_DAL = ConfigurationManager.AppSettings["PERMISSION_DAL"];
        private static readonly string PICTURE_DAL = ConfigurationManager.AppSettings["PICTURE_DAL"];
        private static readonly string PICTURECOMM_DAL = ConfigurationManager.AppSettings["PICTURECOMM_DAL"];
        private static readonly string PROVINCE_DAL = ConfigurationManager.AppSettings["PROVINCE_DAL"];
        private static readonly string SIGHTS_DAL = ConfigurationManager.AppSettings["SIGHTS_DAL"];
        private static readonly string SIGHTSCOMM_DAL = ConfigurationManager.AppSettings["SIGHTSCOMM_DAL"];
        private static readonly string SUBTOUR_DAL = ConfigurationManager.AppSettings["SUBTOUR_DAL"];
        private static readonly string TOUR_DAL = ConfigurationManager.AppSettings["TOUR_DAL"];
        private static readonly string TOURCOMM_DAL = ConfigurationManager.AppSettings["TOURCOMM_DAL"];
        private static readonly string USER_DAL = ConfigurationManager.AppSettings["USER_DAL"];
        private static readonly string USERCOMM_DAL = ConfigurationManager.AppSettings["USERCOMM_DAL"];
        private static readonly string DATA_CONTEXT = ConfigurationManager.AppSettings["DATA_CONTEXT"];

        /// <summary>
        /// 是否使用AOP
        /// </summary>
        private static readonly bool ENABLE_AOP = bool.Parse(ConfigurationManager.AppSettings["ENABLE_AOP"]);

        /// <summary>
        /// 创建一个数据连接层的实例
        /// </summary>
        /// <typeparam name="T">指定的数据类型</typeparam>
        /// <returns>指定数据类型的实例</returns>
        public static T CreateDAL<T>() where T : IBaseDAL
        {
            T t; //=default(T); 
            Type type = typeof(T);

            if (type.Equals(typeof(IBlogDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(BLOG_DAL);
            }
            else if (type.Equals(typeof(ICityDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(CITY_DAL);
            }
            else if (type.Equals(typeof(ICountryDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(COUNTRY_DAL);
            }
            else if (type.Equals(typeof(IFavoriteDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(FAVORITE_DAL);
            }
            else if (type.Equals(typeof(IPermissionDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(PERMISSION_DAL);
            }
            else if (type.Equals(typeof(IPictureDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(PICTURE_DAL);
            }
            else if (type.Equals(typeof(IPictureCommentDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(PICTURECOMM_DAL);
            }
            else if (type.Equals(typeof(IProvinceDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(PROVINCE_DAL);
            }
            else if (type.Equals(typeof(ISightsDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(SIGHTS_DAL);
            }
            else if (type.Equals(typeof(ISightsCommentDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(SIGHTSCOMM_DAL);
            }
            else if (type.Equals(typeof(ISubTourDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(SUBTOUR_DAL);
            }
            else if (type.Equals(typeof(ITourDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(TOUR_DAL);
            }
            else if (type.Equals(typeof(ITourCommentDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(TOURCOMM_DAL);
            }
            else if (type.Equals(typeof(IUserDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(USER_DAL);
            }
            else if (type.Equals(typeof(IUserCommentDAL)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(USERCOMM_DAL);
            }
            else if (type.Equals(typeof(IDataContext)))
            {
                t = (T)Assembly.Load(DAL).CreateInstance(DATA_CONTEXT);
            }
            else
            {
                throw new ArgumentException("Type of T is unkown");
            }

            //以下为AOP阶段新增代码
            if (ENABLE_AOP)
            {
                //Reflection
                //object o = System.Reflection.Assembly.Load("Spring.Aop").CreateInstance("Spring.Aop.Framework.ProxyFactory", false, BindingFlags.Default, null, new object[] { t }, null, new object[] { });
                //Type pf = o.GetType();
                //MethodInfo addAdvice = pf.GetMethod("AddAdvice", new Type[] { typeof(AopAlliance.Aop.IAdvice) });
                //addAdvice.Invoke(o, new object[] { new ExceptionAdvice() });
                //MethodInfo getProxy = pf.GetMethod("GetProxy", new Type[] { });
                //t = (T)getProxy.Invoke(o, null);

                ProxyFactory factory = new ProxyFactory(t);
                factory.AddAdvice(new ExceptionAdvice());

                if (type.Equals(typeof(ISightsDAL)))
                {
                    factory.AddAdvice(new SightsMethodInterceptor());
                    factory.AddAdvice(new SightsAfterReturningAdvice());
                }
                else if (type.Equals(typeof(ITourDAL)))
                {
                    factory.AddAdvice(new TourMethodInterceptor());
                    factory.AddAdvice(new TourAfterReturningAdvice());
                }
                else if (type.Equals(typeof(ISubTourDAL)))
                {
                    factory.AddAdvice(new SubTourMethodInterceptor());
                    factory.AddAdvice(new SubTourAfterReturningAdvice());
                }
                else if (type.Equals(typeof(IPictureDAL)))
                {
                    factory.AddAdvice(new PictureMethodInterceptor());
                    factory.AddAdvice(new PictureAfterReturningAdvice());
                }
                else if (type.Equals(typeof(IUserDAL)))
                {
                    factory.AddAdvice(new UserMethodInterceptor());
                }
                else if (type.Equals(typeof(IFavoriteDAL)))
                {
                    factory.AddAdvice(new FavoriteAfterReturningAdvice());
                }

                t = (T)factory.GetProxy();
            }
            //以上为AOP阶段新增代码

            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(string.Format("Cannot create DAL, Interface Name: {0}", type.ToString()));
            }
        }
    }
}
